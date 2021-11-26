using Lab01_MVC_VStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01_MVC_VStudio.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            @ViewBag.Agora = $"Hello MVC! {DateTime.Now}";
            return View();
        }

        public ActionResult Filme()
        {
            Filme filme = new Filme()
            {
                Titulo = "Inglourious Basterds", Genero = "War", Assistido = true
            };

            return View(filme);
        }
    }
}