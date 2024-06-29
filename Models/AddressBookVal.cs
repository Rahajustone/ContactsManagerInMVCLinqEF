using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactsManagerInMVCLinqEF
{
    public class AddressBookVal
    {
        [Required(ErrorMessage="First Name is Required")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "EmailId is Required")]
        [EmailAddress(ErrorMessage = "Please provide valid Email Address")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "PhoneNo is Required")]
        [RegularExpression(@"^(?!0000000000)[0-9]{10,10}$", ErrorMessage = "Phone Number is not valid")]
        [Display(Name="Phone No")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Address1 is Required")]
        public string Address1 { get; set; }
        [Required(ErrorMessage = "Address2 is Required")]
        public string Address2 { get; set; }
        [Required(ErrorMessage = "Street is Required")]
        public string Street { get; set; }
        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Zip Code is Required")]
        [RegularExpression(@"^(?!000000)[0-9]{6,6}$", ErrorMessage = "Zip code is not valid")]
        public long ZipCode { get; set; }
        [Display(Name="Country")]
        public string CountryName { get; set; }
        [Display(Name="State Name")]
        public string StateName { get; set; }
        [Display(Name="Active")]
        public bool IsActive { get; set; }
    }
    [MetadataType(typeof(AddressBookVal))]
    public partial class AddressBook
    {
    }
}