using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models
{
    public class Medicine
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicineID { get; set; }

        [Required(ErrorMessage = "İlaç adı alanı gereklidir.")]
        [StringLength(100, ErrorMessage = "İlaç adı en fazla 100 karakter olmalıdır.")]
        public string Ad { get; set; }

        [StringLength(50, ErrorMessage = "İlaç kodu en fazla 50 karakter olmalıdır.")]
        public string Kod { get; set; }

        [StringLength(50, ErrorMessage = "İlaç grubu en fazla 50 karakter olmalıdır.")]
        public string Grup { get; set; }
    }
}