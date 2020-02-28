using EPiServer.Core; // PageData
using EPiServer.DataAnnotations; // RegularExpression
using System.ComponentModel.DataAnnotations; // [StringLength], [RegularExpression], [Range]
using Epi = EPiServer.Framework; // Validator

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "Validating", 
        GUID = "ed0e939e-58fc-446e-b9db-231cbe045010", 
        Description = "Use this to demonstrate property validation techniques.")]
    public class ValidatingPage : PageData
    {
        [Required]
        public virtual bool Happy { get; set; }

        [StringLength(20)]
        public virtual string Heading { get; set; }

        [StringLength(20, MinimumLength = 2,
            ErrorMessage = "Subheadng must be between 2 and 20 characters.")]
        public virtual string Subheading { get; set; }

        [RegularExpression(Epi.Validator.DefaultEmailRegexString,
            ErrorMessage = "Must be a valid email address.")]
        public virtual string EmailAddress { get; set; }

        [Range(18, 150, ErrorMessage = "You must be over 18 to enter")]
        public virtual int Age { get; set; }
    }
}