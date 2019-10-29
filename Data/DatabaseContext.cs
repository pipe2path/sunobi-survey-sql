using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
//using MongoDB.Driver;
using survey.Model;

namespace survey.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            :base(options)
        {
        }
                
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SurveyResponse> SurveyResponses { get; set; }
        public DbSet<UserResponse> UserResponses { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserCoupon> UserCoupons { get; set; }

    }
}
