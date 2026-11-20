using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Configurations
{
    internal class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.ShortBio).HasMaxLength(500);
            builder.Property(i => i.DateJoined).IsRequired();

            builder.HasData(
    new Instructor
    {
        Id = 1,
        FullName = "Ahmed Mohamed",
        Email = "ahmed@test.com",
        ShortBio = "Backend Developer",
        DateJoined = new DateTime(2024, 1, 1)
    },
    new Instructor
    {
        Id = 2,
        FullName = "Sara Ali",
        Email = "sara@test.com",
        ShortBio = "Database Specialist",
        DateJoined = new DateTime(2024, 2, 1)
    },
    new Instructor
    {
        Id = 3,
        FullName = "Omar Hassan",
        Email = "omar@test.com",
        ShortBio = null,
        DateJoined = new DateTime(2024, 3, 1)
    }
);
        }
    }
}
