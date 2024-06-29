using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ContactsManagerInMVCLinqEF.BO
{
    public class UserBO
    {
        AddressBookDBEntities context = new AddressBookDBEntities();
        public UserDetail AuthenticateUser(string userName, string password)
        {
            UserDetail objUser = context.UserDetails.Where(user => user.UserName == userName).SingleOrDefault();
            return objUser;
        }
       
        public UserDetail GetUser(int userId)
        {
            return context.UserDetails.Find(userId);
        }
        public IEnumerable<UserDetail> GetUsers(bool? isActive = null)
        {
            IQueryable<UserDetail> qry = context.UserDetails;
            if (isActive.HasValue)
                qry = qry.Where(user => user.IsActive == isActive);
            return qry.ToList();
        }
        public void InsertUser(UserDetail objUser)
        {
            try
            {
                context.UserDetails.Add(objUser);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateUser(UserDetail objUser)
        {
            try
            {
                context.Entry(objUser).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteUser(int userId)
        {
            try
            {
                UserDetail userDetail = context.UserDetails.Find(userId);
                context.UserDetails.Remove(userDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

    }
}