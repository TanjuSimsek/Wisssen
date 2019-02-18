using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wissen.Model;
using Wissen.Service;

namespace Wissen.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService) {

            this.categoryService = categoryService;

        }



        // GET: Category
        public ActionResult Index()
        {
            var categories = categoryService.GetAll();
            return View(categories);
             
        }
        public ActionResult Craate()
        {
            var category = new Category();
            return View(category);

        }
    }
}