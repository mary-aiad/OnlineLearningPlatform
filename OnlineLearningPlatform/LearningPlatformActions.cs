using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public void UpdateCoursePrice(int courseId, decimal newPrice)
        {
            if (newPrice < 0)
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            var course = Context.Courses.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }
           
            course.Price = newPrice;
            Context.SaveChanges();
            Console.WriteLine("Course price updated.");


        }

        public void updateEnrollmentProgress(int studentID, int courseId, decimal newProgress)
        {
            if (newProgress < 0 || newProgress > 100)
            {
                Console.WriteLine("Progress must be between 0 and 100.");
                return;
            }

            var enrollment = Context.Enrollments.FirstOrDefault(c => c.CourseId == courseId && c.StudentId == studentID);
            if(enrollment == null)
            {
                Console.WriteLine("Enrollment not found.");
                return;
            }

            enrollment.ProgressPercentage = newProgress;

            if(newProgress == 100)
            {
                enrollment.Status = EnrollmentStatus.Completed;
            }

            Context.SaveChanges();

            Console.WriteLine("Enrollment Progress Updated successfully.");
        }

        public void PublishCourse(int courseID)
        {
            var course = Context.Courses.FirstOrDefault(c => c.Id == courseID);
            if(course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            course.PublishedDate = DateTime.Now;
            course.IsPublished = true;

            Context.SaveChanges();
            Console.WriteLine("Course published successfully.");
        }


        public void Unenroll(int studentID, int courseId)
        {
            var enrollment = Context.Enrollments.FirstOrDefault(c => c.CourseId == courseId && c.StudentId == studentID);
            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found.");
                return;
            }

            Context.Enrollments.Remove(enrollment);
            Context.SaveChanges();
            Console.WriteLine("Student unenrolled successfully.");
        }

        public void DeleteCategory(int categoryId)
        {
            var category = Context.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            bool hasSubCategories = Context.Categories.Any(c => c.ParentCategoryId == categoryId);
            if (hasSubCategories)
            {
                Console.WriteLine("Cannot delete category because it has sub-categories.");
                return;
            }

            Context.Categories.Remove(category);
            try
            {
                Context.SaveChanges();
                Console.WriteLine("Category deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot delete category because it has related courses.");
            }
        }

        public void DeleteCourse(int courseId)
        {
            var course = Context.Courses.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            var enrollments = Context.Enrollments
                                    .Where(e => e.CourseId == courseId)
                                    .ToList();
            try
            {
                Context.Enrollments.RemoveRange(enrollments);
                Context.SaveChanges();

                Context.Courses.Remove(course);
                Context.SaveChanges();
                Console.WriteLine($"{enrollments.Count} enrollments were removed because " + "the course was deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Course deletion failed.");
            }
        }

        public void RaiseCoursePrice(CourseLevel courseLevel, decimal raisedPercentage)
        {

            int affectedRows = Context.Courses.Where(c => c.IsPublished && c.Level == courseLevel)
                                                    .ExecuteUpdate(setter => setter.SetProperty(c => c.Price, c => c.Price * raisedPercentage));
            
            Console.WriteLine($"Updated courses: {affectedRows}");
        }

        public void DeleteBulk(EnrollmentStatus enrollmentStatus)
        {
            var affectedRows = Context.Enrollments.Where(e => e.Status == enrollmentStatus)
                                                    .ExecuteDelete();
            Console.WriteLine($"Deleted enrollments: {affectedRows}");
        }
    }
}
