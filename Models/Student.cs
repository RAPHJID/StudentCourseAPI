namespace StudentCourseAPI.Models
{
    public class Student
    {
        public int Id {get;set;}
        public string FullName {get;set;}
        public string Email {get;set;}

        //child resource
        public List<Course> Courses {get;set;} = new List<Course> ();
    }
}