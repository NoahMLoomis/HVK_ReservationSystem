#pragma checksum "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3fa667a857934e2a0a9cd6423d5012f981f78d08"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pet_Index), @"mvc.1.0.view", @"/Views/Pet/Index.cshtml")]
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
#line 1 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\_ViewImports.cshtml"
using HVK_ZZTop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\_ViewImports.cshtml"
using HVK_ZZTop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fa667a857934e2a0a9cd6423d5012f981f78d08", @"/Views/Pet/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"738470f597030531a491aa71dcc2154787568b3f", @"/Views/_ViewImports.cshtml")]
    public class Views_Pet_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HVK_ZZTop.Models.Pet>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Pet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
  
    ViewData["Title"] = "Pet List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>Pet</h3>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3fa667a857934e2a0a9cd6423d5012f981f78d084709", async() => {
                WriteLiteral("Create New Pet");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n\r\n");
#nullable restore
#line 13 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card mb-3\">\r\n        <div class=\"card-header bg-white\">\r\n            <div class=\"row align-items-center\">\r\n                <div class=\"col\">\r\n                    <h5 class=\"card-title mb-0\">");
#nullable restore
#line 18 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                </div><div class=\"col-auto ml-auto\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3fa667a857934e2a0a9cd6423d5012f981f78d086703", async() => {
                WriteLiteral("<span class=\"fas fa-pencil-alt fs--2 mr-1\"></span>Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 19 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                                                                                WriteLiteral(item.PetId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</div>

            </div>
        </div>
        <div class=""card-body bg-light border-top"">
            <div class=""row"">
                <div class=""col-lg col-xxl-5 position-relative"">
                    <div class=""row"">
                        <h6 class=""font-weight-semi-bold ls mb-3"">Information</h6>
                        <div class=""col-auto ml-auto""></div>
                    </div>
                    <div class=""row"">
                        <div class=""col-5 col-sm-4"">
                            <p class=""font-weight-semi-bold mb-1""> ");
#nullable restore
#line 32 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                                              Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                        <div class=\"col\"> ");
#nullable restore
#line 34 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                     Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    </div>\r\n                    <div class=\"row\">\r\n                        <div class=\"col-5 col-sm-4\">\r\n                            <p class=\"font-weight-semi-bold mb-1\"> ");
#nullable restore
#line 38 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                                              Write(Html.DisplayNameFor(model => model.Breed));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                        <div class=\"col\"> ");
#nullable restore
#line 40 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                     Write(Html.DisplayFor(modelItem => item.Breed));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    </div>\r\n                    <div class=\"row\">\r\n                        <div class=\"col-5 col-sm-4\">\r\n                            <p class=\"font-weight-semi-bold mb-1\"> ");
#nullable restore
#line 44 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                                              Write(Html.DisplayNameFor(model => model.DogSize));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                        <div class=\"col\">");
#nullable restore
#line 46 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                    Write(Html.DisplayFor(modelItem => item.DogSize));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    </div>\r\n                    <div class=\"row\">\r\n                        <div class=\"col-5 col-sm-4\">\r\n                            <p class=\"font-weight-semi-bold mb-1\"> ");
#nullable restore
#line 50 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                                              Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                        <div class=\"col\">");
#nullable restore
#line 52 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                    Write(Html.DisplayFor(modelItem => item.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    </div>\r\n                    <div class=\"row\">\r\n                        <div class=\"col-5 col-sm-4\">\r\n                            <p class=\"font-weight-semi-bold mb-1\">");
#nullable restore
#line 56 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                                             Write(Html.DisplayNameFor(modelItem => item.Birthdate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                        <div class=\"col\"> ");
#nullable restore
#line 58 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                     Write(Html.DisplayFor(modelItem => item.Birthdate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    </div>\r\n                    <div class=\"row\">\r\n                        <div class=\"col-5 col-sm-4\">\r\n                            <p class=\"font-weight-semi-bold mb-1\"> ");
#nullable restore
#line 62 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                                              Write(Html.DisplayNameFor(model => model.Fixed));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                        <div class=\"col\">");
#nullable restore
#line 64 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                    Write(Html.DisplayFor(modelItem => item.Fixed));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    </div>\r\n                    <div class=\"row\">\r\n                        <div class=\"col-5 col-sm-4\">\r\n                            <p class=\"font-weight-semi-bold mb-1\"> ");
#nullable restore
#line 68 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                                              Write(Html.DisplayNameFor(model => model.Climber));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                        <div class=\"col\">");
#nullable restore
#line 70 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                    Write(Html.DisplayFor(modelItem => item.Climber));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    </div><div class=\"row\">\r\n                        <div class=\"col-5 col-sm-4\">\r\n                            <p class=\"font-weight-semi-bold mb-1\"> ");
#nullable restore
#line 73 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                                              Write(Html.DisplayNameFor(model => model.Barker));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                        <div class=\"col\">");
#nullable restore
#line 75 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                    Write(Html.DisplayFor(modelItem => item.Barker));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                    </div>
                </div>
                <div class=""col-lg col-xxl-5 mt-4 mt-lg-0 offset-xxl-1"">
                    <h6 class=""font-weight-semi-bold ls mb-3"">Vaccination</h6>
                    <div class=""card-body table-responsive"">
                        <table class=""table"">
                            <thead hidden>
                                <tr>
                                    <th></th>
                                    <th>
                                        Name
                                    </th>
                                    <th>
                                        ExpiryDate
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 94 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                 foreach (var vac in ViewBag.Vaccinations) {
                                    var pv = item.PetVaccination.Where(v => v.VaccinationId == vac.VaccinationId).FirstOrDefault();

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                           <input type=\"checkbox\" disabled ");
#nullable restore
#line 98 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                                                       Write((pv != null && pv.VaccinationChecked)? "checked":"" );

#line default
#line hidden
#nullable disable
            WriteLiteral("/>\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 101 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                       Write(vac.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n");
#nullable restore
#line 104 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                             if (pv != null) {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 105 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                           Write(pv.ExpiryDate?.ToString("yyyy\\/MM\\/dd"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 105 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                                                                          ;
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 106 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                                 if (pv.ExpiryDate < DateTime.Today) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <i class=\"bi bi-patch-exclamation text-warning\" title=\"Vaccination has expired\"></i>              \r\n");
#nullable restore
#line 108 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                                 }

#line default
#line hidden
#nullable disable
#nullable restore
#line 108 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                                  
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 112 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 120 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Pet\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HVK_ZZTop.Models.Pet>> Html { get; private set; }
    }
}
#pragma warning restore 1591
