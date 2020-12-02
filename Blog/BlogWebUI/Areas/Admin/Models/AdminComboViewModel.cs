using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Areas.Admin.Models
{
    public class AdminComboViewModel
    {
        public int SelectedKatId { get; internal set; }
        public SelectList SelectedKatData { get; internal set; }
    }
}
