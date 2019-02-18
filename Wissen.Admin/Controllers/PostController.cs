using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wissen.Model;
using Wissen.Service;

namespace Wissen.Admin.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        public PostController(IPostService postService, ICategoryService categoryService) {
            this.postService = postService;
            this.categoryService = categoryService;


        }

        // GET: Post
        public ActionResult Index()
        {
            var post = postService.GetAll();
            return View(post);
        }
        public ActionResult Craate()
        {
            var post = new Post();
            return View(post);

        }
    }
}