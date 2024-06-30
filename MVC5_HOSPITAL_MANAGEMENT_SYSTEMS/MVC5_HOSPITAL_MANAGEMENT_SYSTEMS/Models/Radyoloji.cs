using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models
{
    public class Radyoloji
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RadyolojiID { get; set; }

        [Required(ErrorMessage = "Test açıklama alanı boş bırakılamaz.")]
        [StringLength(200, ErrorMessage = "Test açıklama alanı en fazla 100 karakter olabilir.")]
        public string TestAciklama { get; set; }

        [Required(ErrorMessage = "Sonuç alanı boş bırakılamaz.")]
        public string Sonuc { get; set; }

        [Required(ErrorMessage = "Hasta ID alanı boş bırakılamaz.")]
        public int HastaID { get; set; }

        // İlişkili Hasta nesnesi
        public virtual Hasta Hasta { get; set; }
    }
}