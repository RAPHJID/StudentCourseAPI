using Microsoft.AspNetCore.Mvc;
using StudentCourseAPI.Models;
using StudentCourseAPI.Services.IServices;


namespace StudentCourseAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await _studentService.GetAllStudentsAsync();
        return Ok(students);
    } 

    [HttpGet("{studentId}")]
    public async Task<IActionResult> GetStudentById(int studentId)
    {
        var student = await _studentService.GetStudentByIdAsync(studentId);
        if (student == null) return NotFound("Student Not Found");
        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent(Student newStudent)
    {
        await _studentService.AddStudentAsync(newStudent);
        return Ok(newStudent);

    }

    [HttpPut("{studentId}")]
    public async Task<IActionResult> UpdateStudent(int studentId, Student updatedStudent)
    {
        var existing = await _studentService.GetStudentByIdAsync(studentId);
        if(existing == null) return NotFound("Student Not Found!");

        await _studentService.UpdateStudentAsync(studentId,  updatedStudent);
        return Ok(updatedStudent);

    }

    [HttpDelete("{studentId}")]
    public async Task<IActionResult> DeleteStudent(int studentId)
    {
        var student = await _studentService.GetStudentByIdAsync(studentId);
        if(student == null) return NotFound("Student not Found!");
        await _studentService.DeleteStudentAsync(studentId);
        return Ok($"Student with ID {studentId} DELETED!!");

    }

    
    
}