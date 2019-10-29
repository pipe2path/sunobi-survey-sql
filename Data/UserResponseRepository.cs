using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using survey.Model;
using survey.Interfaces;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace survey.Data
{
    public class UserResponseRepository : IUserResponseRepository
    {
        private readonly DatabaseContext _context = null;

        public UserResponseRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<SurveyResponse> GetResponses()
        {
            try
            {
                return _context.SurveyResponse.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddResponse(SurveyResponse item)
        {
            try
            {
                await _context.SurveyResponse.AddAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddResponseUser(UserResponse user)
        {
            try
            {
                await _context.UserResponse.AddAsync(user);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddUserCoupon(UserCoupon userCoupon)
        {
            try
            {
                await _context.UserCoupon.AddAsync(userCoupon);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }


    }


}
