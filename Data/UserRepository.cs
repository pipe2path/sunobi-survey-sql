using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using survey.Interfaces;
using Microsoft.Extensions.Options;
using survey.Model;

namespace survey.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context = null;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<UserResponse> GetResponseUsers()
        {
            try
            {
                return _context.UserResponse.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserResponse GetResponseUserByPhone(string phone)
        {
            try
            {
                return _context.UserResponse.FirstOrDefault(p => p.userPhone == phone);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<UserCoupon> GetCouponList()
        {
            var dateCutOff = DateTime.Today.AddDays(-15);

            try
            {
                // get a join of responseUser and couponcode based on userid
                IEnumerable<UserCoupon> userCoupons = _context.UserCoupon.ToList();

                // only return users who have not been sent a message in the last 15 days
                List<UserCoupon> filteredUsers = new List<UserCoupon>();
                Message msgSent = new Message();
                foreach (UserCoupon u in userCoupons)
                {
                    var userId = u.responseUserId;
                    msgSent = (from m in _context.Message.AsQueryable()
                               where m.userId == userId
                               select m).FirstOrDefault();

                    if (msgSent != null)
                    {
                        if (msgSent.dateLastTextSent <= dateCutOff)
                            filteredUsers.Add(u);
                    }
                    else
                    {
                        filteredUsers.Add(u);
                    }
                }

                return filteredUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
