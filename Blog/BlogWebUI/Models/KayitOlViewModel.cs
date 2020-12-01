using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Models
{
    public class KayitOlViewModel
    {
        [Required]
        public string AdSoyad { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Parola { get; set; }
        //[Required]
        // [DataType(DataType.Password)]
        //public string YParola { get; set; }
        public int RolId { get; set; }
        public string FotoUrl { get; set; }
    }
}
