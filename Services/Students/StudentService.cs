using System;
using System.Collections.Generic;
using System.Linq;
using Models.Students;

namespace Services.Students;

public class StudentService : IStudentService
{
    private List<Student> students;
    private const int MaxCapacity = 30;

    public StudentService()
    {
        students = new List<Student>(30)
        {
          new Student
          {
            ID = Guid.NewGuid(),
            FirstName = "Ali",
            LastName = "Aliyev",
            Address = "Moskva",
            GPA = 4.5

          },
          new Student
          {
            ID = Guid.NewGuid(),
            FirstName = "Ali",
            LastName = "Aliyev",
            Address = "Moskva",
            GPA = 4.5

          },

          new Student
          {
             ID = Guid.Parse("550e8400-e29b-41d4-a716-446655440000"),
            FirstName = "Javid",
            LastName = "Roziev",
            Address = "Baku",
            GPA = 4.7

          }

        };
    }

    public void CreateStudent(Student student)
    {
        if (students.Count >= MaxCapacity)
        {
            Console.WriteLine("Database is full!");
            return;
        }

        students.Add(student);
        Console.WriteLine("Student successfully created!");
    }

    public void PrintStudentInfo(Student student)
    {
        if (student is null)
        {
            Console.WriteLine("Student is null");
            return;
        }
        Console.WriteLine("====================");
        Console.WriteLine(
            $"""
            Student Info:
                Student ID : {student.ID} 
                First Name: {student.FirstName}
                Last Name: {student.LastName}
                Addres: {student.Address}
                GPA : {student.GPA}
            """
        );
    }

    public Student GetStudentFormUser()
    {
        Console.WriteLine("=== NEW STUDENT ===\n");

        Console.Write("Enter GUID: ");
        string input = Console.ReadLine();

        if (Guid.TryParse(input, out Guid id))
        {
            Console.WriteLine($"Valid GUID: {id}");
        }
        else
        {
            Console.WriteLine("Invalid GUID format!");
        }

        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        if (string.IsNullOrEmpty(firstName))
        {
            Console.WriteLine("Xato! Ism bush bula olmaydi!!!");
            return null;
        }

        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();
        if (string.IsNullOrEmpty(lastName))
        {
            Console.WriteLine("Xato! Familiya bush bula olmaydi!");
            return null;
        }

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("GPA: ");
        double gpa = Convert.ToDouble(Console.ReadLine());

        return new Student
        {
            ID = id,
            FirstName = firstName,
            LastName = lastName,
            Address = address,
            GPA = gpa
        };
    }

    public Student GetStudentById(Guid studentId) =>
        this.students.FirstOrDefault(student => student.ID == studentId);

    public void UpdateStudent(Student student)
    {
        if (student is null)
        {
            Console.WriteLine("Student is null. Please, try with no nul student");
            return;
        }

        Student maybeStudent =
            this.students.FirstOrDefault(student => student.ID == student.ID);

        if (maybeStudent is null)
        {
            Console.WriteLine("Student is not found!!!");
            return;
        }

        maybeStudent.FirstName = student.FirstName;
        maybeStudent.LastName = student.LastName;
        maybeStudent.Address = student.Address;
        maybeStudent.GPA = student.GPA;

        Console.WriteLine("Student is succesfully updated!!!");
    }

    public void DeleteStudentById(Guid studentId)
    {
        Student maybeStudent =
            this.students.FirstOrDefault(student => student.ID == studentId);

        if (maybeStudent is null)
        {
            Console.WriteLine("Student is not found!");
            return;
        }
        this.students.Remove(maybeStudent);
    }

    public void InsertStudent(Student student) =>
        this.students.Add(student);

    List<Student> IStudentService.GetAllStudents() => this.students;
};