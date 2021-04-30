using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HVK_ZZTop.Models;
using System.Globalization;

namespace ZZTop_HVK.Models {
    public class CustomValidation {
        public sealed class CheckValidEmail : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                if (value != null) {
                    return ValidationResult.Success;
                } else {
                    var cellPhone = validationContext.ObjectInstance.GetType().GetProperty("CellPhone").GetValue(validationContext.ObjectInstance, null);
                    var phone = validationContext.ObjectInstance.GetType().GetProperty("Phone").GetValue(validationContext.ObjectInstance, null);
                    if (cellPhone == null && phone == null) {
                        return new ValidationResult("Add an Email or another form of communication");
                    } else {
                        return ValidationResult.Success;
                    }
                }
            }
        }


        public sealed class CheckValidCellPhone : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                if (value != null) {
                    return ValidationResult.Success;
                } else {
                    var email = validationContext.ObjectInstance.GetType().GetProperty("Email").GetValue(validationContext.ObjectInstance, null);
                    var phone = validationContext.ObjectInstance.GetType().GetProperty("Phone").GetValue(validationContext.ObjectInstance, null);
                    if (email == null && phone == null) {
                        return new ValidationResult("Add a Cell Phone Number or another form of communication");
                    } else {
                        return ValidationResult.Success;
                    }
                }
            }
        }


        public sealed class CheckValidPhone : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                if (value != null) {
                    return ValidationResult.Success;
                } else {
                    var email = validationContext.ObjectInstance.GetType().GetProperty("Email").GetValue(validationContext.ObjectInstance, null);
                    var cellPhone = validationContext.ObjectInstance.GetType().GetProperty("CellPhone").GetValue(validationContext.ObjectInstance, null);
                    if (email == null && cellPhone == null) {
                        return new ValidationResult("Add a Phone Number or another form of communication");
                    } else {
                        return ValidationResult.Success;
                    }
                }
            }
        }


        public sealed class CheckValidVet : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                if (value != null) {
                    if (new Veterinarian().getVet((int)value) != null) {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Invalid Veterinarian");
                } else {
                    return new ValidationResult("Invalid Veterinarian");
                }
            }
        }


        public sealed class CheckValidEmergFirst : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                var Last = validationContext.ObjectInstance.GetType().GetProperty("EmergencyContactLastName").GetValue(validationContext.ObjectInstance, null);
                var Phone = validationContext.ObjectInstance.GetType().GetProperty("EmergencyContactPhone").GetValue(validationContext.ObjectInstance, null);
                if (Last == null && Phone == null && value == null) {
                    return ValidationResult.Success;
                } else if (Last != null && Phone != null && value != null) {
                    return ValidationResult.Success;
                } else if (value != null) {
                    return ValidationResult.Success;
                } else {
                    return new ValidationResult("Fill in all of Emergency Contact information");
                }
            }
        }


        public sealed class CheckValidEmergLast : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                var First = validationContext.ObjectInstance.GetType().GetProperty("EmergencyContactFirstName").GetValue(validationContext.ObjectInstance, null);
                var Phone = validationContext.ObjectInstance.GetType().GetProperty("EmergencyContactPhone").GetValue(validationContext.ObjectInstance, null);
                if (First == null && Phone == null && value == null) {
                    return ValidationResult.Success;
                } else if (First != null && Phone != null && value != null) {
                    return ValidationResult.Success;
                } else if (value != null) {
                    return ValidationResult.Success;
                } else {
                    return new ValidationResult("Fill in all of Emergency Contact information");
                }
            }
        }


        public sealed class CheckValidEmergPhone : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                var Last = validationContext.ObjectInstance.GetType().GetProperty("EmergencyContactLastName").GetValue(validationContext.ObjectInstance, null);
                var First = validationContext.ObjectInstance.GetType().GetProperty("EmergencyContactFirstName").GetValue(validationContext.ObjectInstance, null);
                if (Last == null && First == null && value == null) {
                    return ValidationResult.Success;
                } else if (Last != null && First != null && value != null) {
                    return ValidationResult.Success;
                } else if (value != null) {
                    return ValidationResult.Success;
                } else {
                    return new ValidationResult("Fill in all of Emergency Contact information");
                }
            }
        }


        public sealed class CheckValidVetName : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                var Address = validationContext.ObjectInstance.GetType().GetProperty("Street").GetValue(validationContext.ObjectInstance, null);
                var Province = validationContext.ObjectInstance.GetType().GetProperty("Province").GetValue(validationContext.ObjectInstance, null);
                var PostalCode = validationContext.ObjectInstance.GetType().GetProperty("PostalCode").GetValue(validationContext.ObjectInstance, null);
                var Phone = validationContext.ObjectInstance.GetType().GetProperty("Phone").GetValue(validationContext.ObjectInstance, null);
                if (Address == null && Province == null && PostalCode == null && Phone == null && value == null) {
                    return ValidationResult.Success;
                } else if (Address != null && Province != null && PostalCode != null && Phone != null && value != null) {
                    return ValidationResult.Success;
                } else if (value != null && Phone != null) {
                    return ValidationResult.Success;
                } else {
                    return new ValidationResult("Fill in Name and Phone Number");
                }
            }
        }


        public sealed class CheckValidVetPhone : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                var Address = validationContext.ObjectInstance.GetType().GetProperty("Street").GetValue(validationContext.ObjectInstance, null);
                var Province = validationContext.ObjectInstance.GetType().GetProperty("Province").GetValue(validationContext.ObjectInstance, null);
                var PostalCode = validationContext.ObjectInstance.GetType().GetProperty("PostalCode").GetValue(validationContext.ObjectInstance, null);
                var Name = validationContext.ObjectInstance.GetType().GetProperty("Name").GetValue(validationContext.ObjectInstance, null);
                if (Address == null && Province == null && PostalCode == null && Name == null && value == null) {
                    return ValidationResult.Success;
                } else if (Address != null && Province != null && PostalCode != null && Name != null && value != null) {
                    return ValidationResult.Success;
                } else if (value != null && Name != null) {
                    return ValidationResult.Success;
                } else {
                    return new ValidationResult("Fill in Name and Phone Number");
                }
            }
        }


        public sealed class CheckValidStartDate : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                if (value != null) {
                    if (DateTime.Compare((DateTime)value, DateTime.Now.Date.AddMonths(12)) < 0 && DateTime.Compare((DateTime)value, DateTime.Now.Date) > 0) {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Invalid Start Date");
                } else {
                    return new ValidationResult("Invalid Start Date");
                }
            }
        }


        public sealed class CheckValidEndDate : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                if (value != null) {
                    var startDate = validationContext.ObjectInstance.GetType().GetProperty("StartDate").GetValue(validationContext.ObjectInstance, null);
                    if (DateTime.Compare((DateTime)value, ((DateTime)startDate).AddMonths(1)) < 0 && DateTime.Compare((DateTime)value, (DateTime)startDate) > 0) {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Invalid End Date");
                } else {
                    return new ValidationResult("Invalid End Date");
                }
            }
        }


        public sealed class CheckValidMedication : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                var dosage = validationContext.ObjectInstance.GetType().GetProperty("Dosage").GetValue(validationContext.ObjectInstance, null);
                var specialInstruct = validationContext.ObjectInstance.GetType().GetProperty("SpecialInstruct").GetValue(validationContext.ObjectInstance, null);
                var endDate = validationContext.ObjectInstance.GetType().GetProperty("EndDate").GetValue(validationContext.ObjectInstance, null);
                if (dosage != null || specialInstruct != null || endDate != null) {
                    if (value != null) {
                        return ValidationResult.Success;
                    } else {
                        return new ValidationResult("Medication Name is Required");
                    }
                } else {
                    return ValidationResult.Success;
                }
            }
        }




        public sealed class CheckMediEndDate : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                var medName = validationContext.ObjectInstance.GetType().GetProperty("Name").GetValue(validationContext.ObjectInstance, null);
                if (medName != null) {
                    if (value != null) {
                        if (DateTime.Compare((DateTime)value, DateTime.Now.Date.AddMonths(6)) < 0 && DateTime.Compare((DateTime)value, DateTime.Now.Date) > 0) {
                            return ValidationResult.Success;
                        }
                        return new ValidationResult("Invalid Start Date");
                    } else {
                        return ValidationResult.Success;
                    }
                } else {
                    return ValidationResult.Success;
                }
            }
        }

        public sealed class CheckVaccDate : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                if (value != null) {
                    if (DateTime.Compare((DateTime)value, DateTime.Now.Date) > 0) {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Invalid Expiry Date");
                } else {
                    return ValidationResult.Success;

                }
            }
        }

        public sealed class CheckPetAge : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                DateTime PetBirthDate;
                if (value != null && DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None, out PetBirthDate)) {
                    var OldAgeLimit = DateTime.Now.Date.AddYears(-20);

                    if (PetBirthDate > OldAgeLimit && PetBirthDate < DateTime.Now.Date) {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("This pet is too old, isn't born yet");

                } else {
                    return ValidationResult.Success;

                }
            }
        }

        public sealed class CheckPetSex : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                var Gender = validationContext.ObjectInstance.GetType().GetProperty("Gender").GetValue(validationContext.ObjectInstance, null);
                if (value != null) {
                    if (Gender.ToString()[0] == 'M' || Gender.ToString()[0] == 'F') {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Please Select a gender");
                } else {
                    return new ValidationResult("Please Select a gender");

                }
            }
        }

    }
}
