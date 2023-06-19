using Microsoft.AspNetCore.Mvc;
using PustokBookStore.DAL;
using PustokBookStore.Entities;

namespace PustokBookStore.Areas.Manage.Controllers
{
    [Area("manage")]

    public class SliderController : Controller
    {
        private readonly PustokDbContext _context;

        public SliderController(PustokDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Slider> model = _context.Sliders.ToList();
            return View(model);
        }
    }
}
