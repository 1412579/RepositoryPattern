using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using DataService.Services;
using DataService.Interfaces;
namespace RepositoryPattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private ISession _session => _httpContextAccessor.HttpContext.Session;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="accountService"></param>
        /// <param name="LogLoginService"></param>
        /// <returns></returns>
        public HomeController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public IActionResult Index()
        {
            ViewBag.ListCate = _categoryService.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ProductCategory model)
        {

            var isValid = _categoryService.Create(model);
            ViewBag.ListCate = _categoryService.GetAll();
            if (isValid)
            {
                ViewBag.Msg = "Đã tạo cate thành công!"; ;
                ModelState.Remove("InvalidAuth");
            }
            else
            {
                ModelState.AddModelError("InvalidAuth", "Đã có lỗi xảy ra.");
            }
            return View(model);
   
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
