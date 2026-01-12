using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HCAMiniEHR.Models
{
    public class Appointment : IValidatableObject
    {
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Appointment date is required")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [ValidateNever]
        public string Status { get; set; } = "Scheduled";

        [Required]
        public int PatientId { get; set; }

        [ValidateNever]
        public Patient Patient { get; set; }

        [Required(ErrorMessage = "Doctor selection is required")]
        public int DoctorId { get; set; }

        [ValidateNever]
        public Doctor Doctor { get; set; }

        [ValidateNever]
        public ICollection<LabOrder> LabOrders { get; set; }

        // ✅ CUSTOM MODEL-LEVEL VALIDATION
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (AppointmentDate == default)
            {
                yield return new ValidationResult(
                    "Appointment date is required",
                    new[] { nameof(AppointmentDate) });
            }
            else if (AppointmentDate.Date < DateTime.Today)
            {
                yield return new ValidationResult(
                    "Past dates are not allowed for appointments",
                    new[] { nameof(AppointmentDate) });
            }
        }
    }
}
