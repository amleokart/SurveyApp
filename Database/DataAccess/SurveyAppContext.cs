using System;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Database.Models;

namespace SurveyApp.Database.DataAccess
{
    public class SurveyAppContext : DbContext
    {
        public SurveyAppContext(DbContextOptions options) : base(options)
        {
        }

        public SurveyAppContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerOption>()
                .HasKey(ao => new { ao.AnswerId, ao.OptionId });
            modelBuilder.Entity<AnswerOption>()
                .HasOne(ao => ao.Option)
                .WithMany(o => o.AnswerOptions)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Result)
                .WithMany(r => r.Answers)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
