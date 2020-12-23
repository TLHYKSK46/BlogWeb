using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebUI.TagHelpers
{
    [HtmlTargetElement("makale-list-sayfa")]
    public class PageinTagHelper : TagHelper
    {
        [HtmlAttributeName("sayfa-sayisi")]
        public int SayfaSayisi { get; set; }

        [HtmlAttributeName("sayfa-boyut")]
        public int SayfaBoyut { get; set; }

        [HtmlAttributeName("secili-kategori")]
        public int SeciliKategori { get; set; }

        [HtmlAttributeName("secili-sayfa")]
        public int SeciliSayfa { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<ul class='pagination justify-content-center text-danger text-decoration-none'>");

            for (int i = 1; i <= SayfaSayisi; i++)
            {
                stringBuilder.AppendFormat("<li class='{0} page-item'>", i == SeciliKategori?"active":"");
                stringBuilder.AppendFormat("<a class='page-link' href='/home/index?sayfaNo={0}&kategoriId={1}'>{2}</a>", i, SeciliKategori, i);
                stringBuilder.Append("</li>");
            }
            //stringBuilder.Append("</ul>");

            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);
        }
    }
}
