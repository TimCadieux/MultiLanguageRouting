#pragma checksum "D:\Garren\GitHb_Projects\TimCadieux\MultiLanguageRouting\Project.Web\Views\Shared\_Banner.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d7b14df3b9dc4fcb0d5350657e694da91b00c745"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Banner), @"mvc.1.0.view", @"/Views/Shared/_Banner.cshtml")]
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
#line 1 "D:\Garren\GitHb_Projects\TimCadieux\MultiLanguageRouting\Project.Web\Views\_ViewImports.cshtml"
using Project.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Garren\GitHb_Projects\TimCadieux\MultiLanguageRouting\Project.Web\Views\_ViewImports.cshtml"
using Project.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Garren\GitHb_Projects\TimCadieux\MultiLanguageRouting\Project.Web\Views\_ViewImports.cshtml"
using Project.Resources;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7b14df3b9dc4fcb0d5350657e694da91b00c745", @"/Views/Shared/_Banner.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"498b6df5b3f82f655ecb5cb107a458325c108647", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Banner : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<section id=\"banner\">\r\n    <h2>");
#nullable restore
#line 2 "D:\Garren\GitHb_Projects\TimCadieux\MultiLanguageRouting\Project.Web\Views\Shared\_Banner.cshtml"
   Write(Resource.Home);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>\r\n    <ul class=\"actions\">\r\n        <li>\r\n            <a href=\"#\" class=\"button big\">Lorem ipsum dolor</a>\r\n        </li>\r\n    </ul>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
