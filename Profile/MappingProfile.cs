using AutoMapper;
using StudentCourseAPI.Models;
using StudentCourseAPI.Models.DTOs;

namespace StudentCourseAPI.Profile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Student Mapping
            CreateMap<Student, StudentDto>();
            CreateMap<StudentCreateUpdate, Student>();

            //Course Mapping
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.StudentName,
                opt => opt.MapFrom(src => src.Student.FullName));

            CreateMap<CourseCreateUpdateDto, Course>()
                .ForMember(dest => dest.Student, opt => opt.Ignore());
        }
        
    }
}