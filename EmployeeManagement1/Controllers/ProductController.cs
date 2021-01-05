using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement1.Controllers
{
    public class ProductController : Controller
    {




        private readonly AppDbContext _entities;

        public ProductController(AppDbContext entities)
        {
            _entities = entities;
        }
        public ViewResult Index()
        {

            return View();
        }
       

        [HttpGet]
        public JsonResult ProductList()
        {
            var data = _entities.Products.ToList();

            return Json(data, new Newtonsoft.Json.JsonSerializerSettings());

        }
        [HttpPost]
        public JsonResult AddProduct([FromBody]Product product)
        {
          
            _entities.Products.Add(product);
            _entities.SaveChanges();
            var p= _entities.Products.ToList();
            return Json(p, new Newtonsoft.Json.JsonSerializerSettings());
          
        }
        [HttpPost]
        public JsonResult UpdateProduct([FromBody]Product product)
        {
            var upproduct = _entities.Products.FirstOrDefault(x => x.Id == product.Id);
            upproduct.ProductName = product.ProductName;
            upproduct.Price = product.Price;
            _entities.Entry(upproduct).State = EntityState.Modified;
            _entities.SaveChanges();
            var p = _entities.Products.ToList(); 
            return Json(p, new Newtonsoft.Json.JsonSerializerSettings());

          
        }

        public string DeleteProduct(int? id)
        {
            var data = _entities.Products
                   .Where(x => x.Id == id)
                   .Select(x => x)
                   .FirstOrDefault();

            if (data != null)
            {
                _entities.Products.Remove(data);
            }
            _entities.SaveChanges();

            return "Delete Success full";
        }
    }
}

