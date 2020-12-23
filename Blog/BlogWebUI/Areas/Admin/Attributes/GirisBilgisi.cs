using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Areas.Admin.Attributes
{
    public class GirisBilgisi
    {
        int id,rolid;
        string adsoyad, email, fotourl;
        public int Id { get { return id; } set => id = value; }
        public string Adsoyad { get { return adsoyad; } set => adsoyad = value; }
        public string Email { get { return Email; } set => Email = value; }
        public string FotoUrl { get { return FotoUrl; } set => FotoUrl = value; }

        public int RolId { get { return RolId; } set => RolId = value; }

        //public int id { get; set; }
        //public string adsoyad { get; set; }
        //public string email { get; set; }
        //public string fotourl { get; set; }
        //public int rolid { get; set; }

        string ad;
        string soyad;




    }
}
