using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyStatTagHelpers.Models;
using System.Text;

namespace MyStatTagHelpers.HtmlHelpers
{
    public static class DivHelper
    {
        public static HtmlString RenderHomeWorks(this IHtmlHelper source, List<HomeWork> products)
        {

            var builder = new StringBuilder();

            builder.Append("<div id=\"big-container\">");

            //я использовала этот метод потому что у меня уже изначально был html код
            

            foreach (var product in products)
            {
                builder.Append($"<div class=\"container-my\" data-id=\"{product.Id}\">  " +
                    $"<div class=\"id-div\" > <div>{product.Id}</div>" +
                    $"<input  data-id=\"{product.Id}\" class=\"button-remove\" value=\"delete\" type=\"button\"/> " +
                    $"</div>  <h1>{product.Title}</h1>" +
                    $"      <div>{product.CreatedDate}</div>\r\n         " +
                    $"   <a href=\"/HomeWork/Download?id={product.Id}\" class=\"btn-primary btn\">Download file</a>      " +
                    $"  </div>");
            }

            builder.Append("</div>");

            return new HtmlString(builder.ToString());
        }

    }
//        <div id = "big-container" >
//    @foreach(var v in @Model)
//    {
//        <div class="container-my" data-id="@v.Id">
//            <div class="id-div" >
//                @v.Id
//                @*<a href = "" value="delete" class="button-delete"/>*@
//                <input data-id="@v.Id" class="button-remove" value="delete" type="button" />
                
//            </div>
//            <h1>@v.Title</h1>
//            <div>@v.File</div>
//            <div>@v.CreatedDate</div>
//            <a href = "/HomeWork/Download?id=@v.Id" class="btn-primary btn">Download file</a>
//        </div>
//    }
//</ div >

}
