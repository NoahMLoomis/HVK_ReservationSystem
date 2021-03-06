#pragma checksum "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c35e0310803da706f2edb7fae1c1e1b25b17d87c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clerk_Index), @"mvc.1.0.view", @"/Views/Clerk/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c35e0310803da706f2edb7fae1c1e1b25b17d87c", @"/Views/Clerk/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"738470f597030531a491aa71dcc2154787568b3f", @"/Views/_ViewImports.cshtml")]
    public class Views_Clerk_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HVK_ZZTop.Models.PetReservation>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
  
    ViewData["Title"] = "Clerk Home";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""card mb-3"">
    <div class=""card-header"">
        <h5 class=""card-title mb-0"">Checking In Today</h5>
    </div>
    <div id=""datatables-dashboard-projects_wrapper"" class=""dataTables_wrapper dt-bootstrap4 no-footer"">
        <div class=""row"">
            <div class=""col-sm-12"">
                <table id=""datatables-dashboard-projects"" class=""table table-striped my-0 dataTable no-footer"" role=""grid"" aria-describedby=""datatables-dashboard-projects_info"">
                    <thead>
                        <tr role=""row"">
                            <th>
                                ");
#nullable restore
#line 19 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.ReservationId));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </th>
                            <th>
                                Owner
                            </th>
                            <th>
                                Pet
                            </th>


                            <th>
                                ");
#nullable restore
#line 30 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Reservation.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 33 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Reservation.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 36 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Reservation.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n\r\n\r\n                            <th></th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 44 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                         foreach (var item in Model.Where(r => r.Reservation.StartDate == DateTime.Today).Where(r => r.Reservation.Status == 1)) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 47 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.ReservationId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 50 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Pet.Owner.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 50 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                                                                                       Write(Html.DisplayFor(modelItem => item.Pet.Owner.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 53 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Pet.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n\r\n                                <td>\r\n                                    ");
#nullable restore
#line 58 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Reservation.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 61 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Reservation.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 64 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                                Write((HVK_ZZTop.Models.ReservationStatus) Convert.ToInt32(item.Reservation.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td class=\"text-right\">\r\n                                    ");
#nullable restore
#line 68 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.ActionLink("Check In", "CheckIn", new { id = item.PetReservationId }, new { @class = "btn btn-warning btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 71 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>

<div class=""card mb-3"">
    <div class=""card-header"">
        <h5 class=""card-title mb-0"">Checking Out Today</h5>
    </div>
    <div id=""datatables-dashboard-projects_wrapper"" class=""dataTables_wrapper dt-bootstrap4 no-footer"">
        <div class=""row"">
            <div class=""col-sm-12"">
                <table id=""datatables-dashboard-projects"" class=""table table-striped my-0 dataTable no-footer"" role=""grid"" aria-describedby=""datatables-dashboard-projects_info"">
                    <thead>
                        <tr role=""row"">
                            <th>
                                ");
#nullable restore
#line 90 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.ReservationId));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </th>
                            <th>
                                Owner
                            </th>
                            <th>
                                Pet
                            </th>
                            <th>
                                ");
#nullable restore
#line 99 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Reservation.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 102 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Reservation.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 105 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Reservation.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n\r\n\r\n                            <th></th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 113 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                         foreach (var item in Model.Where(r => r.Reservation.EndDate == DateTime.Today)) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 116 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.ReservationId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 119 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Pet.Owner.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 119 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                                                                                       Write(Html.DisplayFor(modelItem => item.Pet.Owner.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 122 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Pet.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n\r\n                                <td>\r\n                                    ");
#nullable restore
#line 127 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Reservation.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 130 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Reservation.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 133 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                                Write((HVK_ZZTop.Models.ReservationStatus) Convert.ToInt32(item.Reservation.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td class=\"text-right\">\r\n                                    ");
#nullable restore
#line 137 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.ActionLink("Check Out", "CheckOut", new { id = item.PetReservationId }, new { @class = "btn btn-warning btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 140 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>

<div class=""card mb-3"">
    <div class=""card-header"">
        <h5 class=""card-title mb-0"">Active Reservations</h5>
    </div>
    <div id=""datatables-dashboard-projects_wrapper"" class=""dataTables_wrapper dt-bootstrap4 no-footer"">
        <div class=""row"">
            <div class=""col-sm-12"">
                <table id=""datatables-dashboard-projects"" class=""table table-striped my-0 dataTable no-footer"" role=""grid"" aria-describedby=""datatables-dashboard-projects_info"">
                    <thead>
                        <tr role=""row"">
                            <th>
                                ");
#nullable restore
#line 159 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.ReservationId));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </th>
                            <th>
                                Owner
                            </th>
                            <th>
                                Pet
                            </th>

                            <th>
                                ");
#nullable restore
#line 169 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Reservation.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 172 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Reservation.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 175 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Reservation.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 180 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                         foreach (var item in Model.Where(r => r.Reservation.Status == 3)) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 183 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.ReservationId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 186 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Pet.Owner.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 186 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                                                                                       Write(Html.DisplayFor(modelItem => item.Pet.Owner.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 189 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Pet.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n\r\n                                <td>\r\n                                    ");
#nullable restore
#line 194 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Reservation.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 197 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Reservation.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td class=\"text-right\">\r\n                                    ");
#nullable restore
#line 200 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                                Write((HVK_ZZTop.Models.ReservationStatus) Convert.ToInt32(item.Reservation.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 203 "C:\Users\nloom\OneDrive\Documents\4thSemester\Web_V\Assignments\HVK_ZZTop\HVK_ZZTop\Views\Clerk\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HVK_ZZTop.Models.PetReservation>> Html { get; private set; }
    }
}
#pragma warning restore 1591
