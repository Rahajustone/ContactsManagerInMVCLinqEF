//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContactsManagerInMVCLinqEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserDetail
    {
        public UserDetail()
        {
            this.AddressBooks = new HashSet<AddressBook>();
        }
    
        public int PKUserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public bool IsActive { get; set; }
    
        public virtual ICollection<AddressBook> AddressBooks { get; set; }
    }
}
