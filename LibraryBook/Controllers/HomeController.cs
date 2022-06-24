using LibraryBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LibraryBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IWebHostEnvironment _appEnvironment;
        private readonly ApplicationContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            _logger = logger;
            db = context;
            _appEnvironment = appEnvironment;
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
            return View(db.Books.Where(s => s.Title.Contains(search)).ToList());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Представление, для чтения текстового файла
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> ReadBook(int id)
        {
            var file = db.Books.Where(s=>s.Id == id).FirstOrDefault().TextFile;

            //Ищем книгу в базе по id
            ViewBag.path = _appEnvironment.WebRootPath + file;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}