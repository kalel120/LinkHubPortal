using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BOL.CustomValidations {
    public class UniqueUrlAttribute : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validContext) {
            LinkHubDbEntities dbEntities = new LinkHubDbEntities();
            var urlValue = value.ToString();
            var count = dbEntities.tbl_Url.Where(x => x.Url == urlValue).ToList().Count;
            if(count != 0) {
                return new ValidationResult("Url Already Exists!");
            }
            return ValidationResult.Success;
        }
    }
}
