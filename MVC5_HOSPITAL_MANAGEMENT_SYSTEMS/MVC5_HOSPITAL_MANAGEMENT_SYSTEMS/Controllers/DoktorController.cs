using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models;
using PagedList;
using PagedList.Mvc;


namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Controllers
{
    public class DoktorController : Controller
    {

        // GET: Doktor  

        readonly DatabaseContext db = new DatabaseContext();
        /*------------DOKTOR ANASAYFASI-------------------*/
        [Authorize]
        public ActionResult Doktor(string p, int sayfa = 1)
        {
           
                var degerler = from k in db.TBLDoktor select k;
                if (!string.IsNullOrEmpty(p))
                {
                    degerler = degerler.Where(m => m.Poliklinik.Contains(p));
                }
                return View(degerler.ToList().ToPagedList(sayfa, 3));
            
        }
        /*------------DOKTOR EKLEME-------------------*/
        [HttpGet]
        [Authorize]
        public ActionResult DoktorEkle()
        {
            
                return View();
            
        }
        [Authorize]
        [HttpPost]
        public ActionResult DoktorEkle(Doktor d)
        {
           
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (!ModelState.IsValid && Request.Files.Count > 0)
                        {
                            return View("DoktorEkle");
                        }
                        //string fileName = Path.GetFileName(Request.Files[0].FileName);
                        //string uzantı = Path.GetExtension(Request.Files[0].FileName);
                        //string yol = "~/Image/" + fileName + uzantı;
                        //Request.Files[0].SaveAs(Server.MapPath(yol));
                        //d.DoktorFoto = "/Image/" + fileName + uzantı;
                        db.TBLDoktor.Add(d);
                        db.SaveChanges();
                      
                        return RedirectToAction("Doktor");


                        //return RedirectToAction("Doktor");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Veritabanına kaydetme sırasında bir hata oluştu: " + ex.Message);
                        return View(d); // Hata durumunda formu tekrar göster
                    }
                }
                else
                {
                    // ModelState geçerli değilse, formu tekrar göster
                    return View(d);
                }
            
        }
        /*------------DOKTOR SİLME-------------------*/
        [Authorize]
        public ActionResult DoktorSil(int id)
        {
           
                var doktor = db.TBLDoktor.Find(id);
                db.TBLDoktor.Remove(doktor);
                db.SaveChanges();
                return RedirectToAction("Doktor");
            }
        

        /*------------PERSONEL GÜNCELLEME-------------------*/
        [Authorize]
        public ActionResult DoktorGetir(int id)
        {
                var dokt = db.TBLDoktor.Find(id);
                return View("DoktorGetir", dokt);
            }
        
        [Authorize]
        public ActionResult DoktorGuncelle(Doktor d)
        {
            
                try
                {
                    var doktorToUpdate = db.TBLDoktor.Find(d.DoktorID);
                    if (doktorToUpdate != null)
                    {
                        doktorToUpdate.Poliklinik = d.Poliklinik;
                        doktorToUpdate.TCKNO = d.TCKNO;
                        doktorToUpdate.Ad = d.Ad;
                        doktorToUpdate.Soyad = d.Soyad;
                        doktorToUpdate.DogumTarihi = d.DogumTarihi;
                        doktorToUpdate.TelefonNo = d.TelefonNo;
                        doktorToUpdate.Sifre = d.Sifre;

                        db.SaveChanges();

                    }
                    return RedirectToAction("Doktor");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu: " + ex.Message);
                    return View(d); // Hata durumunda formu tekrar göster
                }
            }
        }

    }
