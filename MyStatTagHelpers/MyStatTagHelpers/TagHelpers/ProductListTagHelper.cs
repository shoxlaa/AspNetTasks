using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MyStatTagHelpers.Models;
using System.Text;

namespace MyStatTagHelpers.TagHelpers
{
    [HtmlTargetElement("homework", Attributes = "homework-list", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class ProductListTagHelper : TagHelper
    {
        [HtmlAttributeName("homework-list")]
        public List<HomeWork>? HomeWorks { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";


            if (HomeWorks == null)
            {
                return;
            }
            var builder = new StringBuilder();

            builder.Append("<div id=\"big-container\">");

            //я использовала этот метод потому что у меня уже изначально был html код


            foreach (var product in HomeWorks)
            {
                builder.Append($"<div class=\"container-my\" data-id=\"{product.Id}\">  " +
                    $"<div class=\"id-div\" > <div>{product.Id}</div>" +
                    $"<input  data-id=\"{product.Id}\" class=\"button-remove\" value=\"delete\" type=\"button\"/> " +
                    $"</div>  <h1>{product.Title}</h1>" +
                    $"      <div>{product.CreatedDate}</div>\r\n         " +
                    $"   <a href=\"/HomeWork/Download?id={product.Id}\" class=\"btn-primary btn\">Download file</a>      " +
                    $"  </div>");

            }
            output.Content.AppendHtml(builder.ToString());


            builder.Append("</div>");

        }

    }
}
