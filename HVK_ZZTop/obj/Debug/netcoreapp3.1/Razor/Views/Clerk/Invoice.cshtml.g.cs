#pragma checksum "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe28e3a17b4346823b9295795d9f930f356683a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clerk_Invoice), @"mvc.1.0.view", @"/Views/Clerk/Invoice.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe28e3a17b4346823b9295795d9f930f356683a9", @"/Views/Clerk/Invoice.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"738470f597030531a491aa71dcc2154787568b3f", @"/Views/_ViewImports.cshtml")]
    public class Views_Clerk_Invoice : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HVK_ZZTop.Models.PetReservation>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/logo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("invoice"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("96"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
  
    ViewData["Title"] = "Invoice";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<p>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe28e3a17b4346823b9295795d9f930f356683a94957", async() => {
                WriteLiteral("Back to Home");
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
            WriteLiteral(@"</p>
    <div class=""card mb-3"">
        <div class=""card-body"">
            <div class=""row justify-content-between align-items-center"">
                <div class=""col-md"">
                    <h5 class=""mb-2 mb-md-0"">Order #21431241</h5>
                </div>
                <div class=""col-auto"">
                    <button class=""btn btn-falcon-default btn-sm mr-2 mb-2 mb-sm-0"" type=""button""><svg class=""svg-inline--fa fa-print fa-w-16 mr-1"" aria-hidden=""true"" focusable=""false"" data-prefix=""fas"" data-icon=""print"" role=""img"" xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 512 512"" data-fa-i2svg=""""><path fill=""currentColor"" d=""M448 192V77.25c0-8.49-3.37-16.62-9.37-22.63L393.37 9.37c-6-6-14.14-9.37-22.63-9.37H96C78.33 0 64 14.33 64 32v160c-35.35 0-64 28.65-64 64v112c0 8.84 7.16 16 16 16h48v96c0 17.67 14.33 32 32 32h320c17.67 0 32-14.33 32-32v-96h48c8.84 0 16-7.16 16-16V256c0-35.35-28.65-64-64-64zm-64 256H128v-96h256v96zm0-224H128V64h192v48c0 8.84 7.16 16 16 16h48v96zm48 72c-13.25 0-24-10.75-24-24 0-");
            WriteLiteral(@"13.26 10.75-24 24-24s24 10.74 24 24c0 13.25-10.75 24-24 24z""></path></svg><!-- <span class=""fas fa-print mr-1""> </span> Font Awesome fontawesome.com -->Print</button>
                </div>
            </div>
        </div>
    </div>
    <div class=""card mb-3"">
        <div class=""card-body"">
            <div class=""row align-items-center text-center mb-3"">
                <div class=""col-sm-6 text-sm-left"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "fe28e3a17b4346823b9295795d9f930f356683a97639", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</div>
                <div class=""col-sm-auto ml-auto"">
                    <div class=""table-responsive"">
                        <table class=""table table-sm table-borderless fs--1"">
                            <tbody>
                                <tr>
                                    <th class=""text-sm-right"">Date:</th>
                                    <td> ");
#nullable restore
#line 30 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                                    Write(DateTime.Now.ToString("yyyy\\/MM\\/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class=""col-12"">
                    <hr>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-md-3"">
                    <h5>Happy Valley Kennels</h5>
                    <p>123 Chemin Scott</p>
                    <p>Chelsea, QC J9B 1R6</p>
                    <p>(819) 123-4567</p>
                    <p>info@happyvalleykennel.ca</p>
                </div>
                <div class=""col-md-7""><h2 class=""text-primary text-center"">TO:</h2></div>
                <div class=""col-md-2"">
                    <h5>");
#nullable restore
#line 50 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                   Write(Html.DisplayFor(model => model.Pet.Owner.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 50 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                                                                        Write(Html.DisplayFor(model => model.Pet.Owner.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p>");
#nullable restore
#line 51 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                  Write(Html.DisplayFor(model => model.Pet.Owner.Street));

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 51 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                                                                     Write(Html.DisplayFor(model => model.Pet.Owner.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p>");
#nullable restore
#line 52 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                  Write(Model.Pet.Owner.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
            <div class=""row"">
                <table class=""table"">
                    <thead class=""thead-light"">
                        <tr>
                            <th>Reservation Start</th>
                            <th>Reservation End</th>
                            <th>Number of Days</th>
                            <th>Payment Terms</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>");
#nullable restore
#line 67 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                           Write(Html.DisplayFor(model => model.Reservation.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 68 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                           Write(Html.DisplayFor(model => model.Reservation.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 69 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                           Write(Html.DisplayFor(model => (model.Reservation.EndDate - model.Reservation.StartDate).Days));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                            <td>Due on receipt</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class=""row"">
                <table class=""table"">
                    <thead class=""thead-light"">
                        <tr>
                            <th>Description</th>
                            <th>Daily Rate</th>
                            <th>Number Of Days</th>
                            <th class=""align-middle text-right"">Item Total</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 86 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                         foreach (var petResService in Model.PetReservationService) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 88 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                               Write(petResService.Service.ServiceDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 89 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                               Write(petResService.Service.DailyRate.First().Rate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 90 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                               Write(Html.DisplayFor(model => (model.Reservation.EndDate - model.Reservation.StartDate).Days));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"align-middle text-right\">\r\n");
#nullable restore
#line 92 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                                      
                                        var total = petResService.Service.DailyRate.First().Rate * (Model.Reservation.EndDate - Model.Reservation.StartDate).Days;
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
#nullable restore
#line 95 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                           Write(total);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 98 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Invoice.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </tbody>
                </table>

            </div>
            <div class=""row no-gutters justify-content-end"">
                <div class=""col-auto"">
                    <table class=""table table-sm table-borderless fs--1 text-right"">
                        <tbody>
                            <tr>
                                <th class=""text-900"">Subtotal</th>
                                <td class=""font-weight-semi-bold"">$329.60</td>
                            </tr>
                            <tr>
                                <th class=""text-900"">Subtotal after discount</th>
                                <td class=""font-weight-semi-bold"">$306.53</td>
                            </tr>
                            <tr class=""border-top"">
                                <th class=""text-900"">HST</th>
                                <td class=""font-weight-semi-bold"">$45.98</td>
                            </tr>
                            <tr class=""borde");
            WriteLiteral(@"r-top border-2x font-weight-bold text-900"">
                                <th>Total</th>
                                <td class=""font-weight-semi-bold"">$352.51</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HVK_ZZTop.Models.PetReservation> Html { get; private set; }
    }
}
#pragma warning restore 1591
