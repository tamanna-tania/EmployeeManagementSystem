using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement1.Models;
using EmployeeManagement1.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagement1.Controllers
{
    public class AccountTypeController : Controller
    {
        private readonly IAccountRepository _account;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AccountTypeController(IAccountRepository account, IHostingEnvironment hostingEnvironment)
        {
            _account = account; 
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                pageNumber = 1;

            }
            else
            {
                searchString = currentFilter;

            }
            ViewData["CurrentFilter"] = searchString;

            var data = _account.GetAccounts();
            if (!string.IsNullOrEmpty(searchString))
            {
                data = data.Where(p => p.EmployeeName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    data = data.OrderByDescending(p => p.EmployeeName);
                    break;
                default:
                    data = data.OrderBy(p => p.EmployeeName);
                    break;
            }
            int pageSize = 3;
            return View(PaginatedList<Account>.Create(data.AsQueryable<Account>(), pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            TypeDDL();
            return View();
        }
        [HttpPost]
        public IActionResult Create(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                string urlImage = "";
                var files = HttpContext.Request.Form.Files;
                foreach (var image in files)
                {
                    if (image != null && image.Length > 0)
                    {
                        var file = image;
                        var uploadFile = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        if (file.Length > 0)
                        {
                            var fileName = Guid.NewGuid().ToString().Replace("_", "") + file.FileName;
                            using (var fileStream = new FileStream(Path.Combine(uploadFile, fileName), FileMode.Create))
                            {
                                file.CopyTo(fileStream);
                                urlImage = fileName;
                            }
                        }
                    }
                }
                var data = new Account()
                {
                    EmployeeName = model.EmployeeName,
                    AccountNumber = model.AccountNumber,
                    Salary = model.Salary,
                    TypeId = model.TypeId,
                    UrlImage = urlImage
                };
                _account.AddAcount(data);
                return RedirectToAction("Index");
            }
            TypeDDL();
            return View();
        }

        private void TypeDDL(object selectType = null)
        {
            var typelist = _account.GetTypes();
            ViewBag.ListType = new SelectList(typelist, "Id", "TypeName", selectType);
        }

        public IActionResult Edit(int id)
        {
            var product = _account.GetAccountById(id);
            TypeDDL();
            return View();
        }
        [HttpPost]
        public IActionResult Edit(int id, Account changeProduct)
        {
            //if (ModelState.IsValid)
            //  {
            string urlImage = "";
            var files = HttpContext.Request.Form.Files;
            foreach (var image in files)
            {
                if (image != null && image.Length > 0)
                {
                    var file = image;
                    var uploadFile = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    if (file.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString().Replace("_", "") + file.FileName;
                        using (var fileStream = new FileStream(Path.Combine(uploadFile, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            urlImage = fileName;
                        }
                    }
                }
            }
            var data = _account.GetAccountById(id);
            data.EmployeeName = changeProduct.EmployeeName;
            data.AccountNumber = changeProduct.AccountNumber;
            data.Salary = changeProduct.Salary;
            data.TypeId = changeProduct.TypeId;
            if (data.UrlImage != null)
            {
                string fp = Path.Combine(_hostingEnvironment.WebRootPath, "images", data.UrlImage);
                System.IO.File.Delete(fp);
            }
            data.UrlImage = urlImage;
            _account.UpdateAccount(data);
            return RedirectToAction("Index");
            //}
            TypeDDL();
            return View();
        }

        public ActionResult Delete(int id)
        {
            _account.DeleteAccount(id);
            return RedirectToAction("Index");
        }
    }
}
