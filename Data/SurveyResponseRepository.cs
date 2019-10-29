using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Interfaces;
using survey.Model;

namespace survey.Data
{
    public class SurveyResponseRepository : ISurveyResponseRepository
    {
        private readonly DatabaseContext _context = null;

        public SurveyResponseRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<SurveyResponse> GetResponses()
        {
            try
            {
                return _context.SurveyResponses.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddResponse(SurveyResponse item)
        {
            try
            {
                if (item != null)
                    _context.SurveyResponses.Add(item);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddUserResponse(UserResponse user)
        {
            try
            {
                if (user != null)
                    _context.UserResponses.Add(user);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool AddCouponCode(UserCoupon code)
        {
            try
            {
                if (code != null)
                    _context.UserCoupons.Add(code);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
