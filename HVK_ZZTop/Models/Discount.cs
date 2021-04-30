﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class Discount {
        public Discount() {
            PetReservationDiscount = new HashSet<PetReservationDiscount>();
            ReservationDiscount = new HashSet<ReservationDiscount>();
        }

        public int DiscountId { get; set; }
        public string Desciption { get; set; }
        public decimal Percentage { get; set; }
        public string Type { get; set; }

        public virtual ICollection<PetReservationDiscount> PetReservationDiscount { get; set; }
        public virtual ICollection<ReservationDiscount> ReservationDiscount { get; set; }
    }
}
