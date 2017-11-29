using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test_Dot_Net;

namespace EFCoreWebDemo.Controllers
{
    public class BookController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (var context = new EFCoreContext())
            {
                var model = await context.Authors.Include(a => a.Books).AsNoTracking().ToListAsync();
                return View(model);
            }
            
        }  

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            using(var context = new EFCoreContext())
            {
                var authorList = await context.Authors.AsNoTracking().ToListAsync();
                var selectList = authorList.Select(a => new SelectListItem{
                    Value = a.AuthorId.ToString(), 
                    Text = $"{a.FirstName} {a.LastName}"
                });
                // var authors = await context.Authors.Select(a => new SelectListItem {
                //     Value = a.AuthorId.ToString(), 
                //     Text = $"{a.FirstName} {a.LastName}"
                // }).ToListAsync();
                ViewBag.Authors = selectList;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title, AuthorId")] Book book)
        {
            using (var context = new EFCoreContext())
            {
                context.Books.Add(book);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
    }
}