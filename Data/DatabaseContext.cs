using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
//using MongoDB.Driver;
using survey.Model;
using Microsoft.EntityFrameworkCore.Metadata;

namespace survey.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        {
        }
                
        public DbSet<Entity> Entity { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Choice> Choice { get; set; }
        public DbSet<SurveyResponse> SurveyResponse { get; set; }
        public DbSet<UserResponse> UserResponse { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<UserCoupon> UserCoupon { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=SQL5045.site4now.net;database=DB_A4DADD_survey;User Id=DB_A4DADD_survey_admin;Password=Bombay79;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>(entity =>
            {
                entity.Property(e => e.entityId).HasColumnName("entityId");

                entity.Property(e => e.address)
                    .HasColumnName("address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.categoryId).HasColumnName("categoryId");

                entity.Property(e => e.contactName)
                    .HasColumnName("contactName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.entityName)
                    .HasColumnName("entityName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.website)
                    .HasColumnName("website")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.messageId).HasColumnName("messageId");

                entity.Property(e => e.code).HasColumnName("code");

                entity.Property(e => e.dateLastTextSent)
                    .HasColumnName("dateLastTextSent")
                    .HasColumnType("datetime");

                entity.Property(e => e.email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.message)
                    .HasColumnName("message")
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.userId).HasColumnName("userId");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.questionId).HasColumnName("questionId");

                entity.Property(e => e.displayOrder).HasColumnName("displayOrder");

                entity.Property(e => e.questionDesc)
                    .HasColumnName("questionDesc")
                    .IsUnicode(false);

                entity.Property(e => e.questionType)
                    .HasColumnName("questionType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.surveyId).HasColumnName("surveyId");
            });

            modelBuilder.Entity<Choice>(entity =>
            {
                entity.Property(e => e.choiceId).HasColumnName("choiceId");

                entity.Property(e => e.surveyId).HasColumnName("surveyId");
                
                entity.Property(e => e.questionId).HasColumnName("questionId");

                entity.Property(e => e.choiceText).HasColumnName("choiceText").IsUnicode(false);
            });

            modelBuilder.Entity<SurveyResponse>(entity =>
            {
                entity.ToTable("surveyResponse");

                entity.Property(e => e.surveyResponseId).HasColumnName("surveyResponseId");

                entity.Property(e => e.choice)
                    .HasColumnName("choice")
                    .IsUnicode(false);

                entity.Property(e => e.questionId).HasColumnName("questionId");

                entity.Property(e => e.surveyId).HasColumnName("surveyId");

                entity.Property(e => e.userResponseId).HasColumnName("userResponseId");
            });

            modelBuilder.Entity<UserCoupon>(entity =>
            {
                entity.Property(e => e.userCouponId).HasColumnName("userCouponId");

                entity.Property(e => e.couponCode).HasColumnName("couponCode");

                entity.Property(e => e.dateGenerated)
                    .HasColumnName("dateGenerated")
                    .HasColumnType("datetime");

                entity.Property(e => e.dateRedeemed)
                    .HasColumnName("dateRedeemed")
                    .HasColumnType("datetime");

                entity.Property(e => e.messageText)
                    .HasColumnName("messageText")
                    .IsUnicode(false);

                entity.Property(e => e.responseUserId).HasColumnName("userResponseId");
            });

            modelBuilder.Entity<UserResponse>(entity =>
            {
                entity.Property(e => e.userResponseId).HasColumnName("userResponseId");

                entity.Property(e => e.optIn).HasColumnName("optIn");

                entity.Property(e => e.surveyId).HasColumnName("surveyId");

                entity.Property(e => e.userEmail)
                    .HasColumnName("userEmail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.userName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.userPhone)
                    .HasColumnName("userPhone")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }

    }
}
