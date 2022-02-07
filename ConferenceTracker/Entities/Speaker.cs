using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ConferenceTracker.Entities
{
    public class Speaker : IValidatableObject
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First name")]
        [StringLength(maximumLength:100, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last name")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 500, MinimumLength = 10)]
        public string Description { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public bool IsStaff { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List <ValidationResult> res = new List<ValidationResult>();
            if (EmailAddress != null && EmailAddress.EndsWith("TechnologyLiveConference.com", StringComparison.OrdinalIgnoreCase))
            {
                res.Add(new ValidationResult("Technology Live Conference staff should not use their conference email addresses."));
            }
            return res;
        }
    }
}
