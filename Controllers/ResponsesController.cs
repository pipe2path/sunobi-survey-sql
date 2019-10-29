using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using survey.Data;
using survey.Interfaces;
using survey.Model;
using Newtonsoft.Json.Linq;

namespace survey.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    //[EnableCors("AllowAllOrigins")]
    public class ResponsesController : Controller
    {
        public IUserResponseRepository _surveyResponseRepository;
        public IUserCouponRepository _userCouponRepository;

        public ResponsesController(IUserResponseRepository surveyResponseRepository, IUserCouponRepository userCouponRepository)
        {
            _surveyResponseRepository = surveyResponseRepository;
            _userCouponRepository = userCouponRepository;
        }

        [HttpGet]
        public IEnumerable<SurveyResponse> Get()
        {
            return _surveyResponseRepository.GetResponses().ToList();
        }

        //[HttpGet("{id}", Name = "GetById")]
        //public async Task<Response> GetById(string id)
        //{
        //    return await _surveyResponseRepository.GetResponseById(id);
        //}

        [HttpPost]
        public async Task Create([FromBody] ResponseJsonPayload payload)
        {
            try
            {
                if (payload != null && payload.responseDetails != null)
                {

                    UserResponse user = new UserResponse();
                    user.surveyId = payload.surveyId;
                    user.userName = payload.userName;
                    user.userPhone = payload.userPhone;
                    user.userEmail = payload.userEmail;
                    user.optIn = payload.optIn;

                    await _surveyResponseRepository.AddResponseUser(user);

                    // get _id of inserted item
                    var newUserId = user.userResponseId;

                    // construct response and user objects
                    var responseDetails = payload.responseDetails;
                    foreach (var rd in responseDetails)
                    {
                        SurveyResponse responseObj = new SurveyResponse();
                        responseObj.surveyId = rd.surveyId;
                        responseObj.questionId = rd.questionId;
                        responseObj.choice = rd.choice;
                        responseObj.userResponseId = newUserId;
                        
                        await _surveyResponseRepository.AddResponse(responseObj);
                    }

                    // generate random coupon code and insert into couponCode collection
                    int randomNum = GenerateRandomNo();
                    UserCoupon coupon = new UserCoupon();
                    coupon.responseUserId = newUserId;
                    coupon.couponCode = randomNum;
                    await _surveyResponseRepository.AddUserCoupon(coupon);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            int rdmNum = _rdm.Next(_min, _max);
            while (rdmNum == _userCouponRepository.CreateCouponCode(rdmNum))
                rdmNum = _rdm.Next(_min, _max);
            return rdmNum;
        }
    }

    public class ResponseJsonPayload
    {
        public int surveyId { get; set; }
        public string userName { get; set; }
        public string userPhone { get; set; }
        public string userEmail { get; set; }
        public bool optIn { get; set; }
        public SurveyResponse[] responseDetails { get;set;}
    }
}