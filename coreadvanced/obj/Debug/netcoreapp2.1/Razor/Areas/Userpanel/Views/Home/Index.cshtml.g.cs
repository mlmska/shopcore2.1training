#pragma checksum "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85502b0522ee4598fb1ca59a2f02ef981fb75459"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Userpanel_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Userpanel/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Userpanel/Views/Home/Index.cshtml", typeof(AspNetCore.Areas_Userpanel_Views_Home_Index))]
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
#line 1 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\Home\Index.cshtml"
using Core.Convertors;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85502b0522ee4598fb1ca59a2f02ef981fb75459", @"/Areas/Userpanel/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b853c2693020103458b52d8246f923ca3fd89014", @"/Areas/Userpanel/Views/_ViewImports.cshtml")]
    public class Areas_Userpanel_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Core.DTOs.InformationViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Sidebar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "userpanel"+User.Identity.Name;

#line default
#line hidden
            BeginContext(127, 430, true);
            WriteLiteral(@"
    <div class=""container"">
        <nav aria-label=""breadcrumb"">
            <ul class=""breadcrumb"">
                <li class=""breadcrumb-item""><a href=""/"">تاپ لرن</a></li>
                <li class=""breadcrumb-item active"" aria-current=""page""> پنل کاربری </li>
            </ul>
        </nav>
    </div>
    <div class=""container"">
        <div class=""user-account"">
            <div class=""row"">
                ");
            EndContext();
            BeginContext(557, 27, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2b0c9d2a1ad544b5862e134c7bd89ad3", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(584, 524, true);
            WriteLiteral(@"
                <div class=""col-md-9 col-sm-8 col-xs-12"">
                    <section class=""user-account-content"">
                        <header><h1> داشبورد </h1></header>
                        <div class=""inner"">
                            <div class=""account-information"">
                                <h3> اطلاعات کاربری </h3>
                                <ul>
                                   
                                    <li> <i class=""zmdi zmdi-assignment-account""></i> نام کاربری :  ");
            EndContext();
            BeginContext(1109, 14, false);
#line 27 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\Home\Index.cshtml"
                                                                                               Write(Model.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1123, 89, true);
            WriteLiteral(" </li>\r\n                                    <li> <i class=\"zmdi zmdi-email\"></i> ایمیل : ");
            EndContext();
            BeginContext(1213, 11, false);
#line 28 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\Home\Index.cshtml"
                                                                            Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1224, 104, true);
            WriteLiteral(" </li>\r\n                                    <li> <i class=\"zmdi zmdi-calendar-check\"></i> تاریخ عضویت : ");
            EndContext();
            BeginContext(1329, 29, false);
#line 29 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\Home\Index.cshtml"
                                                                                           Write(Model.Registerdate.toshamsi());

#line default
#line hidden
            EndContext();
            BeginContext(1358, 103, true);
            WriteLiteral(" </li>\r\n                                    <li> <i class=\"zmdi zmdi-smartphone-android\"></i> کیف پول: ");
            EndContext();
            BeginContext(1462, 12, false);
#line 30 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\Home\Index.cshtml"
                                                                                          Write(Model.Wallet);

#line default
#line hidden
            EndContext();
            BeginContext(1474, 221, true);
            WriteLiteral(" </li>\r\n                                </ul>\r\n                            </div>\r\n                        </div>\r\n                    </section>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Core.DTOs.InformationViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591