using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Data;
using OnlineLearningPlatform.Models;

namespace OnlineLearningPlatform
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ApplicationDbContext context = new ApplicationDbContext();
            #region Add Students
            //if (! context.Students.Any())
            //{
            //    var students = new List<Student>
            //    {
            //        new Student
            //        {
            //            FullName = "Ali Ahmed",
            //            Email = "ali@test.com",
            //            DateOfBirth = new DateTime(2000, 1, 10)
            //        },
            //        new Student
            //        {
            //            FullName = "Mona Hassan",
            //            Email = "mona@test.com",
            //            DateOfBirth = new DateTime(1995, 2, 15)
            //        },
            //        new Student
            //        {
            //            FullName = "Omar Ali",
            //            Email = "omar.student@test.com",
            //            DateOfBirth = new DateTime(1999, 3, 20)
            //        },
            //        new Student
            //        {
            //            FullName = "Sara Mohamed",
            //            Email = "sara.student@test.com",
            //            DateOfBirth = new DateTime(2002, 4, 25)
            //        },
            //        new Student
            //        {
            //            FullName = "Nour Ahmed",
            //            Email = "nour@test.com",
            //            DateOfBirth = new DateTime(2000, 5, 30)
            //        }
            //    };
            //    context.Students.AddRange(students);
            //    context.SaveChanges();

            //    //AddEnrollment
            //    var enrollments = new List<Enrollment>
            //    {
            //        new()
            //        {
            //            StudentId = students[0].Id,
            //            CourseId = 1,
            //            EnrollmentDate = DateTime.Now,
            //            Status = EnrollmentStatus.Completed,
            //            ProgressPercentage = 100,
            //            FinalGrade = 95
            //        },
            //        new()
            //        {
            //            StudentId = students[0].Id,
            //            CourseId = 2,
            //            EnrollmentDate = DateTime.Now,
            //            ProgressPercentage = 30,
            //            Status = EnrollmentStatus.Active
            //        },
            //        new()
            //        {
            //            StudentId = students[1].Id,
            //            CourseId = 1,
            //            EnrollmentDate = DateTime.Now,
            //            ProgressPercentage = 50,
            //        },
            //        new()
            //        {
            //            StudentId = students[1].Id,
            //            CourseId = 3,
            //            EnrollmentDate = DateTime.Now,
            //            ProgressPercentage = 100,
            //            Status = EnrollmentStatus.Completed,
            //            FinalGrade = 88
            //        },
            //        new()
            //        {
            //            StudentId = students[2].Id,
            //            CourseId = 2,
            //            EnrollmentDate = DateTime.Now,
            //            ProgressPercentage = 20,
            //            Status = EnrollmentStatus.Dropped
            //        },
            //        new()
            //        {
            //            StudentId = students[2].Id,
            //            CourseId = 4,
            //            EnrollmentDate = DateTime.Now,
            //            ProgressPercentage = 100,
            //            Status = EnrollmentStatus.Completed,
            //            FinalGrade = 90
            //        },
            //        new()
            //        {
            //            StudentId = students[3].Id,
            //            CourseId = 3,
            //            EnrollmentDate = DateTime.Now,
            //            ProgressPercentage = 65,
            //            Status = EnrollmentStatus.Active
            //        },
            //        new()
            //        {
            //            StudentId = students[4].Id,
            //            CourseId = 4,
            //            EnrollmentDate = DateTime.Now,
            //            ProgressPercentage = 10,
            //            Status = EnrollmentStatus.Active
            //        }
            //    };

            //    context.Enrollments.AddRange(enrollments);
            //    context.SaveChanges();
            //}

            #endregion

            #region Create
            //LearningPlatformActions actions = new LearningPlatformActions(context);
            //var instructor = new Instructor
            //{
            //    FullName = "Mary Ayad",
            //    DateJoined = DateTime.Now,
            //    Email = "mary@test.com"
            //};
            //actions.AddInstructor(instructor);

            //var students = new List<Student>
            //    {
            //        new()
            //        {
            //            FullName = "Student One",
            //            Email = "one@test.com",
            //            DateOfBirth = new DateTime(2000, 1, 1)
            //        },
            //        new()
            //        {
            //            FullName = "Student Two",
            //            Email = "two@test.com",
            //            DateOfBirth = new DateTime(2001, 2, 2)
            //        },
            //        new()
            //        {
            //            FullName = "Student Three",
            //            Email = "three@test.com",
            //            DateOfBirth = new DateTime(2002, 3, 3)
            //        }
            //    };
            //actions.AddStudent(students);

            //var enrollment = new Enrollment
            //{
            //    StudentId = 1,
            //    CourseId = 1,
            //    EnrollmentDate = DateTime.Now,
            //    ProgressPercentage = 0,
            //    Status = EnrollmentStatus.Active,
            //    FinalGrade = null
            //};

            //actions.AddEnrollment(enrollment);
            #endregion

            #region Read
            LearningPlatformActions actions = new LearningPlatformActions(context);

            actions.FilterCourses(500, 1000);
            actions.FindCourseByID(1);
            actions.FindCourseByTitle("SQL Fundamentals");
            actions.CourseRoster(4);
            #endregion
        }
    }
}
