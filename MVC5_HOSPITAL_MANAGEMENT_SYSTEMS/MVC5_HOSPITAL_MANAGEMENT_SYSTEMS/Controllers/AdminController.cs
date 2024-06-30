using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models;
using MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models.VmModels;
using PagedList;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        readonly DatabaseContext db = new DatabaseContext();

        [HttpPost, ActionName("Anasayfa")]
        [Authorize]
        public ActionResult Anasayfa2()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("AdminGiris", "Login");
            }

        [Authorize]
        public ActionResult Anasayfa()
        {
            var hasta = db.TBLHasta.ToList();
            var admin = db.TBLAdmin.ToList();
            var doktor = db.TBLDoktor.ToList();
            var personel = db.TBLPersonel.ToList();
            var kan = db.TBLKan.ToList();
            var Idrar = db.TBLIdrar.ToList();
            var radyoloji = db.TBLRadyoloji.ToList();
            var medicine = db.TBLMedicine.ToList();
            var recete = db.TBLRecete.ToList();
            var message = db.TBLMessage.ToList();
            HareketVM vm = new HareketVM();
            vm.Hastas = hasta;
            vm.admins = admin;
            vm.doktors = doktor;
            vm.personels = personel;
            vm.kans = kan;
            vm.ıdrars = Idrar;
            vm.radyolojis = radyoloji;
            vm.medicines = medicine;
            vm.recetes = recete;
            vm.messages = message;



            return View(vm);
        }

        [Authorize]
        public ActionResult Map()
        {
          

                return View();
            }
        

        [Authorize]
        public ActionResult Dashboard()
        {
           
                //ArrayList xvalue = new ArrayList();
                //ArrayList yvalue =  new ArrayList();
                //var veriler = db.TBLDoktor.ToList();
                //veriler.ToList().ForEach(x => xvalue.Add(x.DoktorID));
                //veriler.ToList().ForEach(y => yvalue.Add(y.Poliklinik));
                //var grafik = new Chart(width:500,height:500).AddTitle("Doktor Sayısı" ).AddSeries(chartType:"Column",name:"Doktor",xValue:xvalue,yValues:yvalue);
                //return File(grafik.ToWebImage().GetBytes(),"image/jpeg");

                var hasta = db.TBLHasta.ToList();
                var admin = db.TBLAdmin.ToList();
                var doktor = db.TBLDoktor.ToList();
                var personel = db.TBLPersonel.ToList();
                var kan = db.TBLKan.ToList();
                var Idrar = db.TBLIdrar.ToList();
                var radyoloji = db.TBLRadyoloji.ToList();
                var medicine = db.TBLMedicine.ToList();
                var recete = db.TBLRecete.ToList();
                var message = db.TBLMessage.ToList();
                var yorum = db.TBLYorum.ToList();

                // Aylık hasta sayısını hesaplayalım (örnek veri)
                var monthlyPatientCount = new int[] { 5, 10, 15, 20, 25, 30 };

                HareketVM vm = new HareketVM();
                vm.Hastas = hasta;
                vm.admins = admin;
                vm.doktors = doktor;
                vm.personels = personel;
                vm.kans = kan;
                vm.ıdrars = Idrar;
                vm.radyolojis = radyoloji;
                vm.medicines = medicine;
                vm.recetes = recete;
                vm.messages = message;
                vm.yorums = yorum;
                vm.MonthlyPatientCount = monthlyPatientCount; // Yeni eklenen özellik

                return View(vm);
            }
        

        [Authorize]
        public ActionResult Yapilacaklar()
        {
            
                return View();
            
        }

        [Authorize]
        public ActionResult AdminLayout(Admin a)
        {
                HareketVM vm = new HareketVM();
                vm.admins = db.TBLAdmin.ToList();

                // Admin adı ile arama yapmak için FirstOrDefault kullanıyorum
                var deger1 = db.TBLAdmin.FirstOrDefault(admin => admin.Ad == a.Ad);

                if (deger1 != null)
                {
                    ViewBag.dgr1 = deger1.Ad;
                }
                else
                {
                    ViewBag.dgr1 = "Admin bulunamadı";
                }

                return View(vm);
            }
        

        //GoogleCharts Grafikleri
        //public ActionResult GrafikOlustur()
        //{
        //    return Json(Doktorlar(),JsonRequestBehavior.AllowGet);
        //}
        //public List<Doktor> Doktorlar()
        //{
        //    List<Doktor> dk = new List<Doktor>();
        //    dk=db.TBLDoktor.Select(x=>new Doktor
        //        {
        //        Poliklinik =x.Poliklinik,
        //        DoktorID =x.DoktorID,

        //    }).ToList();
        //    return dk;
        //}

        /*------------YORUM ANASAYFASI-------------------*/
        [Authorize]
        public ActionResult Yorum(string p, int sayfa = 1)
        {
            
                var degerler = from k in db.TBLYorum select k;
                if (!string.IsNullOrEmpty(p))
                {
                    degerler = degerler.Where(m => m.Ad.Contains(p));
                }
                return View(degerler.ToList().ToPagedList(sayfa, 3));
            
        }
        /*------------YORUM EKLEME-------------------*/
        [HttpGet]
        [Authorize]
        public ActionResult YorumEkle()
        {
            
                return View();
            }
        
        [Authorize]
        [HttpPost]
        public ActionResult YorumEkle(Yorum y)
        {
          
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (!ModelState.IsValid && Request.Files.Count > 0)
                        {
                            return View("YorumEkle");
                        }
                        //string fileName = Path.GetFileName(Request.Files[0].FileName);
                        //string uzantı = Path.GetExtension(Request.Files[0].FileName);
                        //string yol = "~/Image/" + fileName + uzantı;
                        //Request.Files[0].SaveAs(Server.MapPath(yol));
                        //d.DoktorFoto = "/Image/" + fileName + uzantı;
                        db.TBLYorum.Add(y);
                        db.SaveChanges();

                        return RedirectToAction("Yorum");


                        //return RedirectToAction("Doktor");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Veritabanına kaydetme sırasında bir hata oluştu: " + ex.Message);
                        return View(y); // Hata durumunda formu tekrar göster
                    }
                }
                else
                {
                    // ModelState geçerli değilse, formu tekrar göster
                    return View(y);
                }
            }
        

        /*------------YORUM SİLME-------------------*/
        [Authorize]
        public ActionResult YorumSil(int id)
        {
           
                var yorum = db.TBLYorum.Find(id);
                db.TBLYorum.Remove(yorum);
                db.SaveChanges();
                return RedirectToAction("Yorum");
            
        }

        /*------------YORUM GÜNCELLEME-------------------*/
        [Authorize]
        public ActionResult YorumGetir(int id)
        {
                var yor = db.TBLYorum.Find(id);
                return View("YorumGetir", yor);
            }
        
        [Authorize]
        public ActionResult YorumGuncelle(Yorum y)
        {
           
                try
                {
                    var yorumToUpdate = db.TBLYorum.Find(y.YorumID);
                    if (yorumToUpdate != null)
                    {
                        yorumToUpdate.Ad = y.Ad;
                        yorumToUpdate.Soyad = y.Soyad;
                        yorumToUpdate.Meslek = y.Meslek;
                        yorumToUpdate.Mesaj = y.Mesaj;


                        db.SaveChanges();

                    }
                    return RedirectToAction("Yorum");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu: " + ex.Message);
                    return View(y); // Hata durumunda formu tekrar göster
                }
            
        }
        [Authorize]
        public ActionResult Iletisim(string p, int sayfa = 1)
        {
           
                var degerler = from k in db.TBLMessage select k;
                if (!string.IsNullOrEmpty(p))
                {
                    degerler = degerler.Where(m => m.Ad.Contains(p));
                }
                return View(degerler.ToList().ToPagedList(sayfa, 3));
            }
        [Authorize]
        public ActionResult IletisimSil(int id)
        {

            var message = db.TBLMessage.Find(id);
            db.TBLMessage.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Iletisim");


        }
        [Authorize]
        public ActionResult AdminProfile()
        {
            return View();

        }
    }
}