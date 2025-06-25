using Microsoft.AspNetCore.Mvc;
using StudentCourseAPI.Models;
using StudentCourseAPI.Services.IServices;

namespace StudentCourseAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class CourseController : ControllerBase
{
    public readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public IActionResult GetAllCourses()
    {
        return Ok(_courseService.GetAllCourses());
    }

    [HttpGet("{courseId}")]
    public IActionResult GetCourseById(int courseId)
    {
        var course = _courseService.GetCourseById(courseId);
        if(course == null) return NotFound();
        return Ok(course);
    }

    [HttpPost]
    public IActionResult AddCourse(int studentId, Course newCourse)
    {
        _courseService.AddCourse(studentId, newCourse);
        return Ok(newCourse);
    }

    [HttpPut("{courseId}")]
    public IActionResult UpdateCourse(int courseId, Course updatedCourse)
    {
        var existing = _courseService.GetCourseById(courseId);
        if(existing == null) return NotFound();
        _courseService.UpdateCourse(courseId, updatedCourse);
        return Ok(updatedCourse);
    }

    [HttpDelete("{courseId}")]
    public IActionResult DeleteCourse(int courseId)
    {
        var course = _courseService.GetCourseById(courseId);
        if(course == null) return NotFound();

        _courseService.DeleteCourse(courseId);
        return Ok($"Course with ID {courseId} Deleted!!");
    }


    
}