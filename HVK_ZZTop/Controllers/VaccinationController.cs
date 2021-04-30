using HVK_ZZTop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HVK_ZZTop.Controllers {
    [Authorize]
    public class VaccinationController : Controller {
        private readonly ILogger<VaccinationController> _logger;
        private readonly HVK_ZZTopContext _context;

        public VaccinationController(ILogger<VaccinationController> logger, HVK_ZZTopContext context) {
            _logger = logger;
            _context = context;
        }
        public ActionResult Edit(int id, int petId) {
            TempData["ReturnUrl"] = Request.Headers["Referer"].ToString();

            PetVaccination model = _context.PetVaccination
                .Include(pv => pv.Vaccination)
                .Where(pv => pv.VaccinationId == id && pv.PetId == petId)
                .FirstOrDefault();

            if (model == null) {
                model = new PetVaccination();
                model.Vaccination = _context.Vaccination.Where(v => v.VaccinationId == id).FirstOrDefault();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id, int petId, PetVaccination model) {

            if (!ModelState.IsValid) {
                return View(model);
            } else {
                model.VaccinationId = id;
                model.Vaccination = null;

                if (_context.PetVaccination.Any(pv => pv.VaccinationId == id && pv.PetId == petId)) {
                    _context.PetVaccination.Attach(model);
                    _context.Entry(model).State = EntityState.Modified;
                } else {
                    _context.PetVaccination.Add(model);
                }

                _context.SaveChanges();

                var url = TempData["ReturnUrl"];
                if (null == url)
                    return RedirectToAction("Details", "Pet", new { id = petId });
                else
                    return Redirect(url.ToString());
            }
        }
    }
}
