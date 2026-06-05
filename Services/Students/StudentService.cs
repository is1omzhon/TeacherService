using System;
using System.Collections.Generic;
using System.Linq;
using Models.Students;

namespace Services.Students;

public class StudentService : IStudentService
{
    private Dictionary<Guid, Student> students;  
    private const int MaxCapacity = 30;

    public StudentService()
    {
        students = new Dictionary<Guid, Student>();
        
        var student1 = new Student
        {
            ID = Guid.NewGuid(),
            FirstName = "Ali",
            LastName = "Aliyev",
            Address = "Moskva",
            GPA = 4.5,
            ClassRoom = "9 A"           
        };
        students.Add(student1.ID, student1);
        
        var student2 = new Student
        {
            ID = Guid.NewGuid(),
            FirstName = "Vali",
            LastName = "Valiyev",
            Address = "Toshkent",
            GPA = 4.4,
            ClassRoom = "10 B"
        };
        students.Add(student2.ID, student2);
        
        var student3 = new Student
        {
            ID = Guid.Parse("550e8400-e29b-41d4-a716-446655440000"),
            FirstName = "Javid",
            LastName = "Roziev",
            Address = "Baku",
            GPA = 4.7,
            ClassRoom = "11 A"
        };
        students.Add(student3.ID, student3);
    }

    public void CreateStudent(Student student)
    {
        if (students.Count >= MaxCapacity)
        {
            Console.WriteLine(" Database is full!");
            return;
        }
        
        if (students.ContainsKey(student.ID))
        {
            Console.WriteLine("Student with this ID already exists!");
            return;
        }
        
        students.Add(student.ID, student);  
        Console.WriteLine("Student successfully created!");
    }

    public List<Student> GetAllStudents()
    {
        return students.Values.ToList();  
    }

    public Student GetStudentById(Guid studentId)
    {
        if (students.TryGetValue(studentId, out Student student))
            return student;
        
        return null;
    }

    public void UpdateStudent(Student student)
    {
        if (student is null)
        {
            Console.WriteLine("Student is null!");
            return;
        }
        
        if (!students.ContainsKey(student.ID))
        {
            Console.WriteLine("Student not found!");
            return;
        }
        
        students[student.ID] = student;  
        Console.WriteLine("Student successfully updated!");
    }

    public void DeleteStudentById(Guid studentId)
    {
        if (students.Remove(studentId))
        {
            Console.WriteLine(" Student successfully deleted!");
        }
        else
        {
            Console.WriteLine("Student not found!");
        }
    }

    public List<Student> GetStudentsByName(string name, int pageNumber, int pageSize)
    {
        if (string.IsNullOrEmpty(name))
            return new List<Student>();
        
        return students.Values
            .Where(s => s.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) || 
                        s.LastName.Contains(name, StringComparison.OrdinalIgnoreCase))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public Student GetStudentFormUser()
    {
        Console.WriteLine("=== NEW STUDENT ===\n");

        Console.Write("Enter GUID (or press Enter for auto-generate): ");
        string input = Console.ReadLine();
        
        Guid id;
        if (string.IsNullOrEmpty(input))
        {
            id = Guid.NewGuid();
            Console.WriteLine($"Auto-generated GUID: {id}");
        }
        else if (!Guid.TryParse(input, out id))
        {
            Console.WriteLine("Invalid GUID format!");
            return null;
        }

        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        if (string.IsNullOrEmpty(firstName))
        {
            Console.WriteLine("First name cannot be empty!");
            return null;
        }

        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();
        if (string.IsNullOrEmpty(lastName))
        {
            Console.WriteLine("Last name cannot be empty!");
            return null;
        }

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("GPA: ");
        if (!double.TryParse(Console.ReadLine(), out double gpa))
        {
            Console.WriteLine("Invalid GPA format!");
            return null;
        }
        
        Console.Write("Class Room : ");
        string classRoom = Console.ReadLine();

        return new Student
        {
            ID = id,
            FirstName = firstName,
            LastName = lastName,
            Address = address,
            GPA = gpa,
            ClassRoom = classRoom
        };
    }

    public void PrintStudentInfo(Student student)
    {
        if (student is null)
        {
            Console.WriteLine("Student is null");
            return;
        }
        
        Console.WriteLine("====================");
        Console.WriteLine($"""
            Student Info:
                Student ID : {student.ID}
                First Name: {student.FirstName}
                Last Name: {student.LastName}
                Address: {student.Address}
                GPA: {student.GPA}
                Class Room: {student.ClassRoom}
            """);
    }

    public void GetStudentCountByClass()
    {
        var groups = students.Values
            .Where(s => !string.IsNullOrEmpty(s.ClassRoom))
            .GroupBy(s => s.ClassRoom)
            .OrderBy(g => g.Key);
        
        Console.WriteLine("\nSTUDENT COUNT BY CLASS:");
        Console.WriteLine("═══════════════════════════");
        
        if (!groups.Any())
        {
            Console.WriteLine("No students with class room assigned!");
            return;
        }
        
        foreach (var group in groups)
        {
            Console.WriteLine($" {group.Key}: {group.Count()} ta o'quvchi");
        }
        
        Console.WriteLine("═══════════════════════════");
        Console.WriteLine($"Jami: {students.Count} ta o'quvchi");
    }
}