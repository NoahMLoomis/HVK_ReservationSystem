using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class PetReservationDiscount {
        public int DiscountId { get; set; }
        [Column("PetReservationId")]
        public int PetReservationId { get; set; }

        public virtual Discount Discount { get; set; }
        [ForeignKey("PetReservationId")]
        public virtual PetReservation PetReservation { get; set; }
    }
}
