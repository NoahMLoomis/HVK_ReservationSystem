using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ZZTop_HVK.Models.CustomValidation;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class Medication {

        public int MedicationId { get; set; }
        [StringLength(50)]
        [CheckValidMedication()]
        public string Name { get; set; }
        [StringLength(50)]
        public string Dosage { get; set; }
        [StringLength(50)]
        [Display(Name = "Special Instructions")]
        public string SpecialInstruct { get; set; }
        [Display(Name = "End Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy\\/MM\\/dd}")]
        [CheckMediEndDate()]
        public DateTime? EndDate { get; set; }

        [Column("PetReservationId")]
        public int PetReservationId { get; set; }
        [ForeignKey("PetReservationId")]
        public virtual PetReservation PetReservation { get; set; }
    }
}
