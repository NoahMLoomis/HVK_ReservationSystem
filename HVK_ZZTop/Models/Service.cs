using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class Service {
        private readonly HVK_ZZTopContext _context;

        public Service() {
            DailyRate = new HashSet<DailyRate>();
            PetReservationService = new HashSet<PetReservationService>();
            _context = new HVK_ZZTopContext();
        }

        public int ServiceId { get; set; }
        public string ServiceDescription { get; set; }

        public virtual ICollection<DailyRate> DailyRate { get; set; }
        public virtual ICollection<PetReservationService> PetReservationService { get; set; }

        public Service GetService(int id) {
            var result = _context.Service.Where(s => s.ServiceId == id).AsNoTracking().FirstOrDefault();
            return result;
        }
    }
}
