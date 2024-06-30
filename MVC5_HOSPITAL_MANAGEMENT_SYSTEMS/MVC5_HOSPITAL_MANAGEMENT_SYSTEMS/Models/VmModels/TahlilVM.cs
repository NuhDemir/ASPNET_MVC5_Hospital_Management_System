using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models.VmModels
{
    public class TahlilVM
    {
        public Kan KanSonuc { get; set; }
        public Idrar IdrarSonuc { get; set; }
        public Radyoloji RadyolojiSonuc { get; set; }
        public Hasta MyProperty { get; set; }
    }
}