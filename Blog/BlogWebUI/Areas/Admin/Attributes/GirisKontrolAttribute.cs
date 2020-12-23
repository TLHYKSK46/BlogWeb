using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Areas.Admin.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class GirisKontrolAttribute : Attribute
    {
        private bool durum;
        private List<GirisBilgisi> _girisBiligisi=new List<GirisBilgisi>();

        public GirisKontrolAttribute()
        {
            
    
        }
        public override bool IsDefaultAttribute()
        {
            
            return base.IsDefaultAttribute();
        }



        //public override void OnActionExecuting(ActionExecutingContext context)
        //{

        //    if (HttpContext.Current.Session["Giris"].ToString() == "0")
        //    {
        //        context.HttpContext.Response.Redirect("/Giris/Kontrol");
        //    }
        //    base.OnActionExecuting(context);
        //}



        public bool kontrol()
        {
            foreach (var item in _girisBiligisi)
            {
                if (item.Id == null || item.Adsoyad == null || item.Email == null || item.FotoUrl == null || item.RolId == null)
                {
                    durum = false;
                }
                else
                {
                    durum = true;
                }
            }
         
            return durum;
        }




    }
}
