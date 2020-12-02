using BlogWebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Areas.Admin.ViewComponents
{
    public class SolMenuViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            int RolId = (int)HttpContext.Session.GetInt32("rolid");


            SolMenuViewCompenentModel model = new SolMenuViewCompenentModel
            {

                RolId = RolId

            };
            return View(model);

        }
    }
}
