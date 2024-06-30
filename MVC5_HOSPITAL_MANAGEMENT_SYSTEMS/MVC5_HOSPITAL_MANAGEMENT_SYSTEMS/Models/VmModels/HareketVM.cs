using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models.VmModels
{
    public class HareketVM
    {
        public List<Doktor> doktors { get; set; }
        public List<Admin> admins { get; set; }
        public List<Personel> personels { get; set; }
        public List<Hasta> Hastas { get; set; }
        public List<Kan> kans { get; set; }
        public List<Idrar> ıdrars { get; set; }
        public List<Radyoloji> radyolojis { get; set; }

        public List<Medicine> medicines { get; set; }
        public List<Recete> recetes { get; set; }

        public List<Message> messages { get; set; }
        public List<Yorum> yorums { get; set; }
        // Yeni eklenen özellik
        public int[] MonthlyPatientCount { get; set; }


    }
}