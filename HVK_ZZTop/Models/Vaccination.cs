using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class Vaccination {
        public Vaccination() {
            PetVaccination = new HashSet<PetVaccination>();
        }
        public int VaccinationId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PetVaccination> PetVaccination { get; set; }
    }
}
