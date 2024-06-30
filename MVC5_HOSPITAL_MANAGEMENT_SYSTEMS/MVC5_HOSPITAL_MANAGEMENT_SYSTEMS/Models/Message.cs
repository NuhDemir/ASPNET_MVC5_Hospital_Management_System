using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models
{
    public class Message
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageID { get; set; }

        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "Ad alanı en fazla 50 karakter olmalıdır.")]
        public string Ad { get; set; }

        

        [Required(ErrorMessage = "E-posta alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Konu alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "Konu alanı en fazla 1000 karakter olmalıdır.")]
        public string Konu { get; set; }

        [Required(ErrorMessage = "Mesaj alanı gereklidir.")]
        [StringLength(1000, ErrorMessage = "Mesaj alanı en fazla 1000 karakter olmalıdır.")]
        public string Mesaj { get; set; }
    }
}