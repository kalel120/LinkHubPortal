using System.ComponentModel.DataAnnotations;

namespace BOL {
    public class TblCategoryValidation {
        [Required(ErrorMessage = "Category Name is Required"),Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Category Description is Required"),Display(Name = "Category Description")]
        public string CategoryDesc { get; set; }
    }
    [MetadataType(typeof(TblCategoryValidation))]
    public partial class tbl_Category {}
}
