using Microsoft.AspNetCore.Mvc;
using StudentCourseAPI.Models;
using StudentCourseAPI.Services.IServices;

namespace StudentCourseAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await _courseService.GetAllCoursesAsync();
        return Ok(courses);
    }

    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetCourseById(int courseId)
    {
        var course = await _courseService.GetCourseByIdAsync(courseId);
        if(course == null) return NotFound("Course not found!");
        return Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> AddCourse(int studentId, Course newCourse)
    {
        await _courseService.AddCourseToStudentAsync(studentId, newCourse);
        return Ok(newCourse);
    }

    [HttpPut("{courseId}")]
    public async Task<IActionResult> UpdateCourse(int courseId, Course updatedCourse)
    {
        var existing = await _courseService.GetCourseByIdAsync(courseId);
        if(existing == null) return NotFound("Course not found!");
        await _courseService.UpdateCourseAsync(courseId, updatedCourse);
        return Ok(updatedCourse);
    }

    [HttpDelete("{courseId}")]
    public async Task<IActionResult> DeleteCourse(int courseId)
    {
        var course = await _courseService.GetCourseByIdAsync(courseId);
        if(course == null) return NotFound("Course not found!");

        await _courseService.DeleteCourse(courseId);
        return Ok($"Course with ID {courseId} Deleted!!");
    }


    
}