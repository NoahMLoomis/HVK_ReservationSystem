using HVK_ZZTop.Controllers;
using HVK_ZZTop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HVK.Controllers {
    [Authorize]
    public class PetController : Controller {
        private readonly ILogger<PetController> _logger;
        private readonly HVK_ZZTopContext _context;

        public PetController(ILogger<PetController> logger, HVK_ZZTopContext context) {
            _logger = logger;
            _context = context;
        }

        public ActionResult Index() {
            var userId = (int)HttpContext.Session.GetInt32("ownerId");

            ViewBag.Vaccinations = _context.Vaccination.ToList();

            var result = _context.Pet
                .Include(p => p.PetVaccination)
                .ThenInclude(v => v.Vaccination)
                .Where(p => p.OwnerId == userId)
                .OrderBy(p => p.Name)
                .ToList();

            return View(result);
        }

        public ActionResult Details(int id) {
            ViewBag.Vaccinations = _context.Vaccination.ToList();

            var pet = _context.Pet
                .Include(p => p.PetVaccination)
                .ThenInclude(v => v.Vaccination)
                .Where(p => p.PetId == id).FirstOrDefault();
            return View(pet);
        }

        public ActionResult Create(int? ownerId) {
            int userId = Convert.ToInt32(User.Identity.Name);

            // current user is owenr if not specified;
            if (ownerId == null)
                ownerId = userId;

            // only clerk can create pets for customer
            if (!User.IsInRole("Clerk") && userId != ownerId) {
                return Forbid();
            }

            ViewBag.Vaccinations = _context.Vaccination.ToList();

            ViewBag.Owner = _context.Owner.Find(ownerId);

            return View();
        }

        [HttpPost]
        public ActionResult Create(Pet model, int? ownerId, IFormCollection form) {

            int userId = Convert.ToInt32(User.Identity.Name);

            if (ownerId == null)
                ownerId = userId;

            if (!User.IsInRole("Clerk") && userId != ownerId) {
                return Forbid();
            }

            ViewBag.Vaccinations = _context.Vaccination.ToList();
            ViewBag.Owner = _context.Owner.Find(ownerId);

            model.OwnerId = ownerId.Value;

            var vaccinations = _context.Vaccination.ToList();
            ViewBag.Vaccinations = vaccinations;

            var checkedIds = form["VaccinationChecked"].ToList();

            List<PetVaccination> petVaccinations = new List<PetVaccination>();
            ViewBag.PetVaccinations = petVaccinations;


            foreach (var vac in vaccinations) {
                DateTime expiryDate;

                bool vaccinationChecked = checkedIds.Contains(vac.VaccinationId.ToString());

                if (DateTime.TryParse(form["Vaccination:" + vac.VaccinationId], out expiryDate)) {
                    PetVaccination pv = new PetVaccination();
                    petVaccinations.Add(pv);
                    pv.VaccinationId = vac.VaccinationId;
                    pv.ExpiryDate = expiryDate;
                    pv.VaccinationChecked = vaccinationChecked;
                }
            }

            if (!ModelState.IsValid) {
                return View(model);
            } else {
                try {
                    var owner = _context.Owner.Where(o => o.OwnerId == ownerId);
                    model.OwnerId = ownerId.Value;

                    _context.Pet.Add(model);
                    _context.SaveChanges();

                    foreach (var pv in petVaccinations) {
                        pv.PetId = model.PetId;
                        _context.PetVaccination.Add(pv);
                    }

                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                } catch {
                    return View(model);
                }
            }
        }

        public ActionResult Edit(int id) {


            ViewBag.Vaccinations = _context.Vaccination.ToList();

            Pet model = _context.Pet.Include(p => p.PetVaccination)
                .ThenInclude(v => v.Vaccination).Where(p => p.PetId == id).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, Pet model, IFormCollection form) {
            var vaccinations = _context.Vaccination.ToList();
            ViewBag.Vaccinations = vaccinations;

            var checkedIds = form["VaccinationChecked"].ToList();

            foreach (var vac in vaccinations) {
                DateTime expiryDate;


                var pv = _context.PetVaccination.Where(pv => pv.VaccinationId == vac.VaccinationId && pv.PetId == model.PetId).FirstOrDefault();
                bool vaccinationChecked = checkedIds.Contains(vac.VaccinationId.ToString());
                if (!DateTime.TryParse(form["Vaccination:" + vac.VaccinationId], out expiryDate)) {
                    if (pv != null) {
                        _context.PetVaccination.Remove(pv);
                    }

                } else {
                    if (pv == null) {
                        pv = new PetVaccination();
                        pv.PetId = model.PetId;
                        pv.VaccinationId = vac.VaccinationId;
                        _context.PetVaccination.Add(pv);

                        pv.ExpiryDate = expiryDate;
                        pv.VaccinationChecked = vaccinationChecked;
                    } else {

                        pv.ExpiryDate = expiryDate;
                        pv.VaccinationChecked = vaccinationChecked;
                        _context.PetVaccination.Update(pv);
                    }
                }
            }

            if (!ModelState.IsValid) {
                model.PetVaccination = _context.PetVaccination.Where(pv => pv.PetId == model.PetId).ToList();
                return View(model);
            } else {
                try {
                    _context.Pet.Update(model);
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                } catch {
                    return View(model);
                }
            }
        }

        public ActionResult Delete(int id) {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
                Pet pet = _context.Pet.Find(id);
                _context.Remove(pet);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        public async Task<IActionResult> List() {
            var result = _context.Pet.Include(p => p.Owner).Include(p => p.PetVaccination).OrderBy(p => p.Name).ToListAsync();
            return View(await result);
        }

    }
}
