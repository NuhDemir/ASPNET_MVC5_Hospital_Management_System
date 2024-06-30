using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models;
using PagedList;
using PagedList.Mvc;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Controllers
{
    public class PersonelController : Controller
    {

        readonly DatabaseContext db = new DatabaseContext();
        // GET: Personel
        /*------------PERSONEL ANASAYFASI-------------------*/
        [Authorize]
        public ActionResult Personel(string p, int sayfa = 1)
        {
                var degerler = from k in db.TBLPersonel select k;
                if (!string.IsNullOrEmpty(p))
                {
                    degerler = degerler.Where(m => m.Ad.Contains(p));
                }
                return View(degerler.ToList().ToPagedList(sayfa, 3));
            }
        
        /*------------PERSONEL EKLEME-------------------*/
        [HttpGet]
        [Authorize]
        public ActionResult PersonelEkle()
        {
            if (Session["LogKisi"] == null)
            {
                return RedirectToAction("PersonelGiris", "Login");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult PersonelEkle(Personel p)
        {
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.TBLPersonel.Add(p);
                        db.SaveChanges();
                        return RedirectToAction("Personel");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Veritabanına kaydetme sırasında bir hata oluştu: " + ex.Message);
                        return View(p); // Hata durumunda formu tekrar göster
                    }
                }
                else
                {
                    // ModelState geçerli değilse, formu tekrar göster
                    return View(p);
                }
            }


        /*------------PERSONEL SİLME-------------------*/
        [Authorize]
        public ActionResult PersonelSil(int id)
        {
                var personel = db.TBLPersonel.Find(id);
                db.TBLPersonel.Remove(personel);
                db.SaveChanges();
                return RedirectToAction("Personel");

            }
        
        /*------------PERSONEL GÜNCELLEME-------------------*/
        [Authorize]
        public ActionResult PersonelGetir(int id)
        {
                var pers = db.TBLPersonel.Find(id);
                return View("PersonelGetir", pers);
            }
        
        [Authorize]
        public ActionResult PersonelGuncelle(Personel p)
        {
                try
                {
                    var personelToUpdate = db.TBLPersonel.Find(p.PersonelID);
                    if (personelToUpdate != null)
                    {
                        personelToUpdate.Departman = p.Departman;
                        personelToUpdate.TCKNO = p.TCKNO;
                        personelToUpdate.Ad = p.Ad;
                        personelToUpdate.Soyad = p.Soyad;
                        personelToUpdate.DogumTarihi = p.DogumTarihi;
                        personelToUpdate.TelefonNo = p.TelefonNo;
                        personelToUpdate.Sifre = p.Sifre;

                        db.SaveChanges();
                    }
                    return RedirectToAction("Personel");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu: " + ex.Message);
                    return View(p); // Hata durumunda formu tekrar göster
                }
            
        }


      


    }

}