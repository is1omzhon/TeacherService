using System;

namespace Models.Students
{
    public class Student
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public double GPA { get; set; }
        public string ClassRoom { get; set; }
        
    
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        public string GetFullName() => $"{FirstName} {LastName}";
        
        public string FullName => $"{FirstName} {LastName}";
    }
}