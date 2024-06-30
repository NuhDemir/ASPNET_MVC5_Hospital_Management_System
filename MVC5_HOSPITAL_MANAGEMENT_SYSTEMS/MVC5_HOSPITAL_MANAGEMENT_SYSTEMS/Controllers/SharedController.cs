using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        DatabaseContext db = new DatabaseContext();
        public ActionResult AdminLayout()
        {
            var deger = db.TBLMessage.ToList();
            return View(deger);
        }
    }
}