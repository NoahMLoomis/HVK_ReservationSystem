using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class SpecialNotes {
        public string Notes { get; set; }
        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }
    }
}
