#pragma checksum "E:\ASP.NET CORE\YSKudemy\AdvertisementApp\UI\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc3c06d30196e99f823b9206699a678a869fc99c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 2 "E:\ASP.NET CORE\YSKudemy\AdvertisementApp\UI\Views\_ViewImports.cshtml"
using Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\ASP.NET CORE\YSKudemy\AdvertisementApp\UI\Views\_ViewImports.cshtml"
using UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc3c06d30196e99f823b9206699a678a869fc99c", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cdca5c247a74ccf9508cb184f775960ba4e13b04", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProvidedServiceListDto>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\ASP.NET CORE\YSKudemy\AdvertisementApp\UI\Views\Home\Index.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Header-->
<header class=""masthead text-center text-white"">
    <div class=""masthead-content"">
        <div class=""container px-5"">
            <h1 class=""masthead-heading mb-0"">Udemy Proje</h1>
            <h2 class=""masthead-subheading mb-0"">Masaüstü Uygulamaları</h2>
            <a class=""btn btn-primary btn-xl rounded-pill mt-5"" href=""#scroll"">Daha Fazlası</a>
        </div>
    </div>
    <div class=""bg-circle-1 bg-circle""></div>
    <div class=""bg-circle-2 bg-circle""></div>
    <div class=""bg-circle-3 bg-circle""></div>
    <div class=""bg-circle-4 bg-circle""></div>
</header>
");
#nullable restore
#line 19 "E:\ASP.NET CORE\YSKudemy\AdvertisementApp\UI\Views\Home\Index.cshtml"
 for (int i = 0; i < Model?.Count; i++)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <section id=\"scroll\">\r\n        <div class=\"container px-5\">\r\n            <div class=\"row gx-5 align-items-center\">\r\n                <div");
            BeginWriteAttribute("class", " class=\"", 857, "\"", 899, 2);
            WriteAttributeValue("", 865, "col-lg-6", 865, 8, true);
#nullable restore
#line 24 "E:\ASP.NET CORE\YSKudemy\AdvertisementApp\UI\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 873, i%2==0?"order-lg-2":"", 874, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"p-5\"><img class=\"img-fluid rounded-circle\"");
            BeginWriteAttribute("src", " src=\"", 977, "\"", 1002, 1);
#nullable restore
#line 25 "E:\ASP.NET CORE\YSKudemy\AdvertisementApp\UI\Views\Home\Index.cshtml"
WriteAttributeValue("", 983, Model[i].ImagePath, 983, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></div>\r\n                </div>\r\n                <div");
            BeginWriteAttribute("class", " class=\"", 1058, "\"", 1100, 2);
            WriteAttributeValue("", 1066, "col-lg-6", 1066, 8, true);
#nullable restore
#line 27 "E:\ASP.NET CORE\YSKudemy\AdvertisementApp\UI\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 1074, i%2==0?"order-lg-1":"", 1075, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"p-5\">\r\n                        <h2 class=\"display-4\">");
#nullable restore
#line 29 "E:\ASP.NET CORE\YSKudemy\AdvertisementApp\UI\Views\Home\Index.cshtml"
                                         Write(Model[i].Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                        <p>");
#nullable restore
#line 30 "E:\ASP.NET CORE\YSKudemy\AdvertisementApp\UI\Views\Home\Index.cshtml"
                      Write(Model[i].Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n");
#nullable restore
#line 36 "E:\ASP.NET CORE\YSKudemy\AdvertisementApp\UI\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProvidedServiceListDto>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
