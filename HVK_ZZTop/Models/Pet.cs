using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ZZTop_HVK.Models.CustomValidation;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class Pet {

        public Pet() {
            PetReservation = new HashSet<PetReservation>();
            PetVaccination = new HashSet<PetVaccination>();
        }

        public int PetId { get; set; }
        [StringLength(25)]
        [Required]
        public string Name { get; set; }
        [StringLength(25)]
        [CheckPetSex()]
        public string Gender { get; set; }
        public bool Fixed { get; set; }
        [Required]
        public string Breed { get; set; }
        [CheckPetAge()]
        [RegularExpression(@"^\d{2}\/\d{2}\/\d{4}$", ErrorMessage = "The Birthdate must follow the format dd/MM/YYYY")]
        public string Birthdate { get; set; }
        public int OwnerId { get; set; }
        [Required]
        public string DogSize { get; set; }
        public bool Climber { get; set; }
        public bool Barker { get; set; }

        public virtual Owner Owner { get; set; }
        public virtual SpecialNotes SpecialNotes { get; set; }
        public virtual ICollection<PetReservation> PetReservation { get; set; }
        public virtual ICollection<PetVaccination> PetVaccination { get; set; }
    }
}
