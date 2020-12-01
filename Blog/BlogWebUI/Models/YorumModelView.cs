using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebUI.Models
{
    public class YorumModelView
    {
        public Func<int, IActionResult> Makaleicerik { get; internal set; }
    }
}
