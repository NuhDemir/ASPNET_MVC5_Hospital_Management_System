using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models
{
    public class Recete
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReceteID { get; set; }

        // Reçete numarası
        [Required(ErrorMessage = "Reçete numarası alanı gereklidir.")]
        [StringLength(20, ErrorMessage = "Reçete numarası en fazla 20 karakter olmalıdır.")]
        public string ReceteNo { get; set; }

        // Reçetenin veriliş tarihi
        public DateTime Verilis { get; set; }

        // İlaçlar
        [StringLength(50, ErrorMessage = "İlaç adı en fazla 50 karakter olmalıdır.")]
        public string Ilac { get; set; }

        [StringLength(50, ErrorMessage = "İlaç adı en fazla 50 karakter olmalıdır.")]
        public string Ilac2 { get; set; }

        [StringLength(50, ErrorMessage = "İlaç adı en fazla 50 karakter olmalıdır.")]
        public string Ilac3 { get; set; }

        [StringLength(50, ErrorMessage = "İlaç adı en fazla 50 karakter olmalıdır.")]
        public string Ilac4 { get; set; }

        [StringLength(50, ErrorMessage = "İlaç adı en fazla 50 karakter olmalıdır.")]
        public string Ilac5 { get; set; }

        [StringLength(50, ErrorMessage = "İlaç adı en fazla 50 karakter olmalıdır.")]
        public string Ilac6 { get; set; }

        // İlişkilendirilmiş hasta ID
        public int HastaID { get; set; }

        // İlişkilendirilmiş hasta bilgisi
        public virtual Hasta Hasta { get; set; }
    }
}