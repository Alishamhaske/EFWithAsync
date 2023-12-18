using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFWithAsync.Data;
using EFWithAsync.Models;
using EFWithAsync.Services;

namespace EFWithAsync.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _context;

        public BooksController(IBookService context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var model = await _context.GetBooks();
            return View(model);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var book = await _context.GetBookById(id);
               
            if (book == null)
            { 
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Author,price")] Book book)
        {
            if (ModelState.IsValid)
            {
                int result = await _context.AddBook(book);
                if (result >= 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View(book); 
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.GetBookById(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Author,price")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int result = await _context.UpdateBook(book);
                    if (result >= 1)
                        return RedirectToAction(nameof(Index));
                    else
                        return View(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var book = await _context.GetBookById(id);
             
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
          /*  if (_context.Books == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Books'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();*/
            return RedirectToAction(nameof(Index));
        }

        /*private bool BookExists(int id)
        {
          return (_context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
