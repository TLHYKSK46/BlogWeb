using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBusiness.Abstract;
using BlogWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Controllers
{
    public class ReferansController : Controller
    {

      
            IReferansServis _referansServis;

            public ReferansController(IReferansServis referansServis)
            {
                _referansServis = referansServis;
            }

            public IActionResult Index()
            {
                var referanslar = _referansServis.ReferanslariGetir();

                ReferansViewModel model = new ReferansViewModel
                {
                    Referans = referanslar,

                };

                return View(model);
            
            }
    }
}
