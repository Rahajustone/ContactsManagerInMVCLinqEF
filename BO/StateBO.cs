using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ContactsManagerInMVCLinqEF.BO
{
    public class StateBO
    {
        AddressBookDBEntities context = new AddressBookDBEntities();
        public List<State> GetStates(int countryId = 0, bool? isActive = null)
        {
            IQueryable<State> qry = context.States;
            if (isActive.HasValue)
                qry = qry.Where(state => state.IsActive == isActive.Value);
            if (countryId != 0)
                qry = qry.Where(state => state.FKCountryId == countryId);
            var q = (from s in qry
                     join c in context.Countries on s.FKCountryId equals c.PKCountryId
                     select new
                     {
                         PKStateId = s.PKStateId,
                         StateName = s.StateName,
                         CountryName = c.CountryName,
                         IsActive = s.IsActive
                     }).AsEnumerable().Select(x => new State
                     {
                         PKStateId = x.PKStateId,
                         StateName = x.StateName,
                         CountryName = x.CountryName,
                         IsActive = x.IsActive
                     });
            return q.ToList();
        }
        public State GetState(int stateId)
        {
            var q = (from s in context.States
                     join c in context.Countries
                         on s.FKCountryId equals c.PKCountryId
                     where s.PKStateId == stateId
                     select s).FirstOrDefault();
            return q;
        }
        public void InsertState(State objState)
        {
            try
            {
                context.States.Add(objState);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateState(State objNewState)
        {
            try
            {
                context.Entry(objNewState).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteState(int stateId)
        {
            try
            {
                State state = context.States.Find(stateId);
                context.States.Remove(state);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}