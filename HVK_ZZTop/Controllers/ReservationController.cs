//Kyle Radmore
//420-H50
//ReservationController.cs
//Reservation Controller used for the reservation routing

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HVK_ZZTop.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;


namespace ZZTop_HVK.Controllers {
    [Route("Reservation")]
    [Authorize]
    public class ReservationController : Controller {

        private readonly ILogger<ReservationController> _logger;
        private readonly HVK_ZZTopContext _context;

        public ReservationController(ILogger<ReservationController> logger, HVK_ZZTopContext context) {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index(int? id) {
            var ownerId = (int)HttpContext.Session.GetInt32("ownerId");

            var result = _context.PetReservation
                .Include(r => r.Reservation)
                .Include(r => r.Pet)
                .Where(r => r.Pet.OwnerId == ownerId);

            return View(result);

        }


        [HttpGet, Route("Create")]
        public IActionResult Create(int? id) {
            var ownerId = (int)HttpContext.Session.GetInt32("ownerId");


            ViewData["Pets"] = _context.Pet.Where(p => p.OwnerId == ownerId).ToList();
            ViewData["Services"] = _context.Service.Where(p => p.ServiceId != 1).ToList();

            return View();
        }


        [HttpPost, Route("Create")]
        public IActionResult Create(int? id, PRSMR model, int? Pet_1, int? Pet_2, int? Pet_3) {
            var ownerId = (int)HttpContext.Session.GetInt32("ownerId");
            List<int?> petIds = new List<int?>();
            List<PetReservation> petReservations = new List<PetReservation>();
            if (Pet_1 != null) {
                petIds.Add(Pet_1);
            }
            if (Pet_2 != null) {
                petIds.Add(Pet_2);
            }
            if (Pet_3 != null) {
                petIds.Add(Pet_3);
            }
            ViewData["Pets"] = _context.Pet.Where(p => p.OwnerId == ownerId).ToList();


            if (!ModelState.IsValid) {
                return View(model);
            } else {
                var transaction = _context.Database.BeginTransaction();
                var resId = _context.Reservation.Max(p => p.ReservationId) + 1;
                Reservation res = model.PetReservation.Reservation;
                res.ReservationId = resId;
                _context.Reservation.Add(res);
                _context.Database.ExecuteSqlInterpolated($"USE HVK_ZZTop SET IDENTITY_INSERT dbo.Reservation ON;");
                _context.SaveChanges();
                _context.Database.ExecuteSqlInterpolated($"USE HVK_ZZTop SET IDENTITY_INSERT dbo.Reservation OFF;");
                foreach (int petid in petIds) {
                    PetReservation petRes = new PetReservation();

                    var petResId = _context.PetReservation.Max(p => p.PetReservationId) + 1;

                    petRes.ReservationId = resId;

                    petRes.PetId = petid;

                    petRes.PetReservationId = petResId;


                    petRes.PetReservationService.Add(new PetReservationService { ServiceId = 1 });

                    if (model.Walk) {
                        petRes.PetReservationService.Add(new PetReservationService { ServiceId = 2 });
                    }

                    if (model.PlayTime) {
                        petRes.PetReservationService.Add(new PetReservationService { ServiceId = 5 });
                    }

                    if (model.Medication.Name != null) {
                        var medId = _context.Medication.Max(p => p.MedicationId) + 1;
                        petRes.PetReservationService.Add(new PetReservationService { ServiceId = 4 });
                        model.Medication.MedicationId = medId;
                        _context.Medication.Add(model.Medication);
                        _context.Database.ExecuteSqlInterpolated($"USE HVK_ZZTop SET IDENTITY_INSERT dbo.Medication ON;");
                        _context.SaveChanges();
                        _context.Database.ExecuteSqlInterpolated($"USE HVK_ZZTop SET IDENTITY_INSERT dbo.Medication OFF;");
                    }
                    _context.PetReservation.Add(petRes);
                    _context.Database.ExecuteSqlInterpolated($"USE HVK_ZZTop SET IDENTITY_INSERT dbo.PetReservation ON;");
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlInterpolated($"USE HVK_ZZTop SET IDENTITY_INSERT dbo.PetReservation OFF");
                }
                transaction.Commit();

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet, Route("Edit")]
        public ActionResult Edit(int? id) {
            bool W = false;
            bool P = false;
            Medication PetResMedication = new Medication();

            ViewData["Services"] = _context.Service.Where(p => p.ServiceId != 1).ToList();
            ViewData["PetServices"] = _context.PetReservationService
                                        .Where(p => p.PetReservationId == id).ToList();

            var petRes = _context.PetReservation
                .Include(p => p.Reservation)
                .Include(p => p.Pet)
                .Include(p => p.Medication)
                .Include(p => p.PetReservationService)
                .Where(p => p.PetReservationId == id)
                .FirstOrDefault();


            if (petRes.PetReservationService.Count() > 1) {
                foreach (var serv in petRes.PetReservationService) {
                    if (serv.ServiceId == 2) {
                        W = true;
                    }
                    if (serv.ServiceId == 5) {
                        P = true;
                    }
                }
            }


            if (petRes.Medication.Count() > 0) {
                foreach (var med in petRes.Medication) {
                    PetResMedication = med;
                }
            }

            EditReservationViewModel model = new EditReservationViewModel { PetReservation = petRes, Medication = PetResMedication, Walk = W, PlayTime = P };

            return View(model);
        }

        [HttpPost, Route("Edit")]
        public ActionResult Edit(int id, EditReservationViewModel model) {
            ViewData["Services"] = _context.Service.Where(p => p.ServiceId != 1).ToList();
            ViewData["PetServices"] = _context.PetReservationService
                                .Where(p => p.PetReservationId == id).ToList();

            if (!ModelState.IsValid) {
                return View(model);
            } else {

                model.PetReservation.PetReservationService.Add(new PetReservationService { PetReservationId = model.PetReservation.PetReservationId, ServiceId = 1 });

                if (_context.PetReservationService.Where(p => p.PetReservationId == model.PetReservation.PetReservationId && p.ServiceId == 2).Count() != 0) {
                    _context.PetReservationService.Remove(new PetReservationService { PetReservationId = model.PetReservation.PetReservationId, ServiceId = 2 });
                }

                if (model.Walk) {
                    _context.PetReservationService.Add(new PetReservationService { PetReservationId = model.PetReservation.PetReservationId, ServiceId = 2 });
                }

                if (_context.PetReservationService.Where(p => p.PetReservationId == model.PetReservation.PetReservationId && p.ServiceId == 5).Count() != 0) {
                    _context.PetReservationService.Remove(new PetReservationService { PetReservationId = model.PetReservation.PetReservationId, ServiceId = 5 });
                }

                if (model.PlayTime) {
                    _context.PetReservationService.Add(new PetReservationService { PetReservationId = model.PetReservation.PetReservationId, ServiceId = 5 });
                }

                if (_context.PetReservationService.Where(p => p.PetReservationId == model.PetReservation.PetReservationId && p.ServiceId == 4).Count() != 0) {
                    _context.PetReservationService.Remove(new PetReservationService { PetReservationId = model.PetReservation.PetReservationId, ServiceId = 4 });
                    if (_context.Medication.Where(m => m.PetReservationId == model.PetReservation.PetReservationId).Count() != 0) {
                        _context.Medication.Remove(model.Medication);
                    }
                }

                if (model.Medication.Name != null) {
                    _context.PetReservationService.Add(new PetReservationService { PetReservationId = model.PetReservation.PetReservationId, ServiceId = 4 });
                    if (model.Medication.MedicationId != 0) {
                        _context.Medication.Update(model.Medication);
                    } else {
                        _context.Medication.Add(model.Medication);
                    }
                }


                _context.PetReservation.Update(model.PetReservation);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }


        [Route("Details")]
        public ActionResult Details(int id) {

            var model = _context.PetReservation
                .Include(p => p.Reservation)
                .Include(p => p.Pet)
                .Include(p => p.Medication)
                .Include(p => p.PetReservationService)
                .Where(p => p.PetReservationId == id)
                .FirstOrDefault();

            return View(model);
        }


        [Route("Delete")]
        public ActionResult Delete(int? id) {

            var model = _context.PetReservation
                .Include(p => p.Reservation)
                .Include(p => p.Pet)
                .Include(p => p.Medication)
                .Include(p => p.PetReservationService)
                .Where(p => p.PetReservationId == id)
                .FirstOrDefault();

            if (model.Reservation.Status == 3) {
                ViewBag.DeleteDenied = true;
            }
            return View(model);
        }

        [HttpPost, Route("Delete")]
        public ActionResult Delete(int id) {
            //try {
            Reservation res = _context.Reservation.Find(id);
            List<PetReservation> petRes = _context.PetReservation.Where(pr => pr.ReservationId == id).ToList();
            List<PetReservationService> servs = new List<PetReservationService>();
            foreach (var item in petRes) {
                List<PetReservationService> servsTemp = _context.PetReservationService.Where(prs => prs.PetReservationId == item.PetReservationId).ToList();
                foreach (var serv in servsTemp) {
                    servs.Add(serv);
                }
            }
            List<Medication> meds = new List<Medication>();
            foreach (var item in petRes) {
                List<Medication> medsTemp = _context.Medication.Where(prs => prs.PetReservationId == item.PetReservationId).ToList();
                foreach (var med in medsTemp) {
                    meds.Add(med);
                }
            }

            if (meds.Count() > 0) {
                foreach (var med in meds) {
                    _context.Medication.Remove(med);
                }
            }

            foreach (var serv in servs) {
                _context.PetReservationService.Remove(serv);
            }

            foreach (var item in petRes) {
                _context.Remove(item);
            }

            _context.Remove(res);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
