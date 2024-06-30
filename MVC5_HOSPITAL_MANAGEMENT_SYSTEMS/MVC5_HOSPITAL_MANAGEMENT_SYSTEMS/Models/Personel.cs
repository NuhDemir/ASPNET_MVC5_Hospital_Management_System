using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models
{
    public class Personel
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonelID { get; set; }
        [Required(ErrorMessage = "TC Kimlik Numarası alanı gereklidir.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC Kimlik Numarası 11 karakter olmalıdır.")]
        public string TCKNO { get; set; }

        [Required(ErrorMessage = "Uzmanlık alanı gereklidir.")]
        [StringLength(100, ErrorMessage = "Uzmanlık alanı en fazla 100 karakter olmalıdır.")]
        public string Departman { get; set; }

        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "Ad alanı en fazla 50 karakter olmalıdır.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "Soyad alanı en fazla 50 karakter olmalıdır.")]
        public string Soyad { get; set; }


        [Required(ErrorMessage = "Doğum tarihi alanı gereklidir.")]
        [DataType(DataType.Date)]
        public DateTime DogumTarihi { get; set; }


        [StringLength(20, ErrorMessage = "Telefon numarası en fazla 20 karakter olmalıdır.")]
        public string TelefonNo { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Şifre en az 6, en fazla 20 karakter olmalıdır.")]
        public string Sifre { get; set; }

    }
}