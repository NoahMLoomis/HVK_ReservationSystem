using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class Run {
        public Run() {
            PetReservation = new HashSet<PetReservation>();
        }

        public int RunId { get; set; }
        public string Size { get; set; }
        public int Covered { get; set; }
        public string Location { get; set; }
        public decimal? Status { get; set; }

        public virtual ICollection<PetReservation> PetReservation { get; set; }
    }
}
