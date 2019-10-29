using survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Interfaces
{
    public interface ISurveyResponseRepository
    {
        IEnumerable<SurveyResponse> GetResponses();
        bool AddResponse(SurveyResponse item);
        bool AddUserResponse(UserResponse user);
        bool AddCouponCode(UserCoupon code);
    }
}
