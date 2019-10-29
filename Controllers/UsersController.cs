﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using survey.Interfaces;
using survey.Model;

namespace survey.Controllers
{
    [Produces("application/json")]
    public class UsersController : Controller
    {
        public IUserRepository _userRepository;
        
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("users")]
        public IEnumerable<UserResponse> Get()
        {
            return _userRepository.GetResponseUsers();
        }

        [HttpGet]
        [Route("api/users/{phone}")]
        public UserResponse Get(string phone)
        {
            return _userRepository.GetResponseUserByPhone(phone);
        }

        [HttpGet]
        [Route("api/users/couponlist")]
        public IEnumerable<UserCoupon> GetCouponList()
        {
            return _userRepository.GetCouponList();
        }

        //[HttpPut]
        //[Route("api/users/couponlist")]
        //public async Task SaveCouponList([FromBody] IEnumerable<CouponJsonPayload> payload)
        //{
        //    try
        //    {
        //        if (payload != null )
        //        {
        //            foreach (var p in payload)
        //            {
        //                CouponCode couponCode = await _couponCodeRepository.GetCouponCodeByCode(p.code);
        //                couponCode.message = p.message;
        //                await _couponCodeRepository.UpdateCoupon(couponCode);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
    }

    public class CouponJsonPayload
    {
        [BsonId]
        public string internalId { get; set; }
        public int surveyId { get; set; }
        public string userName { get; set; }
        public string userPhone { get; set; }
        public string userEmail { get; set; }
        public bool optIn { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }
}