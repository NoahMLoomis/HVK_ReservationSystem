using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class KennelLog {
        public DateTime LogDate { get; set; }
        public int SequenceNumber { get; set; }
        public string Notes { get; set; }
        [Column("PetReservationId")]
        public int PetReservationId { get; set; }
        [ForeignKey("PetReservationId")]
        public virtual PetReservation PetReservation { get; set; }
    }
}
