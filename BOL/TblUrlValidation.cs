using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BOL {
    public class CustomUrlValidationAttribute : ValidationAttribute {
        //This method is for overriding the IsValid method ( ValidationResult type).
        //It searches and find the url is already exists or not
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            LinkHubDbEntities objDbEntities = new LinkHubDbEntities();
            string urlVale = value.ToString();
            int count = objDbEntities.tbl_Url.Where(x => x.Url == urlVale).ToList().Count;
            if (count !=0) {
                return new ValidationResult("URL Already Exists");
            }
            return ValidationResult.Success;
        }
    }

    public class TblUrlValidation {
        [Required(ErrorMessage = "*URL Title is Required"), Display(Name = "URL Title")]
        public string UrlTitle { get; set; }

        [Required(ErrorMessage = "*URL is Required"), Display(Name = "URL")]
        [Url]
        [CustomUrlValidation(ErrorMessage = "URL Already Exists!!!")]
        public string Url { get; set; }

        [Required(ErrorMessage = "*URL Description is Required"), Display(Name = "URL Description")]
        public string UrlDesc { get; set; }
    }

    [MetadataType(typeof(TblUrlValidation))]
    public partial class tbl_Url { }
}
