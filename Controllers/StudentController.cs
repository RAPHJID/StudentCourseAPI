using Microsoft.AspNetCore.Mvc;
using StudentCourseAPI.Models;
using StudentCourseAPI.Services.IServices;


namespace StudentCourseAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly IStudentService _studentService;

    public StudentController(ILogger<StudentController> logger, IStudentService studentService)
    {
        _logger = logger;
        _studentService = studentService;
    }

    [HttpGet]
    public IActionResult GetAllStudents()
    {
        return Ok(_studentService.GetAllStudents());
    } 

    [HttpGet("{studentId}")]
    public IActionResult GetStudentById(int studentId)
    {
        var student = _studentService.GetStudentById(studentId);
        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public IActionResult AddStudent(Student newStudent)
    {
        _studentService.AddStudent(newStudent);
        return Ok(newStudent);

    }

    [HttpPut("{studentId}")]
    public IActionResult UpdateStudent(int studentId, Student updatedStudent)
    {
        var existing = _studentService.GetStudentById(studentId);
        if(existing == null) return NotFound();

        _studentService.UpdateStudent(studentId,  updatedStudent);
        return Ok(updatedStudent);

    }

    [HttpDelete("{studentId}")]
    public IActionResult DeleteStudent(int studentId)
    {
        var student = _studentService.GetStudentById(studentId);
        if(student == null) return NotFound();
        _studentService.DeleteStudent(studentId);
        return Ok($"Student with ID {studentId} DELETED!!");

    }

    
    
}