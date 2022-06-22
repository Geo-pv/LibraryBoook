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
        public IActionResult Reating(string userName, float rate, int BookId)
        {
            var user = db.Users.Where(s => s.Login == userName)
                .FirstOrDefault().Id;
            if (user == null)
                user = 0;
            RateBook rateBook = new()
            {
                Rate = rate,
                UserId = user,
                BookId = BookId
            };
            if (db.RateBooks.Where(r=>r.UserId == user).Where(r=>r.BookId == BookId) == null)
            {
                db.Add(rateBook);
            }
            else
            {
                db.Update(rateBook);                
            }
            db.SaveChanges();
            return RedirectToAction("Index");
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