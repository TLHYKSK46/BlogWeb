using BlogEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Models
{
    public class HakkimdaModel
    {
        public List<Hakkimda> Hakkimda { get; internal set; }
        public List<Kullanici> Kullanici { get; internal set; }
        public List<Kullanici> SuperAdmin { get; internal set; }
        public List<string> Deneyimler { get; internal set; }
        public List<string> Beceriler { get; internal set; }
        public List<string> Oduller { get; internal set; }
        public List<string> Egitimler { get; internal set; }
        public List<string> Hobiler { get; internal set; }
    }
}
