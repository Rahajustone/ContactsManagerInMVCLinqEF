using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactsManagerInMVCLinqEF
{
    public class StateVal
    {
        [Display(Name="Country Name")]
        public string CountryName { get; set; }
        [Required(ErrorMessage = "State Name is Required")]
        [Display(Name = "State Name")]
        public string StateName { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
    [MetadataType(typeof(StateVal))]
    public partial class State
    {
    }

}