using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static ZZTop_HVK.Models.CustomValidation;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HVK_ZZTop.Models {
    public partial class Owner {
        private readonly HVK_ZZTopContext _context;

        public Owner() {
            Pet = new HashSet<Pet>();
            _context = new HVK_ZZTopContext();
        }

        public int OwnerId { get; set; }

        [Display(Name = "First Name:")]
        [DataType(DataType.Text)]
        [Required]
        [RegularExpression("^[a-zA-Z]*[a-zA-Z '-]+$", ErrorMessage = "First Name must follow proper format")]
        [MaxLength(25, ErrorMessage = "First Name must be less than 25 characters")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name:")]
        [DataType(DataType.Text)]
        [Required]
        [RegularExpression("^[a-zA-Z]*[a-zA-Z '-]+$", ErrorMessage = "Last Name must follow proper format")]
        [MaxLength(25, ErrorMessage = "First Name must be less than 25 characters")]
        public string LastName { get; set; }

        [Display(Name = "Address:")]
        [DataType(DataType.Text)]
        [RegularExpression("^[a-zA-Z0-9-. ']+$", ErrorMessage = "Address must follow proper format")]
        public string Street { get; set; }

        [Display(Name = "City:")]
        [DataType(DataType.Text)]
        [MaxLength(25, ErrorMessage = "City must be less than 50 characters")]
        [RegularExpression("^[a-zA-Z]*[a-zA-Z -]+$", ErrorMessage = "City must follow proper format")]
        public string City { get; set; }

        [Display(Name = "Province:")]
        public string Province { get; set; }

        [Display(Name = "Postal Code:")]
        [DataType(DataType.PostalCode)]
        [MaxLength(7, ErrorMessage = "Postal Code must be less than 7 characters")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$", ErrorMessage = "Postal Code must follow proper format")]
        public string PostalCode { get; set; }

        [Display(Name = "Home Phone:")]
        [DataType(DataType.PhoneNumber)]
        [CheckValidPhone()]
        [RegularExpression(@"^\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Phone Number must follow proper format")]
        public string Phone { get; set; }

        [Display(Name = "Cell Phone:")]
        [DataType(DataType.PhoneNumber)]
        [CheckValidCellPhone()]
        [RegularExpression(@"^\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Phone Number must follow proper format")]
        public string CellPhone { get; set; }

        [Display(Name = "Email:")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50, ErrorMessage = "Email must be less than 50 characters")]
        [CheckValidEmail()]
        public string Email { get; set; }

        [Display(Name = "First Name:")]
        [DataType(DataType.Text)]
        [CheckValidEmergFirst()]
        [RegularExpression("^[a-zA-Z]*[a-zA-Z '-]+$", ErrorMessage = "First Name must follow proper format")]
        [MaxLength(25, ErrorMessage = "First Name must be less than 25 characters")]
        public string EmergencyContactFirstName { get; set; }

        [Display(Name = "Last Name:")]
        [DataType(DataType.Text)]
        [CheckValidEmergLast()]
        [RegularExpression("^[a-zA-Z]*[a-zA-Z '-]+$", ErrorMessage = "Last Name must follow proper format")]
        [MaxLength(25, ErrorMessage = "First Name must be less than 25 characters")]
        public string EmergencyContactLastName { get; set; }

        [Display(Name = "Phone Number:")]
        [DataType(DataType.PhoneNumber)]
        [CheckValidEmergPhone()]
        [RegularExpression(@"^\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Phone Number must follow proper format")]
        public string EmergencyContactPhone { get; set; }

        [Display(Name = "Vet:")]
        [DataType(DataType.Text)]
        [CheckValidVet()]
        public int? VeterinarianId { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password:")]
        [DataType(DataType.Text)]
        [MaxLength(50, ErrorMessage = "Password must be less than 50 characters")]
        public string Password { get; set; }

        public virtual Veterinarian Veterinarian { get; set; }
        public virtual ICollection<Pet> Pet { get; set; }

        public async Task<IEnumerable<Owner>> GetOwners() {
            return await _context.Owner.OrderBy(o => o.LastName).AsNoTracking().ToListAsync();
        }

        public Owner GetOwner(int id) {
            var result = _context.Owner.Where(o => o.OwnerId == id).AsNoTracking().FirstOrDefault();
            return result;
        }
    }
}
