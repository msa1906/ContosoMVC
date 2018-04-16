using Contoso.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoMVC.Controllers
{
    public class HomeController : Controller
    {
        private ContosoContext db = new ContosoContext();
        public ActionResult Index()
        {
            var personRepository = new PersonRepository(db);
            var list = personRepository.GetPeople();
            var person = personRepository.GetPersonByID(1);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}