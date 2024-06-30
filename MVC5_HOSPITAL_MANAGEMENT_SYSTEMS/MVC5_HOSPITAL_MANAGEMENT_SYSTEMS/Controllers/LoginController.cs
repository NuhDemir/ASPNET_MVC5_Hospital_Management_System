using MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;



namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Controllers
{
    public class LoginController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult DoktorGiris()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult DoktorGiris(Doktor d)
        {

            var bilgiler = db.TBLDoktor.FirstOrDefault(x => x.TCKNO == d.TCKNO    && x.Sifre == d.Sifre);
            string doktorIDString = d.TCKNO.ToString();

            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(d.TCKNO, false);
                return RedirectToAction("Islem", "Muayene");

            }
            else
            {
                ViewBag.Giris = "Giriş Başarısız:(";
                return View();
            }


        }
        [AllowAnonymous]
        public ActionResult PersonelGiris()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult PersonelGiris(Personel z)
        {
            var bilgiler = db.TBLPersonel.FirstOrDefault(x => x.TCKNO == z.TCKNO && x.Sifre == z.Sifre);
            string doktorIDString = z.TCKNO.ToString();

            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(z.TCKNO, false);
                return RedirectToAction("Islem", "PersonelIslem");

            }
            else
            {
                ViewBag.Giris = "Giriş Başarısız:(";
                return View();
            }


        }

        [AllowAnonymous]
        public ActionResult AdminGiris()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AdminGiris(Admin d)
        {
            var bilgiler = db.TBLAdmin.FirstOrDefault(x => x.TCKNO == d.TCKNO && x.Sifre == d.Sifre);
            string doktorIDString = d.TCKNO.ToString();

            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(d.TCKNO, false);
                return RedirectToAction("Anasayfa", "Admin");
            }
            else
            {
                ViewBag.Giris = "Giriş Başarısız:(";
                return View();

            }
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            return RedirectToAction("Anasayfa", "Anasayfa");
        }


    }
}