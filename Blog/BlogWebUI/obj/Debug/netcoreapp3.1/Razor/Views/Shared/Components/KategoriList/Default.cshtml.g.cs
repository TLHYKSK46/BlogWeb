#pragma checksum "D:\GitHub\BlogWeb\Blog\BlogWebUI\Views\Shared\Components\KategoriList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abe05c9115abe21e8ed7b31aa61c579022551708"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_KategoriList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/KategoriList/Default.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\GitHub\BlogWeb\Blog\BlogWebUI\Views\_ViewImports.cshtml"
using BlogWebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitHub\BlogWeb\Blog\BlogWebUI\Views\_ViewImports.cshtml"
using BlogWebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abe05c9115abe21e8ed7b31aa61c579022551708", @"/Views/Shared/Components/KategoriList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"787623a88472e60d6fba24ba40327cb4d09ea29f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_KategoriList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogWebUI.Models.KategoriListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("    <div class=\"card my-2 kartim\">\r\n        <h5 class=\"card-header\">Kategoriler</h5>\r\n\r\n");
#nullable restore
#line 9 "D:\GitHub\BlogWeb\Blog\BlogWebUI\Views\Shared\Components\KategoriList\Default.cshtml"
             foreach (var item in Model.Kategoriler)
            {
                var KategoriMakaleSayisi = Model.Makaleler.Where(i => i.KategoriId == item.KategoriId).Count();

                var css = "list-group-item list-group-item-action list-group-item-action  ";
                var cssbadge = "badge badge-danger float-right ";
                if (item.KategoriId == Model.seciliOlanKategori)
                {
                    css += "active list-group-item-danger ";
                    cssbadge = "badge badge-light float-right ";

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <ul class=\"list-group list-group-flush float-right\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 827, "\"", 873, 2);
            WriteAttributeValue("", 834, "/home/index?kategoriId=", 834, 23, true);
#nullable restore
#line 22 "D:\GitHub\BlogWeb\Blog\BlogWebUI\Views\Shared\Components\KategoriList\Default.cshtml"
WriteAttributeValue("", 857, item.KategoriId, 857, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-decoration-none\" style=\"margin-top:0\">\r\n\r\n                        <li");
            BeginWriteAttribute("class", " class=\"", 956, "\"", 968, 1);
#nullable restore
#line 24 "D:\GitHub\BlogWeb\Blog\BlogWebUI\Views\Shared\Components\KategoriList\Default.cshtml"
WriteAttributeValue("", 964, css, 964, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n                            ");
#nullable restore
#line 26 "D:\GitHub\BlogWeb\Blog\BlogWebUI\Views\Shared\Components\KategoriList\Default.cshtml"
                       Write(item.KategoriAdi);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span");
            BeginWriteAttribute("class", " class=\"", 1025, "\"", 1042, 1);
#nullable restore
#line 26 "D:\GitHub\BlogWeb\Blog\BlogWebUI\Views\Shared\Components\KategoriList\Default.cshtml"
WriteAttributeValue("", 1033, cssbadge, 1033, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 26 "D:\GitHub\BlogWeb\Blog\BlogWebUI\Views\Shared\Components\KategoriList\Default.cshtml"
                                                                 Write(KategoriMakaleSayisi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n                        </li>\r\n                    </a>\r\n                </ul>\r\n");
#nullable restore
#line 31 "D:\GitHub\BlogWeb\Blog\BlogWebUI\Views\Shared\Components\KategoriList\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogWebUI.Models.KategoriListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591