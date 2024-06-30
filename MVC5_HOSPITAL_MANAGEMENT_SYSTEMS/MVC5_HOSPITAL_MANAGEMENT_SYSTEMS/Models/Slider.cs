using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS.Models
{
    [Table("Slider")]
    public class Slider
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SliderID { get; set; }

        [DisplayName("Slider Başlık"),StringLength(30,ErrorMessage ="30 karakter olmalıdır.")]
        public string Baslik { get; set; }

        [DisplayName("Slider Açıklama"), StringLength(150, ErrorMessage = "150 karakter olmalıdır.")]
        public string Aciklama { get; set; }

        [DisplayName("Slider ResimURL"), StringLength(250, ErrorMessage = "30 karakter olmalıdır.")]
        public string ResimURL { get; set; }
    }
}