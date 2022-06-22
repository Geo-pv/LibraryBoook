using LibraryBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LibraryBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            
            return View(db.Books.Include(s => s.Author).ToList());
        }
        public void Reating(/*string userName,*/float rate, int BookId)
        {
            
        }
        [HttpPost]
        public IActionResult Search(string search)
        {
            ViewBag.Search = db.Books.Where(s => s.Title.Contains(search)).ToList();
            {

            }
            return View(ViewBag.Search);
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