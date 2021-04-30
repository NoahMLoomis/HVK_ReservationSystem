using HVK_ZZTop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HVK_ZZTop.Controllers {
    //[Authorize]
    public class CustomerController : Controller {
        private readonly ILogger<CustomerController> _logger;
        private readonly HVK_ZZTopContext _context;

        public CustomerController(ILogger<CustomerController> logger, HVK_ZZTopContext context) {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(int id) {
            if (id == 0) {
                //currently logged in user (customer or clerk)

                id = (int)HttpContext.Session.GetInt32("ownerId");
            }

            //Using sessions now, might need to delete this identity stuff

            //get current user/owner information
            ViewBag.Customer = await _context.Owner
                .Include(o => o.Veterinarian)
                .Where(o => o.OwnerId == id)
                .FirstOrDefaultAsync();

            ViewBag.Pets = _context.Pet.Where(p => p.OwnerId == id).ToList();

            var result = _context.Reservation.Include(r => r.PetReservation).Where(r => r.PetReservation.First().Pet.OwnerId == id).OrderBy(r => r.StartDate).ToListAsync();

            return View(await result);
        }

        public async Task<IActionResult> Create() {
            Veterinarian tempVet = new Veterinarian();
            var veterinarians = await tempVet.GetVeterinarians();
            ViewData["VetList"] = new SelectList(veterinarians, "VeterinarianId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Owner model) {
            if (!ModelState.IsValid) {
                Veterinarian tempVet = new Veterinarian();
                var veterinarians = await tempVet.GetVeterinarians();
                ViewData["VetList"] = new SelectList(veterinarians, "VeterinarianId", "Name");
                return View(model);
            } else {
                if (model.Phone != null) {
                    model.Phone = model.Phone.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Replace(".", string.Empty);
                }
                if (model.CellPhone != null) {
                    model.CellPhone = model.CellPhone.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Replace(".", string.Empty);
                }
                if (model.PostalCode != null) {
                    model.PostalCode = model.PostalCode.Replace(" ", string.Empty).Replace("-", string.Empty);
                }
                if (model.VeterinarianId != 0) {
                    model.Veterinarian = null;
                } else {
                    if (model.Veterinarian.Name == null) {
                        model.Veterinarian = null;
                    }
                    model.VeterinarianId = null;
                }
                _context.Owner.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Login", "Home");
            }
        }

        public async Task<IActionResult> Edit(int ownerId) {
            Veterinarian tempVet = new Veterinarian();
            var veterinarians = await tempVet.GetVeterinarians();
            ViewData["VetList"] = new SelectList(veterinarians, "VeterinarianId", "Name");
            var model = _context.Owner.Where(o => o.OwnerId == ownerId).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Owner model) {
            if (!ModelState.IsValid) {
                Veterinarian tempVet = new Veterinarian();
                var veterinarians = await tempVet.GetVeterinarians();
                ViewData["VetList"] = new SelectList(veterinarians, "VeterinarianId", "Name");
                return View(model);
            } else {
                if (model.Phone != null) {
                    model.Phone = model.Phone.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Replace(".", string.Empty);
                }
                if (model.CellPhone != null) {
                    model.CellPhone = model.CellPhone.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Replace(".", string.Empty);
                }
                if (model.PostalCode != null) {
                    model.PostalCode = model.PostalCode.Replace(" ", string.Empty).Replace("-", string.Empty);
                }
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Details", new { @id = model.OwnerId });
            }
        }
        public async Task<IActionResult> Details(int id) {
            //Need to add this because the user can go straight from the Login page to Details without logging in if previously logged in
            if (id == 0) {
                //currently logged in user (customer or clerk)
                id = (int)HttpContext.Session.GetInt32("ownerId");
            } else {
                HttpContext.Session.SetInt32("ownerId", id);
            }

            Owner model = await _context.Owner
                .Include(o => o.Veterinarian)
                .Where(o => o.OwnerId == id)
                .FirstOrDefaultAsync();
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var owner = await _context.Owner
                .FirstOrDefaultAsync(m => m.OwnerId == id);
            if (owner == null) {
                return NotFound();
            }

            return View(owner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var owner = await _context.Owner.FindAsync(id);

            var reservations = _context.Reservation.Where(r => r.PetReservation.First().Pet.OwnerId == id);
            var activeReservation = reservations.FirstOrDefault(r => r.Status == (decimal)ReservationStatus.Active);

            // Does Customer have Active Reservation
            if (activeReservation != null) {
                ViewBag.DeleteDenied = true;
                return View(owner);

            } else {
                _context.Owner.Remove(owner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

        }


        public async Task<IActionResult> List() {
            var result = _context.Owner.Include(o => o.Pet).Include(o => o.Veterinarian).OrderBy(o => o.FirstName).ToListAsync();
            return View(await result);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
