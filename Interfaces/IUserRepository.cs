using survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserResponse> GetResponseUsers();
        UserResponse GetResponseUserByPhone(string phone);
        IEnumerable<UserCoupon> GetCouponList();
    }
}
