using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Data;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform
{
    internal class LearningPlatformActions
    {
        private readonly ApplicationDbContext Context;


        public LearningPlatformActions(ApplicationDbContext context)
        {
            this.Context = context;
        }


        public void AddInstructor(Instructor instructor)
        {
            if (instructor == null) throw new ArgumentNullException();
            Context.Instructors.Add(instructor);
            Context.SaveChanges();
            Console.WriteLine($"Instructor Added Successfully with ID {instructor.Id}");
        }

        public void AddCourse(Course course)
        {
            //Validations
            bool instructorExist = Context.Instructors.Any(i => i.Id == course.InstructorID);
            bool categoryExist = Context.Categories.Any(c => c.Id == course.CategoryID);

            if (instructorExist && categoryExist)
            {
                Context.Add(course);
                Context.SaveChanges();
                Console.WriteLine("Course added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid instructor or category.");
                return;
            }

        }

        public void AddStudent(List<Student> students)
        {
            Context.AddRange(students);
            Context.SaveChanges();
            Console.WriteLine("students added successfully.");
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            bool studentExist = Context.Students.Any(s => s.Id == enrollment.StudentId);
            bool courseExist = Context.Courses.Any(c => c.Id == enrollment.CourseId);
            var course = Context.Courses.FirstOrDefault(c => c.Id == enrollment.CourseId);
            bool studentEnrolled = Context.Enrollments.Any(sE => sE.StudentId == enrollment.StudentId && sE.CourseId == enrollment.CourseId);

            if (!studentExist || course == null)
            {
                Console.WriteLine("Student or course does not exist.");
                return;
            }

            if (!course.IsPublished)
            {
                Console.WriteLine("Cannot enroll in an unpublished course.");
                return;
            }

            if (studentEnrolled)
            {
                Console.WriteLine("Student is already enrolled.");
                return;
            }

            Context.Enrollments.Add(enrollment);

            Context.SaveChanges();

            Console.WriteLine("Enrollment completed successfully.");
        }

        public void FindCourseByID(int courseId)
        {
            var course = Context.Courses.Find(courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            Console.WriteLine($"Title: {course.Title}");
            Console.WriteLine($"Price: {course.Price}");
            Console.WriteLine($"Level: {course.Level}");
        }
        public void FindCourseByTitle(string title)
        {
            var course = Context.Courses.FirstOrDefault(c => c.Title == title);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            Console.WriteLine($"Title: {course.Title}");
            Console.WriteLine($"Price: {course.Price}");
            Console.WriteLine($"Level: {course.Level}");
        }

        public void FilterCourses(decimal priceLow, decimal priceHigh)
        {
            var courses = Context.Courses.Where(c=>c.Price < priceHigh && c.Price > priceLow)
                                           .OrderByDescending(c=>c.Price).ToList();
            foreach (var course in courses) {
                Console.WriteLine($"{course.Title} - {course.Price} - {course.Level}");
            }
        }

        public void SubCategories(int categoryId)
        {
            var subCategories = Context.Categories.Where(c => c.ParentCategoryId == categoryId).ToList();
            var topCategories = Context.Categories.Where(c => c.ParentCategoryId == null).ToList();

            Console.WriteLine("Direct Sub-Categories:");
            foreach (var category in subCategories)
            {
                Console.WriteLine($"{category.Name} - {category.ParentCategoryId}");
            }

            Console.WriteLine("Top Level Categories:");
            foreach (var category in topCategories)
            {
                Console.WriteLine(category.Name);
            }
        }

        public void CourseRoster(int courseId)
        {
            var course = Context.Courses.FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            var studentIDs = Context.Students.Select(s=>s.Id).ToList();
            var studentsEnrolled = Context.Enrollments.Where(e => e.CourseId == courseId && studentIDs.Contains(e.StudentId)).ToList();

            Console.WriteLine($"Course: {course.Title}");
            Console.WriteLine($"Total Enrollments: {studentsEnrolled.Count}");

            foreach(var enrollment  in studentsEnrolled)
            {
                var student = Context.Students.First(s=>s.Id == enrollment.StudentId);
                Console.WriteLine(student.FullName);
            }
        }
    }
}
