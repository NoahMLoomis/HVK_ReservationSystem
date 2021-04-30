using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class DailyRate {
        public int DailyRateId { get; set; }
        public decimal Rate { get; set; }
        public string DogSize { get; set; }
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
