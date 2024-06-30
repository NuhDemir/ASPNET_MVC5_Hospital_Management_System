using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models
{
    public class Hasta
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HastaID { get; set; }

        [Required(ErrorMessage = "TC Kimlik Numarası alanı gereklidir.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC Kimlik Numarası 11 karakter olmalıdır.")]
        public string TCKNO { get; set; }

        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "Ad alanı en fazla 50 karakter olmalıdır.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "Soyad alanı en fazla 50 karakter olmalıdır.")]
        public string Soyad { get; set; }



        [StringLength(20, ErrorMessage = "Telefon numarası en fazla 20 karakter olmalıdır.")]
        public string TelefonNo { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Şifre en az 6, en fazla 20 karakter olmalıdır.")]


        public string Poliklinik { get; set; }

        [Required(ErrorMessage = "Randevu alış tarihi alanı gereklidir.")]
        [DataType(DataType.Date)]
        public DateTime AlısTarih { get; set; }


        [Required(ErrorMessage = "Seçmek istediğiniz doktor alanı gereklidir.")]
        public string Doktor { get; set; }


        [Required(ErrorMessage = "Mesaj alanı gereklidir.")]
        [StringLength(1000, ErrorMessage = "Mesaj alanı en fazla 1000 karakter olmalıdır.")]
        public string Mesaj { get; set; }

        public string Sifre { get; set; }
        public string ReceteNo { get; set; }
        public string Yas {  get; set; }


    }
}