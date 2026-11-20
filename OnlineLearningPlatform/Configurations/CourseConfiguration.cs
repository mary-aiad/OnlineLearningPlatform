using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Description)
                .HasMaxLength(1000);

            builder.Property(c => c.Price)
                .HasPrecision(18, 2);

            builder.Property(c => c.Level)
                .IsRequired();

            builder.Property(c => c.IsPublished)
                .IsRequired();

            builder.Property(c => c.PublishedDate)
                .IsRequired(false);

            builder.HasOne(c => c.Instructor)
                .WithMany(c => c.Courses)
                .HasForeignKey(c => c.InstructorID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Category)
                .WithMany(c => c.Courses)
                .HasForeignKey(c => c.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
    new Course
    {
        Id = 1,
        Title = "C# Fundamentals",
        Description = "Learn C# basics",
        Price = 500,
        Level = CourseLevel.Beginner,
        IsPublished = true,
        PublishedDate = new DateTime(2025, 1, 1),
        InstructorID = 1,
        CategoryID = 1
    },
    new Course
    {
        Id = 2,
        Title = "OOP with C#",
        Description = "Object oriented programming",
        Price = 700,
        Level = CourseLevel.Intermediate,
        IsPublished = true,
        PublishedDate = new DateTime(2025, 2, 1),
        InstructorID = 1,
        CategoryID = 1
    },
    new Course
    {
        Id = 3,
        Title = "ASP.NET Core",
        Description = "Build web applications",
        Price = 1000,
        Level = CourseLevel.Advanced,
        IsPublished = true,
        PublishedDate = new DateTime(2025, 3, 1),
        InstructorID = 1,
        CategoryID = 1
    },
    new Course
    {
        Id = 4,
        Title = "SQL Fundamentals",
        Description = "Learn SQL",
        Price = 400,
        Level = CourseLevel.Beginner,
        IsPublished = true,
        PublishedDate = new DateTime(2025, 4, 1),
        InstructorID = 1,
        CategoryID = 1
    },
    new Course
    {
        Id = 5,
        Title = "Advanced SQL",
        Description = "Advanced database concepts",
        Price = 800,
        Level = CourseLevel.Advanced,
        IsPublished = false,
        PublishedDate = null,
        InstructorID = 1,
        CategoryID = 1
    },
    new Course
    {
        Id = 6,
        Title = "Entity Framework Core",
        Description = "Learn EF Core",
        Price = 900,
        Level = CourseLevel.Intermediate,
        IsPublished = false,
        PublishedDate = null,
        InstructorID = 1,
        CategoryID = 1
    }
);

        }
    }
}
