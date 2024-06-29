using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ContactsManagerInMVCLinqEF.BO
{
    public class CountryBO
    {
        AddressBookDBEntities context = new AddressBookDBEntities();
        public IEnumerable<Country> GetCountries(bool? isActive=null)
        {
            IQueryable<Country> qry = context.Countries;
            if (isActive.HasValue)
                qry = qry.Where(country => country.IsActive == isActive.Value);
            return qry.ToList();
        }
        public Country GetCountry(int countryId)
        {
            return context.Countries.Find(countryId);
        }
        public void InsertCountry(Country objCountry)
        {
            try
            {
                context.Countries.Add(objCountry);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateCountry(Country objCountry)
        {
            try
            {
                context.Entry(objCountry).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteCountry(int countryId)
        {
            try
            {
                Country objCountry = context.Countries.Find(countryId);
                context.Countries.Remove(objCountry);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}