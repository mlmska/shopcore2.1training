#pragma checksum "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "08fae3279bc96cfd8e5e94c7e255b22c20c04e44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Userpanel_Views_MyOrders_ShowOrder), @"mvc.1.0.view", @"/Areas/Userpanel/Views/MyOrders/ShowOrder.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Userpanel/Views/MyOrders/ShowOrder.cshtml", typeof(AspNetCore.Areas_Userpanel_Views_MyOrders_ShowOrder))]
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
#line 2 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
using Core.Services.Intefaces;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08fae3279bc96cfd8e5e94c7e255b22c20c04e44", @"/Areas/Userpanel/Views/MyOrders/ShowOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b853c2693020103458b52d8246f923ca3fd89014", @"/Areas/Userpanel/Views/_ViewImports.cshtml")]
    public class Areas_Userpanel_Views_MyOrders_ShowOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<datalayer.Entities.Order.Order>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Sidebar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/UserPanel/MyOrders/UseDiscount"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(106, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
   
    int sumOrder = Model.Ordersum;
    string discounttype = ViewBag.typeDiscount.ToString();

#line default
#line hidden
            BeginContext(212, 437, true);
            WriteLiteral(@"    <div class=""container"">
        <nav aria-label=""breadcrumb"">
            <ul class=""breadcrumb"">
                <li class=""breadcrumb-item""><a href=""/"">تاپ لرن</a></li>
                <li class=""breadcrumb-item active"" aria-current=""page"">نمایش فاکتور </li>
            </ul>
        </nav>
    </div>
<main>
    <div class=""container"">
        <div class=""user-account"">
            <div class=""row"">
                ");
            EndContext();
            BeginContext(649, 27, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "69b4b580f510412998fdb08a3c854c9c", async() => {
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
            BeginContext(676, 184, true);
            WriteLiteral("\r\n                <div class=\"col-md-9 col-sm-8 col-xs-12\">\r\n                    <section class=\"user-account-content\">\r\n                        <header><h1>فاکتور شما </h1></header>\r\n");
            EndContext();
#line 25 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                         if (ViewBag.finaly == true)
                        {

#line default
#line hidden
            BeginContext(941, 160, true);
            WriteLiteral("                            <div class=\"alert alert-success\">\r\n                                پرداخت با موفقیت انجام شد\r\n\r\n                            </div>\r\n");
            EndContext();
#line 31 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                        }

#line default
#line hidden
            BeginContext(1128, 455, true);
            WriteLiteral(@"                        <table class=""table table-bordered"">
                            <thead>
                                <tr>
                                    <th>دوره</th>
                                    <th>تعداد</th>
                                    <th>قیمت</th>
                                    <th>جمع</th>
                                </tr>
                            </thead>
                            <tbody>
");
            EndContext();
#line 42 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                 foreach (var item in Model.OrderDetails)
                                {

#line default
#line hidden
            BeginContext(1693, 134, true);
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1827, "\"", 1858, 2);
            WriteAttributeValue("", 1834, "/ShowCourse/", 1834, 12, true);
#line 46 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
WriteAttributeValue("", 1846, item.Course, 1846, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1859, 17, true);
            WriteLiteral(" target=\"_blank\">");
            EndContext();
            BeginContext(1877, 23, false);
#line 46 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                                                                          Write(item.Course.CourseTitle);

#line default
#line hidden
            EndContext();
            BeginContext(1900, 143, true);
            WriteLiteral("</a>\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(2044, 10, false);
#line 49 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                       Write(item.Count);

#line default
#line hidden
            EndContext();
            BeginContext(2054, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(2194, 10, false);
#line 52 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                       Write(item.Price);

#line default
#line hidden
            EndContext();
            BeginContext(2204, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(2345, 41, false);
#line 55 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                        Write((item.Count * item.Price).ToString("#,0"));

#line default
#line hidden
            EndContext();
            BeginContext(2387, 92, true);
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
            EndContext();
#line 58 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                }

#line default
#line hidden
            BeginContext(2514, 32, true);
            WriteLiteral("                                ");
            EndContext();
#line 59 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                 if (!Model.isFinally)
                                {

#line default
#line hidden
            BeginContext(2605, 221, true);
            WriteLiteral("                                    <tr>\r\n                                        <td colspan=\"3\" class=\"text-left\">کد تخفیف</td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(2826, 473, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f7750a0780f45ffbffa7696dc69c0c8", async() => {
                BeginContext(2887, 85, true);
                WriteLiteral("\r\n                                                <input type=\"hidden\" name=\"orderid\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2972, "\"", 2994, 1);
#line 65 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
WriteAttributeValue("", 2980, Model.OrderID, 2980, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2995, 297, true);
                WriteLiteral(@" />
                                                <input type=""text"" name=""code"" class=""form-control"" />
                                                <input type=""submit"" class=""btn btn-primary btn-block"" style=""margin-top:5px"" value=""اعمال"" />
                                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3299, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 69 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                             if (discounttype != "")
                                            {
                                                switch (discounttype)
                                                {
                                                    case "Success":
                                                        {

#line default
#line hidden
            BeginContext(3668, 276, true);
            WriteLiteral(@"                                                            <div class=""alert alert-success"">
                                                                <p class=""text-muted"">کد با موفقیت اعمال شد</p>
                                                            </div>
");
            EndContext();
#line 78 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                                            break;
                                                        }
                                                    case "ExpireDate":
                                                        {

#line default
#line hidden
            BeginContext(4202, 276, true);
            WriteLiteral(@"                                                            <div class=""alert alert-danger"">
                                                                <p class=""text-muted"">تاریخ کد به اتمام رسید</p>
                                                            </div>
");
            EndContext();
#line 85 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                                            break;
                                                        }
                                                    case "NotFound":
                                                        {

#line default
#line hidden
            BeginContext(4734, 268, true);
            WriteLiteral(@"                                                            <div class=""alert alert-warning"">
                                                                <p class=""text-muted"">کد معتبر نیست</p>
                                                            </div>
");
            EndContext();
#line 92 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                                            break;
                                                        }
                                                    case "Finished":
                                                        {

#line default
#line hidden
            BeginContext(5258, 275, true);
            WriteLiteral(@"                                                            <div class=""alert alert-danger"">
                                                                <p class=""text-muted"">کد به اتمام رسیده است</p>
                                                            </div>
");
            EndContext();
#line 99 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                                            break;
                                                        }
                                                    case "UserUsed":
                                                        {

#line default
#line hidden
            BeginContext(5789, 278, true);
            WriteLiteral(@"                                                            <div class=""alert alert-info"">
                                                                <p class=""text-muted"">کد راقبلا استفاده کرده اید</p>
                                                            </div>
");
            EndContext();
#line 106 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                                            break;
                                                        }
                                                }
                                            }

#line default
#line hidden
            BeginContext(6292, 90, true);
            WriteLiteral("                                        </td>\r\n                                    </tr>\r\n");
            EndContext();
#line 112 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                }

#line default
#line hidden
            BeginContext(6417, 203, true);
            WriteLiteral("                                <tr>\r\n                                    <td colspan=\"3\" class=\"text-left\">جمع کل</td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(6621, 8, false);
#line 116 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                   Write(sumOrder);

#line default
#line hidden
            EndContext();
            BeginContext(6629, 84, true);
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 119 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                 if (!Model.isFinally)
                                                    {

#line default
#line hidden
            BeginContext(6824, 181, true);
            WriteLiteral("                                    <tr>\r\n                                        <td colspan=\"2\" class=\"text-left\"></td>\r\n                                        <td colspan=\"2\">\r\n");
            EndContext();
#line 124 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                             if (_userservice.Balanceuserwallett(User.Identity.Name) >= sumOrder)
                                            {

#line default
#line hidden
            BeginContext(7167, 84, true);
            WriteLiteral("                                                <a class=\"btn btn-success btn-block\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 7251, "\"", 7305, 2);
            WriteAttributeValue("", 7258, "/UserPanel/MyOrders/FinallyOrder/", 7258, 33, true);
#line 126 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
WriteAttributeValue("", 7291, Model.OrderID, 7291, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7306, 18, true);
            WriteLiteral(">تایید فکتور</a>\r\n");
            EndContext();
#line 127 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
            BeginContext(7468, 472, true);
            WriteLiteral(@"                                                <a class=""btn btn-success btn-block"" disabled>تایید فکتور</a>
                                                <div class=""alert alert-danger"">
                                                    موجودی کیف شما کافی نمی باشد لطفا حساب خود را شارژ کنید
                                                    <a href=""/UserPanel/Wallet"" class=""alert-link"">شارژ حساب</a>
                                                </div>
");
            EndContext();
#line 135 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                            }

#line default
#line hidden
            BeginContext(7987, 90, true);
            WriteLiteral("                                        </td>\r\n                                    </tr>\r\n");
            EndContext();
#line 138 "C:\Users\user\source\repos\coreadvanced\coreadvanced\Areas\Userpanel\Views\MyOrders\ShowOrder.cshtml"
                                }

#line default
#line hidden
            BeginContext(8112, 255, true);
            WriteLiteral("\r\n                            </tbody>\r\n\r\n                        </table>\r\n                    </section>\r\n                   \r\n                </div>\r\n\r\n          \r\n            </div>\r\n       \r\n        </div>\r\n\r\n        \r\n    </div>\r\n \r\n   \r\n    </main>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IUserService _userservice { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<datalayer.Entities.Order.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591