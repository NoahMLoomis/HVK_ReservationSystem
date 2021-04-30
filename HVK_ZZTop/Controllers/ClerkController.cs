using HVK_ZZTop.Models;
using HVK_ZZTop.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ZZTop_HVK.Controllers {
    [Authorize(Roles = Role.Clerk)]
    public class ClerkController : Controller {
        private readonly ILogger<CustomerController> _logger;

        private readonly HVK_ZZTopContext _context;

        public ClerkController(ILogger<CustomerController> logger, HVK_ZZTopContext context) {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() {
            var result = _context.PetReservation.Include(r => r.Reservation).Include(p => p.Pet).ThenInclude(p => p.Owner).OrderBy(p => p.Pet.Name).ToList();
            return View(result);
        }

        public IActionResult CheckIn(int id) {
            var model = _context.PetReservation.Where(r => r.PetReservationId == id)
                .Include(x => x.Reservation)
                .Include(x => x.Pet)
                .ThenInclude(x => x.Owner)
                .OrderBy(p => p.Pet.Name)
                .FirstOrDefault();

            ViewBag.Vaccinations = _context.Vaccination.ToList();
            ViewBag.PetVaccinations = _context.PetVaccination.Where(x => x.PetId == model.PetId);


            return View(model);
        }

        [HttpPost]
        public IActionResult CheckIn(int id, IFormCollection form) {




            ViewBag.Vaccinations = _context.Vaccination.ToList();
            var checkedIds = form["VaccinationChecked"].ToList();

            List<PetVaccination> petVaccinations = new List<PetVaccination>();
            ViewBag.PetVaccinations = petVaccinations;

            bool allVaccines = false;
            bool anyVacExpired = false;

            foreach (var vac in ViewBag.Vaccinations) {
                DateTime expiryDate;

                bool vaccinationChecked = checkedIds.Contains(vac.VaccinationId.ToString());

                if (DateTime.TryParse(form["Vaccination:" + vac.VaccinationId], out expiryDate)) {
                    PetVaccination pv = new PetVaccination();
                    pv.VaccinationId = vac.VaccinationId;
                    pv.ExpiryDate = expiryDate;
                    pv.VaccinationChecked = vaccinationChecked;
                    petVaccinations.Add(pv);
                    if (expiryDate < DateTime.Today) {
                        anyVacExpired = true;
                    }
                }
            }


            if (checkedIds.Count() >= 6) {
                allVaccines = true;
            }

            if (!allVaccines || anyVacExpired) {
                return RedirectToAction("CheckIn", new { id = id });
            } else {

                var petRes = _context.PetReservation.Find(id);
                var res = _context.Reservation.Find(petRes.ReservationId);
                var pet = _context.Pet.Find(petRes.PetId);
                var petVacs = _context.PetVaccination.Where(x => x.PetId == pet.PetId).ToList();

                res.Status = 3;

                foreach (var singlePetVac in petVacs) {
                    singlePetVac.VaccinationChecked = true;
                    _context.PetVaccination.Update(singlePetVac);
                }
                _context.Reservation.Update(res);
                _context.Pet.Update(pet);
                _context.SaveChanges();
                return RedirectToAction("Contract", new { id = id });
            }
        }

        public IActionResult Contract(int id) {
            var model = _context.PetReservation.Where(r => r.PetReservationId == id)
                .Include(x => x.Reservation)
                .Include(x => x.Pet)
                .ThenInclude(x => x.Owner)
                .Include(x => x.PetReservationDiscount)
                .ThenInclude(x => x.Discount)
                .Include(x => x.PetReservationService)
                .ThenInclude(x => x.Service)
                .FirstOrDefault();

            return View(model);
        }


        public IActionResult CheckOut(int id) {
            var model = _context.PetReservation.Where(r => r.PetReservationId == id)
                .Include(x => x.Reservation)
                .Include(x => x.Pet)
                .ThenInclude(x => x.Owner).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public IActionResult CheckOut(int id, IFormCollection collection) {
            var model = _context.PetReservation.Where(r => r.PetReservationId == id)
                .Include(x => x.Reservation)
                .FirstOrDefault();

            var res = _context.Reservation.Where(x => x.ReservationId == model.Reservation.ReservationId).FirstOrDefault();

            res.Status = 5;

            _context.Reservation.Update(res);
            _context.SaveChanges();

            return RedirectToAction("Invoice", new { id = id });
        }

        public IActionResult Invoice(int id) {
            var model = _context.PetReservation.Where(r => r.PetReservationId == id)
                .Include(x => x.Reservation)
                .ThenInclude(x => x.ReservationDiscount)
                .Include(x => x.Pet)
                .ThenInclude(x => x.Owner)
                .Include(x => x.PetReservationDiscount)
                .ThenInclude(x => x.Discount)
                .Include(x => x.PetReservationService)
                .ThenInclude(x => x.Service)
                .ThenInclude(x => x.DailyRate)
                .FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public IActionResult Search(string SearchInput) {
            if (SearchInput.Contains('@')) {
                var result = _context.Owner
                             .Where(o => o.Email.ToLower() == SearchInput.ToLower())
                             .FirstOrDefault();
                if (result == null) {
                    return RedirectToAction("NoResult", new { message = "No Owners were found that were associated with the email " + SearchInput });
                } else {
                    return RedirectToAction("CustomerSearch", result);
                }
            } else if (((SearchInput.Contains('-') || SearchInput.Contains('(') || SearchInput.Contains(')') || SearchInput.Contains(' ')) && SearchInput.Any(char.IsDigit)) || SearchInput.All(char.IsDigit)) {
                string phoneNumber = SearchInput.Replace(" ", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Replace(".", string.Empty);
                var result = _context.Owner
                             .Where(o => o.Phone == phoneNumber || o.CellPhone == phoneNumber)
                             .FirstOrDefault();
                if (result == null) {
                    return RedirectToAction("NoResult", new { message = "No Owners were found that were associated with the phone number " + SearchInput });
                } else {
                    return RedirectToAction("CustomerSearch", result);
                }
            } else if (SearchInput.Contains('/') && SearchInput.Length == 10) {
                int year = Int32.Parse(SearchInput.Substring(0, 4));
                int month = Int32.Parse(SearchInput.Substring(5, 2));
                int day = Int32.Parse(SearchInput.Substring(8, 2));
                DateTime date = new DateTime(year, month, day);
                int[] result = _context.Reservation
                             .Where(r => r.StartDate == date)
                             .Select(r => r.ReservationId)
                             .ToArray();
                if (result == null) {
                    return RedirectToAction("NoResult", new { message = "No Reservations were found that start on the date " + SearchInput });
                } else {
                    return RedirectToAction("ReservationSearch", new { resList = result });
                }
            } else {
                return RedirectToAction("NoResult", new { message = "No Owners or Reservation were found for the input \"" + SearchInput + "\". To search for owners please enter the owner's email address or phone number, and for reservations please enter the reservation's start date as yyyy/mm/dd." });
            }
        }

        public IActionResult NoResult(string message) {
            ViewBag.Message = message;
            return View();
        }

        public IActionResult CustomerSearch(Owner owner) {

            ViewBag.Vaccinations = _context.Vaccination.ToList();

            var ownerWithVet = _context.Owner
               .Include(o => o.Veterinarian)
               .Where(o => o.OwnerId == owner.OwnerId)
               .FirstOrDefault();

            var pets = _context.Pet
                .Include(p => p.PetVaccination)
                .ThenInclude(v => v.Vaccination)
                .Where(p => p.OwnerId == owner.OwnerId)
                .OrderBy(p => p.Name)
                .ToList();

            var petRes = _context.PetReservation
                .Include(p => p.Reservation)
                .Include(p => p.Pet)
                .Include(p => p.Medication)
                .Include(p => p.PetReservationService)
                .Where(p => p.Pet.Owner.OwnerId == owner.OwnerId)
                .OrderBy(p => p.Reservation.StartDate)
                .ToList();

            CustomerSearchViewModel result = new CustomerSearchViewModel { Owner = ownerWithVet, Pets = pets, PetReservations = petRes };
            return View(result);
        }

        public IActionResult ReservationSearch(int[] resList) {

            List<PetReservation> tempPetResList = _context.PetReservation
                .Include(p => p.Reservation)
                .Include(p => p.Pet)
                .ThenInclude(p => p.Owner)
                .Include(p => p.Medication)
                .Include(p => p.PetReservationService)
                .OrderBy(p => p.Reservation.StartDate)
                .ToList();

            List<PetReservation> petResList = new List<PetReservation>();


            foreach (var resId in resList) {
                foreach (var petRes in tempPetResList) {
                    if (resId == petRes.ReservationId)
                        petResList.Add(petRes);
                }
            }


            List<PetReservation> SortedList = petResList.OrderBy(p => p.Pet.Owner.FirstName).ToList();
            return View(SortedList);
        }
    }
}
