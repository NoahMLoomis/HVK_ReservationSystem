#pragma checksum "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2cb9088642e7a6d0854f38ccd631ee67ef3f331"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clerk_Contract), @"mvc.1.0.view", @"/Views/Clerk/Contract.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2cb9088642e7a6d0854f38ccd631ee67ef3f331", @"/Views/Clerk/Contract.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"738470f597030531a491aa71dcc2154787568b3f", @"/Views/_ViewImports.cshtml")]
    public class Views_Clerk_Contract : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HVK_ZZTop.Models.PetReservation>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
  
    ViewData["Title"] = "Contract";

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2cb9088642e7a6d0854f38ccd631ee67ef3f3313760", async() => {
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
                    <h5 class=""mb-2 mb-md-0"">Boarding Contract</h5>
                    <p>
                        ");
#nullable restore
#line 13 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                   Write(DateTime.Now.ToString("yyyy\\/MM\\/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                </div>
                <div class=""col-auto"">
                    <button class=""btn btn-falcon-default btn-sm mr-2 mb-2 mb-sm-0"" type=""button""><svg class=""svg-inline--fa fa-print fa-w-16 mr-1"" aria-hidden=""true"" focusable=""false"" data-prefix=""fas"" data-icon=""print"" role=""img"" xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 512 512"" data-fa-i2svg=""""><path fill=""currentColor"" d=""M448 192V77.25c0-8.49-3.37-16.62-9.37-22.63L393.37 9.37c-6-6-14.14-9.37-22.63-9.37H96C78.33 0 64 14.33 64 32v160c-35.35 0-64 28.65-64 64v112c0 8.84 7.16 16 16 16h48v96c0 17.67 14.33 32 32 32h320c17.67 0 32-14.33 32-32v-96h48c8.84 0 16-7.16 16-16V256c0-35.35-28.65-64-64-64zm-64 256H128v-96h256v96zm0-224H128V64h192v48c0 8.84 7.16 16 16 16h48v96zm48 72c-13.25 0-24-10.75-24-24 0-13.26 10.75-24 24-24s24 10.74 24 24c0 13.25-10.75 24-24 24z""></path></svg><!-- <span class=""fas fa-print mr-1""> </span> Font Awesome fontawesome.com -->Print</button>
                </div>
            </div>
       ");
            WriteLiteral(" </div>\r\n    </div>\r\n    <div class=\"card mb-3\">\r\n        <div class=\"card-body\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-3\">\r\n                    <h5>Customer</h5>\r\n\r\n                    <h6>");
#nullable restore
#line 28 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                   Write(Html.DisplayFor(model => model.Pet.Owner.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 28 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                                                                        Write(Html.DisplayFor(model => model.Pet.Owner.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n\r\n                    <p>");
#nullable restore
#line 30 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                  Write(Html.DisplayFor(model => model.Pet.Owner.Street));

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 30 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                                                                     Write(Html.DisplayFor(model => model.Pet.Owner.City));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

                </div>
                <div class=""col-md-6""></div>
                <div class=""col-md-3"">
                    <dl>
                        <dt>Emergency Contact</dt>
                        <dd>
                            <dl class=""row"">
                                <dt class=""col-sm-6"">
                                    Name:
                                </dt>
                                <dd class=""col-sm-8"">");
#nullable restore
#line 42 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                                                Write(Html.DisplayFor(model => model.Pet.Owner.EmergencyContactFirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 42 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                                                                                                                     Write(Html.DisplayFor(model => model.Pet.Owner.EmergencyContactLastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n                                <dt class=\"col-sm-6\">\r\n                                    Phone:\r\n                                </dt>\r\n                                <dd class=\"col-sm-8\">");
#nullable restore
#line 46 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                                                Write(Html.DisplayFor(model => model.Pet.Owner.EmergencyContactPhone));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</dd>
                            </dl>
                        </dd>
                    </dl>
                </div>
            </div>

        </div>
    </div>
    <div class=""card mb-3"">
        <div class=""card-body"">
            <div class=""row"">
                <dl class=""col-md-12"">
                    <dt class=""col-md-12"">Reservation</dt>
                    <dd class=""col-md-12"">
                        <dl class=""row"">
                            <dt class=""col-md-2"">");
#nullable restore
#line 62 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                                            Write(Html.DisplayNameFor(model => model.Reservation.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n                            <dd class=\"col-md-2\">");
#nullable restore
#line 63 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                                            Write(Html.DisplayFor(model => model.Reservation.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n                            <dt class=\"col-md-2\">");
#nullable restore
#line 64 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                                            Write(Html.DisplayNameFor(model => model.Reservation.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n                            <dd class=\"col-md-2\">");
#nullable restore
#line 65 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                                            Write(Html.DisplayFor(model => model.Reservation.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n                            <dt class=\"col-md-2\">Days</dt>\r\n                            <dd class=\"col-md-2\">");
#nullable restore
#line 67 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                                            Write(Html.DisplayFor(model => (model.Reservation.EndDate - model.Reservation.StartDate).Days));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</dd>
                        </dl>
                    </dd>
                </dl>
            </div>
        </div>
    </div><div class=""card mb-3"">
        <div class=""card-body"">
            <div class=""row"">
                <div class=""col-md-5 data-table"">Pet</div>
                <div class=""col-md-2 data-table""></div>
                <div class=""col-md-5 data-table"">Service</div>
            </div>
            <div class=""row"">
                <table class=""table col-md-5"">
                    <tr>
                        <td>
                            ");
#nullable restore
#line 84 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                       Write(Html.DisplayNameFor(model => model.Pet.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 87 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                       Write(Html.DisplayFor(model => model.Pet.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 92 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                       Write(Html.DisplayNameFor(model => model.Pet.DogSize));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 95 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                       Write(Html.DisplayFor(model => model.Pet.DogSize));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 100 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                       Write(Html.DisplayNameFor(model => model.Pet.SpecialNotes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 103 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                       Write(Html.DisplayFor(model => model.Pet.SpecialNotes));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </td>
                    </tr>
                </table>
                <div class=""col-md-2""></div>
                <table class=""table col-md-5 thead-light"">
                    <thead>
                        <tr>
                            <th>
                                Service Name
                            </th>
                            <th>
                                Daily Rate
                            </th>
                            <th>
                                Times
                            </th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 124 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                         foreach (var item in Model.PetReservationService) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 127 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Service.ServiceDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 130 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Service.DailyRate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 135 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Contract.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>

            </div>
            <div>
                <dl>
                    <dt>Customer Discounts:</dt>
                    <dd>Three or more dogs brought in (7%)</dd>
                </dl>
            </div>
        </div>
    </div>
    <div class=""card-footer bg-light"">
        <p class=""fs--1 mb-0"">
            <strong>Notes: </strong>I understand and agree to the terms and conditions of this contract (see
            reverse side) and agree that Happy Valley Kennels is not liable for loss
            or illness of my pet.
        </p>
    </div>

    <div class=""text-right fs--0"">
        Signature of Owner: ____________________ Date: ____________________
       
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