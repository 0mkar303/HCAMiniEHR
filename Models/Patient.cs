using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HCAMiniEHR.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Patient), nameof(ValidateDOB))]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [RegularExpression(@"^[6-9]\d{9}$",
            ErrorMessage = "Enter a valid 10-digit mobile number Number Should start with 6-9")]
        public string MobileNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }=null!;

        [Required(ErrorMessage = "Blood Group is Required")]
        [RegularExpression(
     "^(A|B|AB|O)[+-]$",
     ErrorMessage = "Select a valid blood group")]
        public string? BloodGroup { get; set; }=null!;

        [Required(ErrorMessage ="Emergency contact is Required")]
        [RegularExpression(@"^[1-9]\d{9}$",
            ErrorMessage = "Emergency contact must be a valid 10-digit number")]
        public string? EmergencyContact { get; set; }=null!;

        public DateTime RegisteredOn { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Active";
        [ValidateNever]
        public ICollection<Appointment> Appointments { get; set; }

        // ✅ Custom DOB validation
        public static ValidationResult ValidateDOB(DateTime dob, ValidationContext context)
        {
            if (dob.Date > DateTime.Today)
            {
                return new ValidationResult("Date of Birth cannot be a future date");
            }

            return ValidationResult.Success;
        }
    }
}
