using StudentCourseAPI.Models;
using StudentCourseAPI.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace StudentCourseAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
       
        public StudentService(AppDbContext context) => _context = context;

        public async Task<List<Student>GetAllStudentsAsync() => return await _context.Students.Include(s => s.Courses).AsNoTracking().ToListAsync();
        
        public async Task<Student?> GetStudentByIdAsync(int studentId) => return await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.Id == studentId);
        

        public async Task AddStudentAsync(Student newStudent)
        {
            await _context.Students.AddAsync(newStudent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(int studentId, Student updatedStudent)
        {
           var existing = await GetStudentByIdAsync(studentId);
           ?? throw new KeyNotFoundException("Student not found");

           _context.Entry(existing).CurrentValues.SetValues(updatedStudent);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(int studentId)
        {
           var student = await GetStudentById(studentId);
           ?? throw new KeyNotFoundException("Student not found");

           _context.Students.Remove(student);
           await _context.SaveChangesAsync();


        }

    }
}