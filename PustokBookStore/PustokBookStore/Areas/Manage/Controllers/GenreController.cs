using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokBookStore.DAL;
using PustokBookStore.Entities;

namespace PustokBookStore.Areas.Manage.Controllers
{
    [Area("manage")]
    public class GenreController : Controller
    {
        private readonly PustokDbContext _context;
        public GenreController(PustokDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
           List<Genre> model = _context.Genres.Include(x=>x.Books).ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            if(_context.Genres.Any(x=> x.Name == genre.Name))
            {
                ModelState.AddModelError("Name", "Name is already taken.");
                return View();
            }
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Genre genre = _context.Genres.FirstOrDefault(x=>x.Id == id);

            if(genre == null)
            {
                return View("Error");
            }

            return View(genre);
        }

        [HttpPost]
        public IActionResult Edit(Genre genre)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            if (_context.Genres.Any(x => x.Name == genre.Name))
            {
                ModelState.AddModelError("Name", "Name is already taken.");
                return View();
            }

            Genre existGenre = _context.Genres.FirstOrDefault(x=>x.Id==genre.Id);

            if(existGenre == null)
            {
                return View("Error");
            }

            existGenre.Name = genre.Name;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
