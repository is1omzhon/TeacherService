using System;
using Models.Students;

namespace Services.Students;

public class StudentService : IStudentService
{
    private Student[] students = new Student[10];
    private int count = 0;

    public StudentService()
    {
        students[0] = new Student
        {
            ID = 1,
            FirstName = "Ali",
            LastName = "Aliyev",
            Address = "Moskva",
            GPA = 4.5
        };

        students[1] = new Student
        {
            ID = 2,
            FirstName = "Vali",
            LastName = "Valiyev",
            Address = "Petr",
            GPA = 4.4
        };

        students[2] = new Student
        {
            ID = 3,
            FirstName = "Javid",
            LastName = "Roziev",
            Address = "Baku",
            GPA = 4.7
        };

        count = 3;
    }

    public void CreateStudent(Student student)
    {
        if (count > this.students.Length - 1)
        {
            Console.WriteLine("Database is full");
            return;
        }
        this.students[count] = student;
        count++;
    }

    public Student[] GetAllStudents()
    {
        return this.students;
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

        Console.Write("ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Xato! ID son bulishi kerak!!!");
            return null;
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
}