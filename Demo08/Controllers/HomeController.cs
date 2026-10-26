using Demo08.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo08.Controllers
{
    public class HomeController : Controller
    {
        private readonly SystemDbContext context;

        //Injection de dépendances par le constucteur
        public HomeController(SystemDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Authors.ToList());
        }

       
    }
}
