using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Model;

namespace survey.Interfaces
{
    public interface IUserResponseRepository
    {
        IEnumerable<SurveyResponse> GetResponses();
        
        // add new response document
        Task AddResponse(SurveyResponse item);
        Task AddResponseUser(UserResponse user);
        Task AddUserCoupon(UserCoupon code);

        
    }
}

