using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactsManagerInMVCLinqEF
{
    public class CountryVal
    {
        [Required(ErrorMessage="Country Name is Required")]
       [Display(Name="Country Name")]
        public string CountryName { get; set; }

        [Required(ErrorMessage="Zip code start is required")]
        [RegularExpression(@"^(?!000000)[0-9]{6,6}$", ErrorMessage = "Zip code is not valid")]
        public Nullable<long> ZipCodeStart { get; set; }
       
        [Required(ErrorMessage="Zip code end is Required")]
        [RegularExpression(@"^(?!000000)[0-9]{6,6}$", ErrorMessage = "Zip code is not valid")]
        public long ZipCodeEnd { get; set; }
        [Display(Name="Active")]
        public bool IsActive { get; set; }
    }

    [MetadataType(typeof(CountryVal))]
    public partial class Country
    {
    }
}