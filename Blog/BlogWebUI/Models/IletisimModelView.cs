using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Models
{
    public class IletisimModelView
    {
        [Required(ErrorMessage = "*Lütfen ad soyad giriniz...")]
        public string AdSoyad { get; set; }
        [Required(ErrorMessage = "*Lütfen bir email giriniz")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                           ErrorMessage = "Email adresi geçersiz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*Lütfen bir konu giriniz")]
        public string Konu { get; set; }
        [Required(ErrorMessage = "*Lütfen bir mesaj giriniz")]
        public string Mesaj { get; set; }

    }
}
