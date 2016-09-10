using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BOL.CustomValidations {
    public class UniqueCategoryValidation: ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validContext) {
            LinkHubDbEntities dbEntities = new LinkHubDbEntities();
            var category = value.ToString();
            var count = dbEntities.tbl_Category.Where(x => x.CategoryName == category).ToList().Count;
            if (count !=0) {
                return new ValidationResult("Category Already Exists!");
            }
            return ValidationResult.Success;
        }
    }
}
