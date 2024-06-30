using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models
{
    public class Yorum
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YorumID { get; set; }

        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "Ad alanı en fazla 50 karakter olmalıdır.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "Soyad alanı en fazla 50 karakter olmalıdır.")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Meslek alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "Soyad alanı en fazla 50 karakter olmalıdır.")]
        public string Meslek { get; set; }

        [Required(ErrorMessage = "Mesaj alanı gereklidir.")]
        [StringLength(1000, ErrorMessage = "Mesaj alanı en fazla 1000 karakter olmalıdır.")]
        public string Mesaj { get; set; }
    }
}