#pragma checksum "C:\Users\user\source\repos\coreadvanced\coreadvanced\Views\Home\OnlinePayment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a253ce1302150065ea61a159e931ccd75e410f6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_OnlinePayment), @"mvc.1.0.view", @"/Views/Home/OnlinePayment.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/OnlinePayment.cshtml", typeof(AspNetCore.Views_Home_OnlinePayment))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a253ce1302150065ea61a159e931ccd75e410f6", @"/Views/Home/OnlinePayment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b853c2693020103458b52d8246f923ca3fd89014", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_OnlinePayment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Views\Home\OnlinePayment.cshtml"
  
    ViewData["Title"] = "نتیجه پرداخت";

#line default
#line hidden
            BeginContext(50, 347, true);
            WriteLiteral(@"    <div class=""container"">
        <nav aria-label=""breadcrumb"">
            <ul class=""breadcrumb"">
                <li class=""breadcrumb-item""><a href=""/"">تاپ لرن</a></li>
                <li class=""breadcrumb-item active"" aria-current=""page"">نتیجه پرداخت</li>
            </ul>
        </nav>
    </div>

    <div class=""container"">
");
            EndContext();
#line 15 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Views\Home\OnlinePayment.cshtml"
         if (ViewBag.Issuccess = true)
        {

#line default
#line hidden
            BeginContext(448, 129, true);
            WriteLiteral("            <div class=\"alert alert-success\">\r\n                <h2>پرداخت با موفقیت انجام شد</h2>\r\n                <p>کد پیگیری :");
            EndContext();
            BeginContext(578, 12, false);
#line 19 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Views\Home\OnlinePayment.cshtml"
                         Write(ViewBag.code);

#line default
#line hidden
            EndContext();
            BeginContext(590, 26, true);
            WriteLiteral("</p>\r\n            </div>\r\n");
            EndContext();
#line 21 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Views\Home\OnlinePayment.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(652, 128, true);
            WriteLiteral("            <div class=\"alert alert-danger\">\r\n                <h2>پرداخت انجام نگرفت</h2>\r\n               \r\n            </div>\r\n");
            EndContext();
#line 28 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Views\Home\OnlinePayment.cshtml"
        }

#line default
#line hidden
            BeginContext(791, 14, true);
            WriteLiteral("    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
