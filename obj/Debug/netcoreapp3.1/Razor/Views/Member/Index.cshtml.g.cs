#pragma checksum "D:\EliasFile\Tree\FloorManagement\DomMS\Views\Member\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec3fd5b5466003055a91cd71b9d58bc283d28a23"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Member_Index), @"mvc.1.0.view", @"/Views/Member/Index.cshtml")]
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
#line 1 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\_ViewImports.cshtml"
using DomMS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\_ViewImports.cshtml"
using DomMS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec3fd5b5466003055a91cd71b9d58bc283d28a23", @"/Views/Member/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f80187d55cf007e6cf0d6cf3e1d41a7426c42ac3", @"/Views/_ViewImports.cshtml")]
    public class Views_Member_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BookingsVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/gantt/gantt.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/gantt/gantt.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/gantt/initialize-gantt.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\Member\Index.cshtml"
  
    ViewData["Title"] = "Profile";
    Layout = "~/Views/Shared/_templateSiteLayout.cshtml";
    ViewData["Footer"] = "false";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Stylesheets", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ec3fd5b5466003055a91cd71b9d58bc283d28a234874", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <style>
        body {
            color: #1a202c;
            text-align: left;
            background-color: #e2e8f0;
        }

        .main-body {
            padding-top: 15px;
        }

        .card {
            box-shadow: 0 1px 3px 0 rgba(0,0,0,.1), 0 1px 2px 0 rgba(0,0,0,.06);
        }

        .card {
            position: relative;
            display: flex;
            flex-direction: column;
            min-width: 0;
            word-wrap: break-word;
            background-color: #fff;
            background-clip: border-box;
            border: 0 solid rgba(0,0,0,.125);
            border-radius: .25rem;
        }

        .card-body {
            flex: 1 1 auto;
            min-height: 1px;
            padding: 1rem;
        }

        .gutters-sm {
            margin-right: -8px;
            margin-left: -8px;
        }

            .gutters-sm > .col, .gutters-sm > [class*=col-] {
                padding-right: 8px;
                padding-l");
                WriteLiteral(@"eft: 8px;
            }

        .mb-3, .my-3 {
            margin-bottom: 1rem !important;
        }

        .bg-gray-300 {
            background-color: #e2e8f0;
        }

        .h-100 {
            height: 100% !important;
        }

        .shadow-none {
            box-shadow: none !important;
        }

        #chart {
            width: 100%;
            overflow-x: scroll;
        }

        .container {
            margin-left: 20px;
            margin-right: 20px;
            width: 100%;
        }
    </style>
");
            }
            );
            WriteLiteral(@"
<div class=""container"">
    <div class=""main-body"">
        <div class=""row gutters-sm"">
            <div class=""col-md-3"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""d-flex flex-column align-items-center text-center"">
                            <img");
            BeginWriteAttribute("src", " src=\"", 2174, "\"", 2199, 1);
#nullable restore
#line 89 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\Member\Index.cshtml"
WriteAttributeValue("", 2180, ViewData["imgUrl"], 2180, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"image\" class=\"rounded-circle\" width=\"150\">\r\n                            <div class=\"mt-3\">\r\n                                <h4>");
#nullable restore
#line 91 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\Member\Index.cshtml"
                               Write(ViewData["name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                <p class=\"text-secondary mb-1\">Member</p>\r\n");
            WriteLiteral(@"                            </div>
                        </div>
                    </div>
                </div>
                <div class=""card mt-3"">
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-sm-3"">
                                <h6 class=""mb-0"">Full Name</h6>
                            </div>
                            <div class=""col-sm-9 text-secondary"">
                                ");
#nullable restore
#line 106 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\Member\Index.cshtml"
                           Write(ViewData["name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                        </div>
                        <hr>
                        <div class=""row"">
                            <div class=""col-sm-3"">
                                <h6 class=""mb-0"">Email</h6>
                            </div>
                            <div class=""col-sm-9 text-secondary"">
                                ");
#nullable restore
#line 115 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\Member\Index.cshtml"
                           Write(ViewData["mail"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                        </div>
                        <hr>

                    </div>
                </div>
            </div>
            <div class=""col-md-8"" style=""height:500px; overflow-y:scroll;"">

                <table class=""table"">
                    <thead>
                        <tr>
                            <th>
                                ");
#nullable restore
#line 129 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\Member\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.RoomName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 132 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\Member\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 135 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\Member\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.TimeDuration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 140 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\Member\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 144 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\Member\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.RoomName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 147 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\Member\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 150 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\Member\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.TimeDuration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    <button class=\"btn btn-danger\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5119, "\"", 5188, 8);
            WriteAttributeValue("", 5129, "confirm(\'Are", 5129, 12, true);
            WriteAttributeValue(" ", 5141, "you", 5142, 4, true);
            WriteAttributeValue(" ", 5145, "sure", 5146, 5, true);
            WriteAttributeValue(" ", 5150, "?\')", 5151, 4, true);
            WriteAttributeValue(" ", 5154, "&&", 5155, 3, true);
            WriteAttributeValue(" ", 5157, "DeleteBooking(", 5158, 15, true);
#nullable restore
#line 153 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\Member\Index.cshtml"
WriteAttributeValue("", 5172, item.BookingId, 5172, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5187, ")", 5187, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Delete</button>\r\n\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 157 "D:\EliasFile\Tree\FloorManagement\DomMS\Views\Member\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec3fd5b5466003055a91cd71b9d58bc283d28a2314810", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec3fd5b5466003055a91cd71b9d58bc283d28a2315910", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>
        function DeleteBooking(id) {
            var url = '/Member/DeleteBooking/' + id;
            $.get(url, function (result, status) {

                if (""success"" !== status) {
                    toastr.error('Failed To Delete!');
                    return;
                }
                else if (true == result) {
                    toastr.success(""Delete Successful"");
                    window.top.location = '/Member/Index';
                    return;
                }
                else {
                    toastr.error(""Delete Faild"");
                }
                // result
            });
        }
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BookingsVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
