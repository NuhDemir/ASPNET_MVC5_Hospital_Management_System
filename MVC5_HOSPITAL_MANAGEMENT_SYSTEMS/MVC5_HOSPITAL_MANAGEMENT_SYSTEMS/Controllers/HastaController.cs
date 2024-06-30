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
    public class HastaController : Controller
    {
        readonly DatabaseContext db = new DatabaseContext();

        /*------------HASTA ANASAYFASI-------------------*/
        [Authorize]
        public ActionResult Hasta(string p, int sayfa = 1)
        {
            
                var degerler = from k in db.TBLHasta select k;
                if (!string.IsNullOrEmpty(p))
                {
                    degerler = degerler.Where(m => m.Ad.Contains(p));
                }
                return View(degerler.ToList().ToPagedList(sayfa, 3));
            
        }

        /*------------PERSONEL EKLEME-------------------*/
        [HttpGet]
        [Authorize]
        public ActionResult HastaEkle()
        {
                return View();
            }
        

        [HttpPost]
        [Authorize]
        public ActionResult HastaEkle(Hasta h)
        {
           
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.TBLHasta.Add(h);
                        db.SaveChanges();
                        return RedirectToAction("Hasta");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Veritabanına kaydetme sırasında bir hata oluştu: " + ex.Message);
                        return View(h); // Hata durumunda formu tekrar göster
                    }
                }
                else
                {
                    // ModelState geçerli değilse, formu tekrar göster
                    return View(h);
                }
            }
        

        /*------------HASTA SİLME-------------------*/
        [Authorize]
        public ActionResult HastaSil(int id)
        {
                var hasta = db.TBLHasta.Find(id);
                db.TBLHasta.Remove(hasta);
                db.SaveChanges();
                return RedirectToAction("Hasta");

            }


        /*------------HASTA GÜNCELLEME-------------------*/
        [Authorize]
        public ActionResult HastaGetir(int id)
        {
           
                var hast = db.TBLHasta.Find(id);
                return View("HastaGetir", hast);
            }
        
        [Authorize]
        public ActionResult HastaGuncelle(Hasta h)
        {
                try
                {
                    var hastaToUpdate = db.TBLHasta.Find(h.HastaID);
                    if (hastaToUpdate != null)
                    {

                        hastaToUpdate.TCKNO = h.TCKNO;
                        hastaToUpdate.Ad = h.Ad;
                        hastaToUpdate.Soyad = h.Soyad;
                        hastaToUpdate.Yas = h.Yas;
                        hastaToUpdate.TelefonNo = h.TelefonNo;
                        hastaToUpdate.Sifre = h.Sifre;

                        db.SaveChanges();
                    }
                    return RedirectToAction("Hasta");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu: " + ex.Message);
                    return View(h); // Hata durumunda formu tekrar göster
                }
            }

        }
    }
