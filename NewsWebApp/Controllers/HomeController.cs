using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsWebApp.Data;
using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        NewsContext db;
        public HomeController(ILogger<HomeController> logger, NewsContext context)
        {
              db = context;
            _logger = logger;

        }

        // init for the Db
        
        //public HomeController()
        //{
        
            
            
        //}
        public IActionResult Index()
        {
            var result = db.Categories.ToList();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        // we are passing the id of the category from the news table 
        public IActionResult News(int id)
        {
            Category c = db.Categories.Find(id);
            ViewBag.cat = c.Name;
            // here we compared the categoryid coming from the news with the category id from the cateogry table 
            var result = db.News.Where(x => x.CategoryId == id).OrderByDescending(x=>x.Date).ToList();
            return View(result);
        }
        public IActionResult DeleteNews(int id)
        {
          var News =  db.News.Find(id);
            db.Remove(News);
            db.SaveChanges();
           return RedirectToAction("Index");
        }
        //model  must be passed 
        [HttpPost]
        public IActionResult CreateContact(ContactUs model)
        {
            db.ContactUs.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
