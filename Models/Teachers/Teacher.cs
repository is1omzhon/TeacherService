using System;

namespace Models.Teachers;

public class Teacher
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Subject { get; set; }
    public double Rank { get; set; }
    public decimal Salary { get; set; }        
    public int Experience { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}