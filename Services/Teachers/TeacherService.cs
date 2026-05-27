using System;
using Models.Teachers;

namespace Services.Teachers;

public class TeacherService : ITeacherService
{

    private Teacher [] teachers = new Teacher [10];
    private int count = 0;

    public void CreateTeacher(Teacher teacher)
    {
        if( count > this.teachers.Length - 1)
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

        Console.Write("ID:");
        int id = Convert.ToInt32(Console.ReadLine());

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
}