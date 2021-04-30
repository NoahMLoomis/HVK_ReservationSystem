using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class PetReservationService {
        public int PetReservationId { get; set; }
        public int ServiceId { get; set; }
        public virtual PetReservation PetReservation { get; set; }
        public virtual Service Service { get; set; }
    }
}
