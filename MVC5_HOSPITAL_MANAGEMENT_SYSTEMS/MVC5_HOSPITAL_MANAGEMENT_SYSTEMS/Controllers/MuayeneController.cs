using MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Controllers
{
    public class MuayeneController : Controller
    {

        DatabaseContext db = new DatabaseContext();

        [HttpGet]
        [Authorize]
        public ActionResult Islem()
        {
           
                ViewBag.giris = "Giriş Başarılı";



                ViewBag.tarih = DateTime.Now.Day.ToString();


                List<Hasta> hastalar = db.TBLHasta.ToList();




                db.SaveChanges();


                //foreach (var item in hastalar)
                //{
                //    item.ReceteNo = recete.ReceteNo;
                //}
                return View(hastalar);
            }



        
        [HttpPost, ActionName("Islem")]
        [Authorize]
        public ActionResult Islem2()
        {
                Session.Remove("LogKisi");
                return RedirectToAction("DoktorGiris", "Login");
            }
        


        [Authorize]
        public ActionResult Sonuc(int? id)
        {
                var hastagetir = db.TBLHasta.FirstOrDefault(x => x.HastaID == id);
                var kansonuc = db.TBLKan.FirstOrDefault(x => x.HastaID == id);
                var idrarsonuc = db.TBLIdrar.FirstOrDefault(x => x.HastaID == id);
                var radyalojisonuc = db.TBLRadyoloji.FirstOrDefault(x => x.HastaID == id);


                MuayeneVM vm = new MuayeneVM()
                {
                    kanSonucları = kansonuc,
                    IdrarSonucları = idrarsonuc,
                    RadyalojiSonucları = radyalojisonuc,
                    hasta = hastagetir
                };



                return View(vm);

            }

        [Authorize]
        public ActionResult Recete(int? id)
        {
                var hastagetir = db.TBLHasta.FirstOrDefault(x => x.HastaID == id);

                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                char[] code = new char[6];

                for (int i = 0; i < 6; i++)
                {
                    code[i] = chars[random.Next(chars.Length)];
                }

                string generatedCode = new string(code);



                ReceteVM vm = new ReceteVM();
                vm.Hasta = hastagetir;
                vm.Recete = new Recete();

                vm.Recete.ReceteNo = generatedCode;

                return View(vm);
            }
        

        [HttpPost]
        [Authorize]
        public ActionResult Recete(ReceteVM _ilac, Hasta hasta)
        {
                _ilac.Recete.HastaID = hasta.HastaID;
                db.TBLRecete.Add(_ilac.Recete);
                int sonuc = db.SaveChanges();
                return RedirectToAction("Islem", "Muayene");
            }

        [Authorize]
        public ActionResult ReceteNo(Hasta hasta)
        {
            var Recete = db.TBLRecete.FirstOrDefault(x => x.HastaID == hasta.HastaID);
            Recete rc = new Recete();
            rc.ReceteNo = Recete.ReceteNo;


            return View(rc);
        }

        [Authorize]
        public ActionResult ReceteYazdır(int? id)
        {
            try
            {
                // Burada nesne oluşturma veya işlemler gerçekleştir
                // Eğer hata alırsanız, catch bloğuna gidecek
                var recete = db.TBLRecete.FirstOrDefault(x => x.HastaID == id);
                if (recete == null)
                {
                    // Hata durumunda başka bir sayfaya yönlendir
                    return RedirectToAction("ReceteYazilmadi");
                }

                return View(recete);
            }
            catch (Exception ex)
            {
                // Hata durumunda başka bir sayfaya yönlendir
                return RedirectToAction("ReceteYazilmadi");
            }
        }

        [Authorize]
        public ActionResult ReceteYazilmadi()
        {
            return View();
        }


    }
}