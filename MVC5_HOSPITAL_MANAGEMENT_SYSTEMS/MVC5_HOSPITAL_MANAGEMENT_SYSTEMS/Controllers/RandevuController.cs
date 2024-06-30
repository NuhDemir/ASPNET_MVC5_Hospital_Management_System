using MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Controllers
{
    public class RandevuController : Controller
    {
        // RandevuAnasayfa action metodu
        public ActionResult RandevuIslemleri()
        {
            return View();
        }

        // RandevuVer action metodu
        [HttpGet]
        public ActionResult RandevuVer(string poliklinik = null)
        {
            ViewBag.poliklinikler = new SelectList(Getpoliklinikler());

            IEnumerable<string> doktorlar;
            if (!string.IsNullOrEmpty(poliklinik))
            {
                doktorlar = GetDoktorlarBypoliklinik(poliklinik);
            }
            else
            {
                doktorlar = new List<string>();
            }

            ViewBag.Doktorlar = new SelectList(doktorlar);
            return View(new Hasta { Poliklinik = poliklinik });
        }

        private IEnumerable<string> GetDoktorlarBypoliklinik(string poliklinik)
        {
            Dictionary<string, List<string>> doktorListesi = new Dictionary<string, List<string>>();
            using (var dbContext = new DatabaseContext())
            {
                List<Doktor> Doktorlar = dbContext.TBLDoktor.ToList();

                foreach (var doktor in Doktorlar)
                {
                    if (doktorListesi.ContainsKey(doktor.Poliklinik))
                    {
                        doktorListesi[doktor.Poliklinik].Add(doktor.Ad + " " + doktor.Soyad);
                    }
                    else
                    {
                        doktorListesi.Add(doktor.Poliklinik, new List<string> { doktor.Ad + " " + doktor.Soyad });
                    }
                }
            }


            return doktorListesi.TryGetValue(poliklinik, out var doktorlar) ? doktorlar : Enumerable.Empty<string>();
        }

        public List<string> Getpoliklinikler()
        {
            List<string> poliklinikler = new List<string>();
            using (var dbContext = new DatabaseContext())
            {
                poliklinikler = dbContext.TBLDoktor.Select(d => d.Poliklinik).Distinct().ToList();

            }
            return poliklinikler;
        }

        [HttpPost]
        public ActionResult RandevuVer(Hasta hasta)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new DatabaseContext())
                {

                    dbContext.TBLHasta.Add(hasta);

                    dbContext.SaveChanges();
                }
                return RedirectToAction("RandevuOnay", new { id = hasta.HastaID });
            }

            ViewBag.poliklinikler = new SelectList(Getpoliklinikler());


            var doktorlar = GetDoktorlarBypoliklinik(hasta.Poliklinik);
            ViewBag.Doktorlar = new SelectList(doktorlar);
            return View(hasta);
        }

        [HttpGet]
        public ActionResult RandevuOnay(int id, string message = "Randevunuz başarıyla alındı.")
        {
            using (var dbContext = new DatabaseContext())
            {
                var randevu = dbContext.TBLHasta.FirstOrDefault(r => r.HastaID == id);
                if (randevu == null)
                {
                    return HttpNotFound("Randevu bulunamadı.");
                }
                ViewBag.Message = message;  // Mesajı View'a aktar
                return View(randevu);
            }
        }


        [HttpGet]
        public ActionResult RandevuGoster(string tcKimlik = null)
        {
            using (var dbContext = new DatabaseContext())
            {
                List<Hasta> randevular = new List<Hasta>();  // Boş bir liste oluştur

                if (!string.IsNullOrWhiteSpace(tcKimlik) && tcKimlik.Length == 11)
                {
                    randevular = dbContext.TBLHasta.Where(r => r.TCKNO == tcKimlik).ToList();
                }

                return View(randevular);
            }
        }
        [HttpPost]
        public ActionResult RandevuSil(int id)
        {
            using (var dbContext = new DatabaseContext())
            {
                var randevu = dbContext.TBLHasta.FirstOrDefault(r => r.HastaID == id);
                if (randevu != null)
                {
                    dbContext.TBLHasta.Remove(randevu);
                    dbContext.SaveChanges();  // Değişiklikleri veritabanına kaydet
                    return RedirectToAction("RandevuGoster", new { message = "Randevu başarıyla silindi." });  // Başarılı silme işleminden sonra kullanıcıyı bilgilendir
                }
                else
                {
                    return HttpNotFound("Randevu bulunamadı.");  // Randevu bulunamazsa kullanıcıya hata mesajı göster
                }
            }
        }

        [HttpGet]
        public ActionResult RandevuDuzenle(int id)
        {
            using (var dbContext = new DatabaseContext())
            {
                var randevu = dbContext.TBLHasta.FirstOrDefault(r => r.HastaID == id);
                if (randevu == null)
                    return HttpNotFound();

                return View(randevu);
            }
        }

        [HttpPost]
        public ActionResult RandevuDuzenle(int id, Hasta model)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new DatabaseContext())
                {
                    var existingRandevu = dbContext.TBLHasta.FirstOrDefault(r => r.HastaID == id);
                    if (existingRandevu != null)
                    {
                        // Modelden alınan verilerle var olan kaydı güncelle
                        existingRandevu.AlısTarih = model.AlısTarih;
                        existingRandevu.TelefonNo = model.TelefonNo;

                        // Değişiklikleri kaydet
                        dbContext.Entry(existingRandevu).State = System.Data.Entity.EntityState.Modified; // Entity Framework için durumu güncelle
                        dbContext.SaveChanges();

                        return RedirectToAction("RandevuOnay", new { id, message = "Randevunuz başarıyla güncellendi." });
                    }
                    else
                    {
                        return HttpNotFound("Randevu bulunamadı.");
                    }
                }
            }
            // ModelState geçersizse, hata mesajlarıyla formu tekrar göster
            return View(model);
        }
    }
}