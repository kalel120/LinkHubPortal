using System;
using System.ComponentModel.DataAnnotations;
using BOL.CustomValidations;

namespace BOL {
    public class CategoryValidation {
        [Required (ErrorMessage = "Category Name is Required")]
        [UniqueCategoryValidation]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Category Name is Required")]
        public string CategoryDesc { get; set; }
    }


    [MetadataType(typeof(CategoryValidation))]
    public partial class tbl_Category { }
}
