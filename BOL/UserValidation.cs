using System.ComponentModel.DataAnnotations;
using BOL.CustomValidations;

namespace BOL {
    public class UserValidation {
        [Required(ErrorMessage = "Email is Required"), Display(Name = "Name")]
        [EmailAddress]
        [UniqueUserValidation]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Password is Required"), Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required"), Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

    [MetadataType(typeof(UserValidation))]
    public partial class tbl_User {
        public string ConfirmPassword { get; set; }
    }
}
