#pragma checksum "C:\Users\hale irem beyaz\source\repos\web_technologies\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f75c9822844b37ea80cdc63899f5b80288858a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f75c9822844b37ea80cdc63899f5b80288858a0", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<web_technologies.Models.Movie>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\hale irem beyaz\source\repos\web_technologies\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(89, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\Users\hale irem beyaz\source\repos\web_technologies\Views\Home\Index.cshtml"
 using (Html.BeginForm("Login", "Admin"))
{


#line default
#line hidden
            BeginContext(139, 55, true);
            WriteLiteral("    <input type=\"submit\" value=\"Admin Panel Login\" />\r\n");
            EndContext();
#line 10 "C:\Users\hale irem beyaz\source\repos\web_technologies\Views\Home\Index.cshtml"

}

#line default
#line hidden
#line 12 "C:\Users\hale irem beyaz\source\repos\web_technologies\Views\Home\Index.cshtml"
 using (Html.BeginForm("Login", "User"))
{


#line default
#line hidden
            BeginContext(246, 48, true);
            WriteLiteral("    <input type=\"submit\" value=\"User Login\" />\r\n");
            EndContext();
#line 16 "C:\Users\hale irem beyaz\source\repos\web_technologies\Views\Home\Index.cshtml"

}

#line default
#line hidden
            BeginContext(299, 445, true);
            WriteLiteral(@"<div class=""text-center"">
    <h1 class=""display-4"">Home Page</h1>


    <h2>buraya filmler ve gösterimde oldukları salon listesi gelecek</h2>


    <table class=""table table-bordered"">
        <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Description</th>
                <th>Date</th>
                <th>Saloon</th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 36 "C:\Users\hale irem beyaz\source\repos\web_technologies\Views\Home\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(801, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(840, 13, false);
#line 39 "C:\Users\hale irem beyaz\source\repos\web_technologies\Views\Home\Index.cshtml"
               Write(item.Movie_id);

#line default
#line hidden
            EndContext();
            BeginContext(853, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(881, 15, false);
#line 40 "C:\Users\hale irem beyaz\source\repos\web_technologies\Views\Home\Index.cshtml"
               Write(item.Movie_name);

#line default
#line hidden
            EndContext();
            BeginContext(896, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(924, 22, false);
#line 41 "C:\Users\hale irem beyaz\source\repos\web_technologies\Views\Home\Index.cshtml"
               Write(item.Movie_description);

#line default
#line hidden
            EndContext();
            BeginContext(946, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(974, 15, false);
#line 42 "C:\Users\hale irem beyaz\source\repos\web_technologies\Views\Home\Index.cshtml"
               Write(item.Movie_date);

#line default
#line hidden
            EndContext();
            BeginContext(989, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1017, 9, false);
#line 43 "C:\Users\hale irem beyaz\source\repos\web_technologies\Views\Home\Index.cshtml"
               Write(item.S_id);

#line default
#line hidden
            EndContext();
            BeginContext(1026, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 45 "C:\Users\hale irem beyaz\source\repos\web_technologies\Views\Home\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1067, 40, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<web_technologies.Models.Movie>> Html { get; private set; }
    }
}
#pragma warning restore 1591
