using System;
using Models.Teachers;

namespace Services.Teachers;

public class TeacherService : ITeacherService
{

    private Teacher[] teachers = new Teacher[10];
    private int count = 0;

    public void CreateTeacher(Teacher teacher)
    {
        if (count > this.teachers.Length - 1)
        {
            Console.WriteLine("Database is full");
            return;
        }
        this.teachers[count] = teacher;
        count++;

    }

    public Teacher[] GetAllTeachers()
    {
        return this.teachers;
    }

    public Teacher GetTeachersFromUser()
    {
        Console.WriteLine("=== NEW Teacher ===\n");

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

        Console.Write("FirstName: ");
        string firstName = Console.ReadLine();

        Console.Write("LastName: ");
        string lastName = Console.ReadLine();

        Console.Write("Subject: ");
        string subject = Console.ReadLine();

        Console.Write("Rank: ");
        double rank = Convert.ToDouble(Console.ReadLine());



        return new Teacher
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Subject = subject,
            Rank = rank
        };
    }

    public void TeacherPrintInfo(Teacher teacher)
    {
        if (teacher is null)
        {
            Console.WriteLine("Teacher is null");
        }

        Console.WriteLine("==================");
        Console.WriteLine(
            $"""
            Teacher Info:
                ID: {teacher.Id},
                FirstName: {teacher.FirstName},
                LastName: {teacher.LastName},
                Subject : {teacher.Subject}
                Rank: {teacher.Rank}
            """
        );
    }

    public Teacher GetTeacherById(Guid teacherId)
    {
        foreach (Teacher teacher in this.teachers)
        {
            if (teacher?.Id == teacherId)
            {
                return teacher;
            }
        }
        return null;
    }

    public void UpdateTeacher(Teacher teacher)
    {
        if (teacher is null)
        {
            Console.WriteLine("Student is null. Please, try with no nul student");
            return;
        }

        foreach (Teacher storageTeacher in this.teachers)
        {
            if (storageTeacher.Id == teacher.Id)
            {
                storageTeacher.FirstName = teacher.FirstName;
                storageTeacher.LastName = teacher.LastName;
                storageTeacher.Subject = teacher.Subject;
                storageTeacher.Rank = teacher.Rank;
                Console.WriteLine("Student is succesfully updated!!!");

                return;
            }
        }

        Console.WriteLine("Student is not found!!!");
    }

    public void DeleteTeacherById(Guid teacherId)
    {
        for (int i = 0; i < this.teachers.Length; i++)
        {
            if (this.teachers[i]?.Id == teacherId)
            {
                this.teachers[i] = null;
                Console.WriteLine("Student succesfully deleted!!");
            }
        }
    }
}