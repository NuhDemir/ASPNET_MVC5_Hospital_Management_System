using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Idrar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdrarID { get; set; }

        // İlişkilendirilmiş hasta ID
        public int HastaID { get; set; }

        // İdrar testi açıklaması
        public string TestAciklama { get; set; }

        // İdrar dansitesi
        [Required(ErrorMessage = "Dansite alanı gereklidir.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Geçerli bir dansite değeri giriniz.")]
        public int Dansite { get; set; }

        // İdrar pH değeri
        [Required(ErrorMessage = "pH alanı gereklidir.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Geçerli bir pH değeri giriniz.")]
        public int PH { get; set; }

        // İdrar eritrosit sayısı
        [Required(ErrorMessage = "Eritrosit alanı gereklidir.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Geçerli bir eritrosit sayısı giriniz.")]
        public int Eritrosit { get; set; }

        // İdrar lökosit sayısı
        [Required(ErrorMessage = "Lökosit alanı gereklidir.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Geçerli bir lökosit sayısı giriniz.")]
        public int Lokosit { get; set; }

        // İdrar epitelyal hücre sayısı
        [Required(ErrorMessage = "Epitel alanı gereklidir.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Geçerli bir epitel sayısı giriniz.")]
        public int Epitel { get; set; }

        // İlişkilendirilmiş hasta bilgisi
        public virtual Hasta Hasta { get; set; }
    }

}
