using StudentCourseAPI.Models;
using StudentCourseAPI.Services;

namespace StudentCourseAPI.Services.IServices
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();
        Course GetCourseById(int courseId);
        void AddCourse(int studentId, Course newCourse);
        void UpdateCourse(int courseId, Course updatedCourse);
        void DeleteCourse(int courseId);
        
    }
    
    
}