using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HVK_ZZTop.Models {
    public class CustomerSearchViewModel {
        public Owner Owner { get; set; }

        public List<Pet> Pets { get; set; }

        public List<PetReservation> PetReservations { get; set; }
    }
}
