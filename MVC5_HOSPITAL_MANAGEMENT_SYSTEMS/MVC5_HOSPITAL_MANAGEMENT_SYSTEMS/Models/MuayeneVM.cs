using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models
{
    public class MuayeneVM
    {
     
            public Hasta hasta { get; set; }
            public Kan kanSonucları { get; set; }
            public Radyoloji RadyalojiSonucları { get; set; }
            public Idrar IdrarSonucları { get; set; }
        }
    }

