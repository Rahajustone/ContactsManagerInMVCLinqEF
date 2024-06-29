using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactsManagerInMVCLinqEF
{
    public class UserDetailVal
    {
        [Required(ErrorMessage = "User Name is Required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "FirstName is Required")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required")]
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Address is Required")]
        [EmailAddress(ErrorMessage = "Please provide valid Email Address")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "PhoneNo is Required")]
        [RegularExpression(@"^(?!0000000000)[0-9]{10,10}$", ErrorMessage = "Phone Number is not valid")]
        [Display(Name="Phone No")]
        public string PhoneNo { get; set; }
        [Display(Name="Active")]
        public bool IsActive { get; set; }
    }
    [MetadataType(typeof(UserDetailVal))]
    public partial class UserDetail
    {
    }
}