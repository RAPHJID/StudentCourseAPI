using StudentCourseAPI.Models;
using StudentCourseAPI.Services.IServices;

namespace StudentCourseAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await _context.Courses.FindAsync(courseId);

        }

        public async Task AddCourseToStudentAsync(int studentId, Course newCourse)
        {

            var student = await _context.Students.Include
            (s => s.Courses).FirstOrDefaultAsync(s => s.studentId == studentId);
            if(studentId != null){
                _context.Courses.Add(newCourse);
                await _context.SaveChangesAnsync();
            }
           
        }

        public async Task UpdateCourseAsync(int courseId, Course updatedCourse)
        {
            var existing = await _context.Courses.FindAsync(courseId);

            if (existing != null)
                {
                    existing.Title = updatedCourse.Title;
                    existing.Description = updatedCourse.Description;
                    await _context.SaveChangesAnsync();
                }
        }

        public async Task DeleteCourse(int courseId)
        {
            var course = await _context.Courses.FindAsync();
            if(course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAnsync();
            }

        }
        
    }
}
