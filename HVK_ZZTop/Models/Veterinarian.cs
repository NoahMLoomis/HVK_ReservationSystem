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
    public partial class Veterinarian {
        private readonly HVK_ZZTopContext _context;

        public Veterinarian() {
            Owner = new HashSet<Owner>();
            _context = new HVK_ZZTopContext();
        }

        public int VeterinarianId { get; set; }

        [Display(Name = "Full Name:")]
        [DataType(DataType.Text)]
        [CheckValidVetName()]
        [RegularExpression("^[a-zA-Z]*[a-zA-Z ,.'-]+$", ErrorMessage = "Full Name must follow proper format")]
        [MaxLength(50, ErrorMessage = "Full Name must be less than 50 characters")]
        public string Name { get; set; }

        [Display(Name = "Phone:")]
        [DataType(DataType.PhoneNumber)]
        [CheckValidVetPhone()]
        [RegularExpression(@"^\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Phone Number must follow proper format")]
        public string Phone { get; set; }

        [Display(Name = "Address:")]
        [DataType(DataType.Text)]
        [RegularExpression("^[a-z0-9-. ']+$", ErrorMessage = "Address must follow proper format")]
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
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$", ErrorMessage = "Postal Code must follow proper format")]
        public string PostalCode { get; set; }

        public virtual ICollection<Owner> Owner { get; set; }

        public async Task<IEnumerable<Veterinarian>> GetVeterinarians() {
            return await _context.Veterinarian.OrderBy(v => v.Name).AsNoTracking().ToListAsync();
        }


        public async Task<IEnumerable<Veterinarian>> getVet(int id) {
            var result = _context.Veterinarian.Where(v => v.VeterinarianId == id).AsNoTracking().ToListAsync();
            return await result;
        }
    }
}
