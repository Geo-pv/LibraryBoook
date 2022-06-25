using LibraryBook.Models;
using LibraryBook.ViewModels;
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

        public IActionResult Index(int? idAuthor, int? idGenre)
        {
            //данные для фильтра
            ViewBag.Authors = db.Authors.ToList();
            ViewBag.Genres = db.Genres.ToList();
            //список книг, которые выводятся на экран
            var listBooks = new List<OblogkaView>();
            //Список авторов
            List<Book> queryA = new List<Book>();
            //список жанров
            List<GenBook> listGenres;
            //стандартный список книг, т.е. бз фильтров
            queryA = db.Books.Include(s => s.Author).ToList();
            //если филтруем по опрделённому автору
            if (idAuthor != null)
            {
                queryA = db.Books.Include(s => s.Author).Where(s => s.AuthorId == idAuthor).ToList();
            }
            //если фильтруем по определённому жанру
            if (idGenre != null)
            {
                queryA.Clear();
                listGenres = db.GenBooks.Where(s => s.GenreId == idGenre).ToList();
                foreach (var item in listGenres)
                {
                    queryA.Add(db.Books.Include(s => s.Author).Where(s => s.Id == item.BookId).FirstOrDefault());
                }
            }
            //если общий фильтр по жанру и автору
            if((idAuthor != null)&& (idGenre != null))
            {
                queryA.Clear();
                listGenres = db.GenBooks
                    .Where(s => s.GenreId == idGenre)
                    .Where(s => s.Books.AuthorId == idAuthor).ToList();
                foreach (var item in listGenres)
                {
                    queryA.Add(db.Books.Include(s => s.Author).Where(s=>s.Id == item.BookId).FirstOrDefault());
                }
            }
            //формируем список для вывода
            foreach (var item in queryA)
            {
                var oblogka = new OblogkaView();
                oblogka.Id = item.Id;
                oblogka.Title = item.Title;
                oblogka.Author = item.Author.Full;
                List<Genre> genres = new();
                foreach (var gen in db.GenBooks.Where(s => s.BookId == item.Id).Include(s => s.Genres).ToList())
                {
                    genres.Add(db.Genres.Find(gen.GenreId));
                }
                oblogka.Genres = genres;
                oblogka.Image = item.Image;
                oblogka.Page = item.Pages;
                listBooks.Add(oblogka);
            }
            return View(listBooks);
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
            if (db.RateBooks.Where(r => r.UserId == user).Where(r => r.BookId == BookId).FirstOrDefault() == null)
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
            var listBooks = new List<OblogkaView>();
            foreach (var item in db.Books.Include(s=>s.Author).Where(s => s.Title.Contains(search)).ToList())
            {
                var oblogka = new OblogkaView();
                oblogka.Id = item.Id;
                oblogka.Title = item.Title;
                oblogka.Author = item.Author.Full;
                List<Genre> genres = new();
                foreach (var gen in db.GenBooks.Where(s => s.BookId == item.Id).Include(s => s.Genres).ToList())
                {
                    genres.Add(db.Genres.Find(gen.GenreId));
                }
                oblogka.Genres = genres;
                oblogka.Image = item.Image;
                oblogka.Page = item.Pages;
                listBooks.Add(oblogka);
            }
            return View(listBooks);
        }
        public IActionResult Top()
        {
            var listBooks = new List<OblogkaView>();
            //Список авторов
            List<Book> queryA = new List<Book>();
            //Сортируем в обратном орядке, от большего к меньшему
            var listGenres = db.RateBooks.OrderByDescending(s=>s.Rate).Take(10).ToList();
            foreach (var item in listGenres)
            {
                queryA.Add(db.Books.Include(s => s.Author).Where(s => s.Id == item.BookId).FirstOrDefault());
            }
            foreach (var item in queryA)
            {
                var oblogka = new OblogkaView();
                oblogka.Id = item.Id;
                oblogka.Title = item.Title;
                oblogka.Author = item.Author.Full;
                List<Genre> genres = new();
                foreach (var gen in db.GenBooks.Where(s => s.BookId == item.Id).Include(s => s.Genres).ToList())
                {
                    genres.Add(db.Genres.Find(gen.GenreId));
                }
                oblogka.Genres = genres;
                oblogka.Image = item.Image;
                oblogka.Page = item.Pages;
                listBooks.Add(oblogka);
            }
            return View(listBooks);
        }

        /// <summary>
        /// Представление, для чтения текстового файла
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> ReadBook(int id)
        {
            var file = db.Books.Where(s => s.Id == id).FirstOrDefault().TextFile;

            //Ищем книгу в базе по id
            ViewBag.pathtxt = _appEnvironment.WebRootPath + file;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}