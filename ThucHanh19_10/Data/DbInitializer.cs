using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThucHanh19_10.Models;
using System;
using System.Linq;
using ThucHanh19_10.Data;
using ThucHanh19_10.Models;

namespace MyWebApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(
                serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                // Tạo cơ sở dữ liệu nếu chưa tồn tại
                context.Database.EnsureCreated();

                // Kiểm tra xem đã có dữ liệu trong bảng Majors chưa. Nếu có rồi thì không làm gì cả.
                if (context.Majors.Any())
                {
                    return; // DB đã được gieo mầm dữ liệu
                }

                // --- 1. Thêm các Chuyên ngành (Majors) ---
                var majors = new Major[]
                {
                    new Major{MajorName="IT"},
                    new Major{MajorName="Economics"},
                    new Major{MajorName="Mathematics"}
                };

                // Sử dụng AddRange để thêm hiệu quả hơn thay vì dùng vòng lặp foreach với Add
                context.Majors.AddRange(majors);
                context.SaveChanges();

                // --- 2. Thêm người học (Learners) ---
                var learners = new Learner[]
                {
                    new Learner { FirstMidName = "Carson", LastName = "Alexander",
                        EnrollmentDate = DateTime.Parse("2005-09-01"), MajorID = 1},
                    new Learner { FirstMidName = "Meredith", LastName = "Alonso",
                        EnrollmentDate = DateTime.Parse("2002-09-01"), MajorID = 2 }
                };

                // Sử dụng AddRange
                context.Learners.AddRange(learners);
                context.SaveChanges();

                // --- 3. Thêm khóa học (Courses) ---
                var courses = new Course[]
                {
                    new Course{CourseID=1050, Title="Chemistry", Credits=3},
                    new Course{CourseID=4022, Title="Microeconomics", Credits=3},
                    new Course{CourseID=4041, Title="Macroeconomics", Credits=3}
                };

                // Sử dụng AddRange
                context.Courses.AddRange(courses);
                context.SaveChanges();

                // --- 4. Thêm Đăng ký học (Enrollments) ---
                var enrollments = new Enrollment[]
                {
                    // Giả sử LearnerID 1 và 2 tương ứng với Carson và Meredith sau khi SaveChanges ở trên
                    new Enrollment{LearnerID=1, CourseID=1050, Grade=5.5f},
                    new Enrollment{LearnerID=1, CourseID=4022, Grade=7.5f},
                    new Enrollment{LearnerID=2, CourseID=1050, Grade=3.5f},
                    new Enrollment{LearnerID=2, CourseID=4041, Grade=7f}
                };

                // Sử dụng AddRange
                context.Enrollments.AddRange(enrollments);
                context.SaveChanges();
            }
        }
    }
}