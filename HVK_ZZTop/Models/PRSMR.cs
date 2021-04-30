using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HVK_ZZTop.Models {
    public class PRSMR {
        public PetReservation PetReservation { get; set; }
        public bool Walk { get; set; }
        public bool PlayTime { get; set; }
        public Medication Medication { get; set; }
        public int[] PetIds { get; set; }
    }
}
