using System;
using System.Collections.Generic;
using System.Linq;
using Models.Teachers;

namespace Services.Teachers;

public class TeacherServicee : ITeacherService
{

    private List<Teacher> teachers;
    private const int MaxCapacity = 30;

    public void CreateTeacher(Teacher teacher)
    {
        if (teachers.Count >= MaxCapacity)
        {
            Console.WriteLine("Database is full!");
            return;
        }

        teachers.Add(teacher);
        Console.WriteLine("Teacher successfully created!");

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
        Teacher maybeTeacher =
            this.teachers.FirstOrDefault(teacher => teacher.Id == teacherId);

        if (maybeTeacher is null)
        {
            Console.WriteLine("Student is not found!");
            return;
        }
        this.teachers.Remove(maybeTeacher);
    }

    public void InsertTeacher(Teacher teacher) =>
        this.teachers.Add(teacher);

    public List<Teacher> GetAllTeachers()
    {
        return teachers.ToList();
    }
}