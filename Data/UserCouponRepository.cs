using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Interfaces;
using survey.Model;

namespace survey.Data
{
    public class UserCouponRepository : IUserCouponRepository
    {
        private readonly DatabaseContext _context = null;

        public UserCouponRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<UserCoupon> GetUserCoupons()
        {
            try
            {
                return _context.UserCoupons.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserCoupon GetUserCoupon(int userId)
        {
            return _context.UserCoupons.FirstOrDefault(c => c.responseUserId == userId);
        }

        public int CreateCouponCode(int code)
        {
            try
            {
                var returnCode = 0;
                UserCoupon couponCode = _context.UserCoupons.FirstOrDefault(r => r.couponCode == code);
                if (couponCode != null)
                    returnCode = couponCode.userCouponId;

                return returnCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
