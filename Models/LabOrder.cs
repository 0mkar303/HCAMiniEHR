using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HCAMiniEHR.Models
{
    public class LabOrder : IValidatableObject
    {
        public int LabOrderId { get; set; }

        [Required(ErrorMessage = "Test name is required")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Test name must be at least 3 characters")]
        public string TestName { get; set; }

        // System controlled
        [ValidateNever]
        public string Status { get; set; } = "Pending";

        [Required]
        public int AppointmentId { get; set; }

        [ValidateNever]
        public Appointment Appointment { get; set; }

        // Custom validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrWhiteSpace(TestName))
            {
                if (TestName.Trim().Length < 3)
                {
                    yield return new ValidationResult(
                        "Test name must contain meaningful characters",
                        new[] { nameof(TestName) });
                }
            }
        }
    }
}
