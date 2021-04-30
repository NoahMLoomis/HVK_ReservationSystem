using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ZZTop_HVK.Models.CustomValidation;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class Reservation {
        public Reservation() {
            PetReservation = new HashSet<PetReservation>();
            ReservationDiscount = new HashSet<ReservationDiscount>();
            ReservationId = ReservationId++;
        }

        public int ReservationId { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [CheckValidStartDate()]
        [DisplayFormat(DataFormatString = "{0:yyyy\\/MM\\/dd}")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [CheckValidEndDate()]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy\\/MM\\/dd}")]
        public DateTime EndDate { get; set; }
        public decimal Status { get; set; }
        public virtual ICollection<PetReservation> PetReservation { get; set; }
        public virtual ICollection<ReservationDiscount> ReservationDiscount { get; set; }

        public int GetTotalDays() {
            return (EndDate - StartDate).Days;
        }
    }
}
