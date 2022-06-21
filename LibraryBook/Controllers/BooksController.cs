using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryBook.Models;

namespace LibraryBook.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationContext db;
        IWebHostEnvironment _appEnvironment;

        public BooksController(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;   
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await db.Books.Include(s => s.Author).ToListAsync();
            return View(books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || db.Books == null)
            {
                return NotFound();
            }

            var book = await db.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewBag.IdAuthor = new SelectList(db.Authors, "Id", "Full");
            ViewBag.MoreGenre = new SelectList(db.Genres, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,DateCreated,Pages,IdAuthor")] Book book, List<int>MoreGenre,IFormFile file)
        { 
            if (ModelState.IsValid)
            {
                string path = "/Foto/" + Path.GetFileName(file.FileName);
                using (var filestream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }
                book.Image = path;
                db.Add(book);
                await db.SaveChangesAsync();
                foreach (var item in MoreGenre)
                {
                    db.GenBooks.Add(new GenBook { idBook = book.Id, idGenre = item });
                }
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdAuthor = new SelectList(db.Authors, "Id", "Full");
            ViewBag.MoreGenre = new SelectList(db.Genres, "Id", "Name");
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.Books == null)
            {
                return NotFound();
            }

            var book = await db.Books.FindAsync(id);
            ViewBag.IdAuthor = new SelectList(db.Authors, "Id", "Full", db.Authors.Find(book.IdAuthor));
            ViewBag.MoreGenre = new SelectList(db.Genres, "Id", "Name", db.GenBooks.Where(s => s.idBook == id).Select(s=>s.idGenre));
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Title,DateCreated,Pages,IdAuthor")] Book book, List<int> MoreGenre, IFormFile file)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(file != null)
                    {
                        string path = "/Foto/" + Path.GetFileName(file.FileName);
                        using (var filestream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await file.CopyToAsync(filestream);
                        }
                        book.Image = path;
                        db.Update(book);
                        await db.SaveChangesAsync();
                        foreach (var item in MoreGenre)
                        {
                            db.GenBooks.Add(new GenBook { idBook = book.Id, idGenre = item });
                        }

                    }
                    db.Update(book);
                    await db.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdAuthor = new SelectList(db.Authors, "Id", "Full");
            ViewBag.MoreGenre = new MultiSelectList(db.Genres, "Id", "Name", db.GenBooks.Where(s => s.idBook == id).Select(s => s.idGenre));
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.Books == null)
            {
                return NotFound();
            }

            var book = await db.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (db.Books == null)
            {
                return Problem("Entity set 'ApplicationContext.Books'  is null.");
            }
            var book = await db.Books.FindAsync(id);
            if (book != null)
            {
                db.Books.Remove(book);
            }
            
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return (db.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
