using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ContactsManagerInMVCLinqEF.BO
{
    public class AddressBookBO
    {
        AddressBookDBEntities context = new AddressBookDBEntities();
        public IEnumerable<AddressBook> GetAddresses(int countryId = 0, int stateId = 0, bool? isActive = null)
        {
            IQueryable<AddressBook> qry = context.AddressBooks;
            if (Helper.CurrentUserRole != "Admin")
                qry = qry.Where(address => address.FKUserId == Helper.CurrentUserID);
            if (stateId != 0)
            {
                qry = qry.Where(address => address.FKStateId == stateId);
            }
            else if (countryId != 0)
            {
                var stateIds = context.States.Where(state => state.FKCountryId == countryId).Select(state => state.PKStateId);
                qry = qry.Where(address => stateIds.Contains(address.FKStateId));
            }
            if (isActive.HasValue)
            {
                qry = qry.Where(address => address.IsActive == isActive.Value);
            }
            var q = (from a in qry
                     join s in context.States on a.FKStateId equals s.PKStateId
                     join c in context.Countries on s.FKCountryId equals c.PKCountryId
                     select new
                     {
                         PKAddressId = a.PKAddressId,
                         FirstName = a.FirstName,
                         LastName = a.LastName,
                         EmailId = a.EmailId,
                         PhoneNo = a.PhoneNo,
                         Street = a.Street,
                         City = a.City,
                         FKStateId = s.PKStateId,
                         CountryName = c.CountryName,
                         StateName = s.StateName,
                         ZipCode = a.ZipCode,
                         IsActive = (bool)a.IsActive
                     }).AsEnumerable().Select(x => new AddressBook
                     {
                         PKAddressId = x.PKAddressId,
                         FirstName = x.FirstName,
                         LastName = x.LastName,
                         EmailId = x.EmailId,
                         PhoneNo = x.PhoneNo,
                         Street = x.Street,
                         City = x.City,
                         FKStateId = x.FKStateId,
                         CountryName = x.CountryName,
                         StateName = x.StateName,
                         ZipCode = x.ZipCode,
                         IsActive = (bool)x.IsActive
                     });
            return q.ToList();
        }
        public AddressBook GetAddress(int addressId)
        {
            return context.AddressBooks.Where(address => address.PKAddressId == addressId).SingleOrDefault();
        }
        public void InsertAddress(AddressBook objAddress)
        {
            try
            {
                objAddress.FKUserId = Helper.CurrentUserID;
                context.AddressBooks.Add(objAddress);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateAddress(AddressBook objAddress)
        {
            try
            {
                context.Entry(objAddress).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteAddress(int addressId)
        {
            try
            {
                AddressBook objAddress = context.AddressBooks.Find(addressId);
                context.AddressBooks.Remove(objAddress);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}