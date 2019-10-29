using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Model
{
    public class UserCoupon 
    {
        public int userCouponId { get; set; }
        public int responseUserId { get;set; }
        public int couponCode { get; set; }
        public string messageText { get; set; }
        public DateTime dateGenerated { get; set; }
        public DateTime dateRedeemed { get; set; }

        //public UserCoupon() { }
        //public UserCoupon(ResponseUser responseUser)
        //{
        //    this.internalId = responseUser.internalId;
        //    this.userId = new ObjectId();
        //    this.userName = responseUser.userName;
        //    this.userPhone = responseUser.userPhone;
        //    this.userEmail = responseUser.userEmail;
        //    this.message = "";
        //    this.code = 0;
        //}
    }
}
