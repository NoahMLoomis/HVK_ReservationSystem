using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using static ZZTop_HVK.Models.CustomValidation;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class PetReservation {

        private readonly HVK_ZZTopContext _context;
        public PetReservation() {
            KennelLog = new HashSet<KennelLog>();
            Medication = new HashSet<Medication>();
            PetReservationDiscount = new HashSet<PetReservationDiscount>();
            PetReservationService = new HashSet<PetReservationService>();
            _context = new HVK_ZZTopContext();

        }

        public int PetReservationId { get; set; }
        [Required]
        public int PetId { get; set; }
        public int ReservationId { get; set; }
        public int? RunId { get; set; }
        public virtual Pet Pet { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual Run Run { get; set; }
        public virtual ICollection<KennelLog> KennelLog { get; set; }
        public virtual ICollection<Medication> Medication { get; set; }

        public virtual ICollection<PetReservationDiscount> PetReservationDiscount { get; set; }
        public virtual ICollection<PetReservationService> PetReservationService { get; set; }

    }
}