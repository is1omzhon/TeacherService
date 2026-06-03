using System;
using Models.Students;

namespace Services.Students;

public class StudentService : IStudentService
{
    private Student[] students = new Student[5];
    private int count = 0;

    public StudentService()
    {
        students[0] = new Student
        {
            ID = Guid.NewGuid(),
            FirstName = "Ali",
            LastName = "Aliyev",
            Address = "Moskva",
            GPA = 4.5
        };

        students[1] = new Student
        {
            ID = Guid.Parse("123e4567-e89b-12d3-a456-426614174000"),
            FirstName = "Vali",
            LastName = "Valiyev",
            Address = "Petr",
            GPA = 4.4
        };

        students[2] = new Student
        {
            ID = Guid.Parse("550e8400-e29b-41d4-a716-446655440000"),
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

        Console.Write("Enter GUID: ");
        string input = Console.ReadLine();

        if (Guid.TryParse(input, out Guid id))
        {
            Console.WriteLine($"✅ Valid GUID: {id}");
        }
        else
        {
            Console.WriteLine("❌ Invalid GUID format!");
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

    public Student GetStudentById(Guid studentId)
    {
        foreach (Student student in this.students)
        {
            if (student?.ID == studentId)
            {
                return student;
            }
        }

        return null;
    }

    public void UpdateStudent(Student student)
    {
        if (student is null)
        {
            Console.WriteLine("Student is null. Please, try with no nul student");
            return;
        }

        foreach(Student storageStudent in this.students)
        {
            if (storageStudent.ID== student.ID)
            {
                storageStudent.FirstName = student.FirstName;
                storageStudent.LastName = student.LastName;
                storageStudent.Address = student.Address;
                storageStudent.GPA = student.GPA;
                Console.WriteLine("Student is succesfully updated!!!");

                return;
            }
        }

        Console.WriteLine("Student is not found!!!");
    }

    public void DeleteStudentById(Guid studentId)
    {
        for (int i = 0; i < this.students.Length; i++)
        {
            if (this.students[i]?.ID == studentId)
            {
                this.students[i] = null;
                Console.WriteLine("Student succesfully deleted!!");
            }
        }
    }
}