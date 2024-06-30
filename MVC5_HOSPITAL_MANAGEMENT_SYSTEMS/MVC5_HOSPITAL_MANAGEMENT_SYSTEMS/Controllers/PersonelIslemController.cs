using MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Controllers
{
    public class PersonelIslemController : Controller
    {
        DatabaseContext db = new DatabaseContext();


        [Authorize]
        public ActionResult Islem()
        {

            List<Hasta> hastalar = null;
            hastalar = db.TBLHasta.ToList();
            return View(hastalar);
        }

        [Authorize]
        [HttpGet]
        public ActionResult KanSonucuEkle(int? id)
        {
            var hastagetir = db.TBLHasta.FirstOrDefault(x => x.HastaID == id);

            KanSonucVM vm = new KanSonucVM();
            vm.Hasta = hastagetir;
            vm.KanSonuc = new Kan();

            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult KanSonucuEkle(KanSonucVM _kanSonuc)
        {
            if (_kanSonuc.KanSonuc.Demir != 0 && _kanSonuc.KanSonuc.CRP != 0 && _kanSonuc.KanSonuc.Eritrosit != 0 && _kanSonuc.KanSonuc.Granulosit != 0 && _kanSonuc.KanSonuc.Hemoglobin != 0)
            {
                _kanSonuc.KanSonuc.HastaID = _kanSonuc.Hasta.HastaID; // HastaId'i doğrudan _kanSonuc üzerinden al
                db.TBLKan.Add(_kanSonuc.KanSonuc);
                db.SaveChanges();
                return RedirectToAction("Islem", "PersonelIslem");

            }
            return RedirectToAction("Hatali", "PersonelIslem");

        }

        //[HttpGet]
        //public ActionResult KanSonucuGuncelle(int id)
        //{

        //    var kanSonuc = db.KanSonucları.FirstOrDefault(x => x.HastaId == id);

        //    return View(kanSonuc);
        //}

        //[HttpPost]
        //public ActionResult KanSonucuGuncelle(int? _id ,KanSonuc _kanSonuc)
        //{
        //    Hasta hasta = db.Hastalar.Where(x => x.HastaId ==  _kanSonuc.HastaId).FirstOrDefault();
        //    KanSonuc kansonuc = db.KanSonucları.FirstOrDefault(x => x.KanSonucId == _kanSonuc.KanSonucId);
        //    if (hasta != null)
        //    {

        //        kansonuc.Demir = _kanSonuc.Demir;
        //        db.SaveChanges();
        //        return RedirectToAction("Islem", "Personel");
        //    }
        //    else
        //    {
        //        return View();
        //    }


        //}

        [Authorize]
        [HttpGet]
        public ActionResult IdrarSonucuEkle(int? id)
        {
            var hastagetir = db.TBLHasta.FirstOrDefault(x => x.HastaID == id);

            IdrarVM vm = new IdrarVM();
            vm.Hasta = hastagetir;
            vm.IdrarSonuc = new Idrar();

            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult IdrarSonucuEkle(IdrarVM _idrarSonuc)
        {
            if (_idrarSonuc.IdrarSonuc.PH != 0 && _idrarSonuc.IdrarSonuc.Dansite != 0 && _idrarSonuc.IdrarSonuc.Epitel != 0 && _idrarSonuc.IdrarSonuc.Eritrosit != 0)
            {
                _idrarSonuc.IdrarSonuc.HastaID = _idrarSonuc.Hasta.HastaID; // HastaId'i doğrudan _kanSonuc üzerinden al
                db.TBLIdrar.Add(_idrarSonuc.IdrarSonuc);
                db.SaveChanges();

                return RedirectToAction("Islem", "PersonelIslem");
            }

            return RedirectToAction("Hatali", "PersonelIslem");



        }
        [Authorize]
        [HttpGet]
        public ActionResult RadyolojiSonucuEkle(int? id)
        {
            var hastagetir = db.TBLHasta.FirstOrDefault(x => x.HastaID == id);

            RadyolojiVM vm = new RadyolojiVM();
            vm.Hasta = hastagetir;
            vm.RadyolojiSonuc = new Radyoloji();

            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult RadyolojiSonucuEkle(RadyolojiVM _radyoloji)
        {
            if (_radyoloji.RadyolojiSonuc.TestAciklama != null && _radyoloji.RadyolojiSonuc.Sonuc != null)
            {
                _radyoloji.RadyolojiSonuc.HastaID = _radyoloji.Hasta.HastaID; // HastaId'i doğrudan _kanSonuc üzerinden al
                db.TBLRadyoloji.Add(_radyoloji.RadyolojiSonuc);
                db.SaveChanges();

                return RedirectToAction("Islem", "PersonelIslem");
            }


            return RedirectToAction("Hatali", "PersonelIslem");
        }
        [Authorize]
        public ActionResult Hatali()
        {

            return View();
        }

        [Authorize]
        public ActionResult HataliEkle()
        {

            return View();
        }




    }
}
