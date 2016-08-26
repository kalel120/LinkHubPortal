using System.ComponentModel.DataAnnotations;

namespace BOL {
    public class UrlValidation {
        [Required(ErrorMessage = "Required")]
        public string UrlTitle { get; set; }

        [Required(ErrorMessage = "Required"), Url]
        public string Url { get; set; }

        [Required(ErrorMessage = "Required")]
        public string UrlDesc { get; set; }
    }

    [MetadataType(typeof(UrlValidation))]
    public partial class tbl_Url{}
}
