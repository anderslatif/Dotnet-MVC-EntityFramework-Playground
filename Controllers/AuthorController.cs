using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test_Dot_Net
{
    public class AuthorController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // instantiated in a using block so that it is disposed of correctly
            using (var context = new EFCoreContext())
            {
                var model = await context.Authors.AsNoTracking().ToListAsync();
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FirstName, LastName")] Author author)
        {
            using (var context = new EFCoreContext())
            {
                context.Add(author);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
    }    
}