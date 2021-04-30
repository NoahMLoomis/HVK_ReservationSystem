using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class ReservationDiscount {
        public int DiscountId { get; set; }
        public int ReservationId { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
