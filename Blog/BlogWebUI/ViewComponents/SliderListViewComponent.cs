using BlogBusiness.Abstract;
using BlogWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.ViewComponents
{
    public class SliderListViewComponent : ViewComponent
    {
        IMakaleServis _makaleServis;

        public SliderListViewComponent(IMakaleServis makaleServis)
        {
            _makaleServis = makaleServis;
        }
        public ViewViewComponentResult Invoke()
        {
            var model = new SliderListViewModel
            {

                Makaleler = _makaleServis.MakaleleriGetir(),

            };

            return View(model);
        }

    }
}
