using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HVK_ZZTop.Models {
    public class EditReservationViewModel {
        public PetReservation PetReservation { get; set; }

        public Medication Medication { get; set; }

        public bool Walk { get; set; }

        public bool PlayTime { get; set; }
    }
}
