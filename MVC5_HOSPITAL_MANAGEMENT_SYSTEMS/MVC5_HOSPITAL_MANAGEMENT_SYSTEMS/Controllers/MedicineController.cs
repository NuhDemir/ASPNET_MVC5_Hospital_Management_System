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
    public class MedicineController : Controller
    {

        readonly DatabaseContext db = new DatabaseContext();
        // GET: Medicine
        /*------------İLAÇLAR ANASAYFASI-------------------*/
        [Authorize]
        public ActionResult Medicine(string p, int sayfa = 1)
        {
            
                var degerler = from k in db.TBLMedicine select k;
                if (!string.IsNullOrEmpty(p))
                {
                    degerler = degerler.Where(m => m.Ad.Contains(p));
                }
                return View(degerler.ToList().ToPagedList(sayfa, 4));
            }
        

        /*------------İLAÇ EKLEME-------------------*/
        [HttpGet]
        [Authorize]
        public ActionResult MedicineEkle()
        
            {
                return View();
            }
        
        [Authorize]
        [HttpPost]
        public ActionResult MedicineEkle(Medicine med)
        {
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.TBLMedicine.Add(med);
                        db.SaveChanges();
                        return RedirectToAction("Medicine");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Veritabanına kaydetme sırasında bir hata oluştu: " + ex.Message);
                        return View(med); // Hata durumunda formu tekrar göster
                    }
                }
                else
                {
                    // ModelState geçerli değilse, formu tekrar göster
                    return View(med);
                }
            
        }
        /*------------İLAÇ SİLME-------------------*/

        [Authorize]
        public ActionResult MedicineSil(int id)
        {
                var medicine = db.TBLMedicine.Find(id);
                db.TBLMedicine.Remove(medicine);
                db.SaveChanges();
                return RedirectToAction("Medicine");
            }
        

        /*------------İLAÇ GÜNCELLEME-------------------*/
        [Authorize]
        public ActionResult MedicineGetir(int id)
        {
                var medc = db.TBLMedicine.Find(id);
                return View("MedicineGetir", medc);
            }
        
        [Authorize]
        public ActionResult MedicineGuncelle(Medicine med)
        {
                try
                {
                    var medicineToUpdate = db.TBLMedicine.Find(med.MedicineID);
                    if (medicineToUpdate != null)
                    {

                        medicineToUpdate.Ad = med.Ad;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Medicine");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu: " + ex.Message);
                    return View(med); // Hata durumunda formu tekrar göster
                }
            }
        }
    }

