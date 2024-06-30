using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models
{
    public class Kan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KanID { get; set; }

        // İlişkilendirilmiş hasta ID
        public int HastaID { get; set; }

       

        // Demir değeri (ug/dL)
        [Required(ErrorMessage = "Demir değeri gereklidir.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Geçerli bir demir değeri giriniz.")]
        public int Demir { get; set; }

        // CRP (C-reaktif protein) değeri (mg/L)
        [Required(ErrorMessage = "CRP değeri gereklidir.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Geçerli bir CRP değeri giriniz.")]
        public int CRP { get; set; }

        // Granülosit değeri (k/µL)
        [Required(ErrorMessage = "Granülosit değeri gereklidir.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Geçerli bir granülosit değeri giriniz.")]
        public int Granulosit { get; set; }

        // Lenfosit değeri (k/µL)
        [Required(ErrorMessage = "Lenfosit değeri gereklidir.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Geçerli bir lenfosit değeri giriniz.")]
        public int Lenfosit { get; set; }

        // Eritrosit değeri (milyon/µL)
        [Required(ErrorMessage = "Eritrosit değeri gereklidir.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Geçerli bir eritrosit değeri giriniz.")]
        public int Eritrosit { get; set; }

        // Hemoglobin değeri (g/dL)
        [Required(ErrorMessage = "Hemoglobin değeri gereklidir.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Geçerli bir hemoglobin değeri giriniz.")]
        public int Hemoglobin { get; set; }

        // Hemotokrit değeri (%)
        [Required(ErrorMessage = "Hemotokrit değeri gereklidir.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Geçerli bir hemotokrit değeri giriniz.")]
        public int Hemotokrit { get; set; }

        // Trombosit değeri (bin/µL)
        [Required(ErrorMessage = "Trombosit değeri gereklidir.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Geçerli bir trombosit değeri giriniz.")]
        public int Trombosit { get; set; }

        // İlişkilendirilmiş hasta bilgisi
        public virtual Hasta Hasta { get; set; }
    }
}