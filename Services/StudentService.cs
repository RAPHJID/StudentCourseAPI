using StudentCourseAPI.Models;
using StudentCourseAPI.Services.IServices;

namespace StudentCourseAPI.Services
{

    
    public class StudentService : IStudentService
    {
        //Fake Data
        private static List<Student> _students = new List<Student>
        {
            new Student
                {
                    Id = 1,
                    FullName = "Alice Mwangi",
                    Email = "alice@example.com",
                    Courses = new List<Course>
                    {
                        new Course { Id = 1, Title = "Math 101", Description = "Intro to Mathematics" },
                        new Course { Id = 2, Title = "Physics 101", Description = "Basics of Physics" }
                    }
                },
            new Student
                {
                    Id = 2,
                    FullName = "Brian Otieno",
                    Email = "brian@example.com",
                    Courses = new List<Course>
                    {
                        new Course { Id = 3, Title = "Chemistry 101", Description = "Intro to Chemistry" }
                    }
                },
            new Student
                {
                    Id = 3,
                    FullName = "Cynthia Njeri",
                    Email = "cynthia@example.com",
                    Courses = new List<Course>() // No courses yet
                }
        };



        public List<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudentById(int studentId)
        {
            var student = _students.FirstOrDefault(s => s.Id == studentId);
            return(student);
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public void UpdateStudent(int studentId, Student updatedStudent)
        {
            var existingStudent = _students.FirstOrDefault(e => e.Id == studentId);
            if(existingStudent != null)
            {
                existingStudent.FullName = updatedStudent.FullName;
                existingStudent.Email = updatedStudent.Email;
                existingStudent.Courses = updatedStudent.Courses;
            }
        }

        public void DeleteStudent(int studentId)
        {
            var student = _students.FirstOrDefault(s => s.Id == studentId);
            if(student!= null)
            {
                 _students.Remove(student);
            }
           
        }

    }
}