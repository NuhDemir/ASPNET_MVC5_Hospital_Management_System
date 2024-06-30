using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography.X509Certificates;
using MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models;
using PagedList;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Controllers
{
    public class AnasayfaController : Controller
    {


        DatabaseContext db = new DatabaseContext();



        // GET: Anasayfa
        [AllowAnonymous]
        public ActionResult Anasayfa()
        { var degerler = db.TBLYorum.ToList();
            return View(degerler);
        }
        [AllowAnonymous]
        public ActionResult AmacveHedeflerimiz()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Degerlerimiz()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult DiyabetOkulu()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult DiyalizUnitesi()
        {
            return View();
        }
        [HttpPost, ActionName("Doktorlarimiz")]
        [Authorize]
        public ActionResult Doktorlarimiz2()
        {
            Session.Remove("LogKisi");
            return RedirectToAction("DoktorGirs", "Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Doktorlarimiz(string p)
        {
            var degerler = from k in db.TBLDoktor select k;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.Ad.Contains(p));
            }
            return View(degerler.ToList());
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult DoktorDetay(int id)
        {
            using (var dbContext = new DatabaseContext())
            {
                var doktor = dbContext.TBLDoktor.FirstOrDefault(r => r.DoktorID == id);
                if (doktor == null)
                    return HttpNotFound();

                return View(doktor);
            }
        }

        [AllowAnonymous]
        public ActionResult EvdeSaglik()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Hastanemiz()
        {

            return View();
        }
        [AllowAnonymous]
        public ActionResult HizmetBinalarimiz()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult IletisimEkle()
        {
            var model = new Message();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult IletisimEkle(Message m)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.TBLMessage.Add(m);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Your message has been sent. Thank you!";
                    return RedirectToAction("Anasayfa");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Veritabanına kaydetme sırasında bir hata oluştu: " + ex.Message);
                }
            }
            // ModelState geçerli değilse veya hata durumunda formu tekrar göster
            return View(m);
        }



        [AllowAnonymous]
        public ActionResult KonusmaTerapi()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Palyatif()
        {
            return View();
        }
        [HttpPost, ActionName("Sonuclarim")]
        [Authorize]
        public ActionResult Sonuclarim2()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("PersonelGiris", "Login");
        }

        [Authorize]
        public ActionResult Sonuclarim()
        {
            
                ViewBag.giris = "Giriş Başarılı";
                string kullanıcı = Session["LogKisi"].ToString();
                var a = int.Parse(kullanıcı);
                var personels = db.TBLPersonel.Where(x => x.PersonelID == a).ToList();
                return View(personels);
            
        }

        [AllowAnonymous]
        public ActionResult Tarihcemiz()
        {
            return View();
        }
       

    }
}