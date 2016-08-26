using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BOL {
    public class UrlValidation {
        [Required(ErrorMessage = "Required")]
        public string UrlTitle { get; set; }

        [Required(ErrorMessage = "Required"), Url, UniqueUrl]
        public string Url { get; set; }

        [Required(ErrorMessage = "Required")]
        public string UrlDesc { get; set; }
    }

    public class UniqueUrlAttribute : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validContext) {
            LinkHubDbEntities dbEntities = new LinkHubDbEntities();
            var urlValue = value.ToString();
            var count = dbEntities.tbl_Url.Where(x => x.Url == urlValue).ToList().Count;
            if (count !=0) {
                return new ValidationResult("Url Already Exists!");
            }
            return ValidationResult.Success;
        }
    }

    [MetadataType(typeof(UrlValidation))]
    public partial class tbl_Url{}
}
