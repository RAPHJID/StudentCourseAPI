using StudentCourseAPI.Models;
using StudentCourseAPI.Services.IServices;

namespace StudentCourseAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly IStudentService _studentService;

        public CourseService(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public List<Course> GetAllCourses()
        {
            var allCourses = new List<Course>();
            var students = _studentService.GetAllStudents();

            foreach (var student in students)
            {
                allCourses.AddRange(student.Courses);
            }
            return allCourses;
        }

        public Course GetCourseById(int courseId)
        {
            var students = _studentService.GetAllStudents();
            foreach (var student in students)
            {
                var course = student.Courses.FirstOrDefault(c => c.Id == courseId);
                if (course != null)
                {
                    return course;
                }
                                
            }
            return null;
        }

        public void AddCourse(int studentId, Course newCourse)
        {
            var student = _studentService.GetStudentById(studentId);
            if (student != null)
            {
                student.Courses.Add(newCourse);
            }
            

        }

        public void UpdateCourse(int courseId, Course updatedCourse)
        {
            var students = _studentService.GetAllStudents();

            foreach (var student in students)
            {
                var course = student.Courses.FirstOrDefault(c => c.Id == courseId);
                if (course != null)
                {
                    course.Title = updatedCourse.Title;
                    course.Description = updatedCourse.Description;
                }
                
            }
        }

        public void DeleteCourse(int courseId)
        {
            var students = _studentService.GetAllStudents();

            foreach (var student in students)
            {
                var course = student.Courses.FirstOrDefault(c => c.Id == courseId);
                if (course != null)
                {
                    student.Courses.Remove(course);     
                }
                
            }
        }
        
    }
}