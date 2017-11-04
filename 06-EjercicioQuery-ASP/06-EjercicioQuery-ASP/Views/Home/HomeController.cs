using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _06_EjercicioQuery_ASP.Views.Home
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(Boolean? esMiPrimeraVez)
        {

            if (esMiPrimeraVez != null)
            {
                ViewData["resultado"] = "No es tu primera vez";
            }

            else
            {
                ViewData["resultado"] = "Es tu primera vez";
            }

            return View();
        }
    }
}