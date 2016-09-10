using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BOL.CustomValidations {
   public class UniqueUserValidation : ValidationAttribute {
       protected override ValidationResult IsValid( object value, ValidationContext validContext) {
           LinkHubDbEntities dbEntities = new LinkHubDbEntities();
           var userEmail = value.ToString();
           var count = dbEntities.tbl_User.Where(x => x.UserEmail == userEmail).ToList().Count;
           if (count != 0) {
               return new ValidationResult("User Already Exists with this Email");
           }
           return ValidationResult.Success;
       }
    }
}
