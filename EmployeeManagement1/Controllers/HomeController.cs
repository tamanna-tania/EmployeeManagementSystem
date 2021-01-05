using EmployeeManagement1.Models;
using EmployeeManagement1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement1.Controllers
{
    //[Authorize]
    public class HomeController:Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            this._hostingEnvironment = hostingEnvironment;
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            List<Employee> employees = _employeeRepository.GetEmployees().ToList();
            ////ViewData["Employees"] = employees;
            //ViewBag.Employees = employees;

            return View(employees);
        }
        [AllowAnonymous]
        public ViewResult Details(int id)
        {
           //// throw new Exception();
            Employee employee = _employeeRepository.GetEmployeeDetails(id);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id);
            }

            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                Employee = _employeeRepository.GetEmployeeDetails(id),
                PageTitle = "Employee Details"
            };
            return View(homeIndexViewModel);
        }
        //[Authorize]
        public ActionResult Create()
        {
            return View();
        }
        //[Authorize]
        [HttpPost]        
        public ActionResult Create(CreateEmployeeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessFileUpload(vm);
                //string uniqueFileName = null;
                //if (vm.Photo != null)
                //{
                //    string uploadFolder =Path.Combine(_hostingEnvironment.WebRootPath, "images");
                //    uniqueFileName = Guid.NewGuid().ToString() + "_" + vm.Photo.FileName;
                //    string filePath = Path.Combine(uploadFolder, uniqueFileName);

                //    vm.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                //}
                Employee newEmployee = new Employee
                {
                    Name = vm.Name,
                    Email = vm.Email,
                    Department = vm.Department,
                    PhotoPath = uniqueFileName
                };
                _employeeRepository.AddEmployee(newEmployee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
                //Employee newEmployee = _employeeRepository.AddEmployee(obj);
                //return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Update(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeDetails(id);
            EditEmployeeViewModel vm = new EditEmployeeViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath,
                PageTitle = "Update Employee"
            };
            
            return View(vm);
        }
        [HttpPost]
        public IActionResult Update(EditEmployeeViewModel obj)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployeeDetails(obj.Id);
                employee.Name = obj.Name;
                employee.Email = obj.Email;
                employee.Department = obj.Department;
                if (obj.Photo != null)
                {
                    if (obj.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images",obj.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                        
                    }
                    employee.PhotoPath = ProcessFileUpload(obj);
                }
                Employee emp = _employeeRepository.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }


        private string ProcessFileUpload(CreateEmployeeViewModel vm)
        {
            string uniqueFileName = null;
            if (vm.Photo != null)
            {
                string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + vm.Photo.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    vm.Photo.CopyTo(fileStream);
                }                
            }
            return uniqueFileName;
        }




        [HttpPost]
        public ActionResult Delete(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeDetails(id);
            if (employee != null)
            {
                Employee deleteEmp = _employeeRepository.DeleteEmployee(employee.Id);
                return RedirectToAction("Index");
            }
            return View();
        }
        public PartialViewResult PartialDetails(int? id)
        {
            if (id!=null)
            {
                Employee obj = _employeeRepository.GetEmployeeDetails((int)id)/*.SingleOrDefault(u => u.EmployeeId == id)*/;
                Employee vobj = new Employee();
                vobj.Name = obj.Name;

                vobj.Email = obj.Email;
                //vobj.PhotoPath = obj.PhotoPath;
                vobj.Id = obj.Id;
                vobj.Department = obj.Department;
                ViewBag.Details = "Show";
                return PartialView("_EmployeeDEtails", vobj);
            }
            return null;
        }

    }
}
