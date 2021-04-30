using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ZZTop_HVK.Models.CustomValidation;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class PetVaccination {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy\\/MM\\/dd}")]
        [CheckVaccDate()]
        public DateTime? ExpiryDate { get; set; }
        public int VaccinationId { get; set; }
        public int PetId { get; set; }
        [Display(Name = "Checked")]
        public bool VaccinationChecked { get; set; }

        public virtual Pet Pet { get; set; }
        public virtual Vaccination Vaccination { get; set; }
    }
}
