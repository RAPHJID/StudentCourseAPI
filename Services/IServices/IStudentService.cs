using StudentCourseAPI.Models;
using StudentCourseAPI.Services;

namespace StudentCourseAPI.Services.IServices
{

    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int studentId);
        void UpdateStudent(int studentId, Student updatedStudent);
        void AddStudent(Student newStudent);
        void DeleteStudent(int studentId);
        
    }

}