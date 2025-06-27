using StudentCourseAPI.Models;
using StudentCourseAPI.Services;

namespace StudentCourseAPI.Services.IServices
{

    public interface IStudentService
    {
       Task<List<Student>> GetAllStudentsAsync();
       Task<Student?> GetStudentByIdAsync(int studentId);
       Task AddStudentAsync(Student newStudent);
       Task UpdateStudentAsync(int studentId, Student updatedStudent);
       Task DeleteStudentAsync(int studentId);
    }

}
