using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Model;

namespace survey.Interfaces
{
    public interface IUserCouponRepository
    {
        IEnumerable<UserCoupon> GetUserCoupons();
        UserCoupon GetUserCoupon(int userId);
        int CreateCouponCode(int code);
    }
}
