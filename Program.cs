using System;
using System.Reflection.Metadata;
using Models.Students;
using Models.Teachers;
using Services.Students;
using Services.Teachers;

int length = 10;

StudentService service = new StudentService();


for (int i = 3; i < length; i++)
{
    Console.WriteLine($"\n--- STUDENT {i + 1} ---");
    
    Student student = service.GetStudentFormUser();
    
    if (student != null)
    {
        service.CreateStudent(student);
        Console.WriteLine($"STUDENT {i + 1} added!");
    }
    else
    {
        Console.WriteLine($"Error! Student {i + 1} don't added.");
        i--; 
    }
}

Console.WriteLine("\n\n=== ALL STUDENTS ===");
Student[] allStudents = service.GetAllStudents();
foreach (var student in allStudents)
{
    service.PrintStudentInfo(student);
}

Console.WriteLine("==========================================");


TeacherService teacherService = new TeacherService();

for (int i = 0; i < length; i++)
{
    Console.WriteLine($"\n--- TEACHER {i + 1} ---");

    Teacher newTeacher = teacherService.GetTeachersFromUser();

    if (newTeacher != null)
    {
        teacherService.CreateTeacher(newTeacher);
        Console.WriteLine($"TEACHER {i + 1} added!");
    }
    else
    {
        Console.WriteLine($"Error! Teacher {i + 1} don't added.");
        i--; 
    }
    
}

Console.WriteLine("\n\n=== ALL TEACHERS ===");
Teacher[] allTeachers = teacherService.GetAllTeachers();
foreach (var teacher in allTeachers)
{
    teacherService.TeacherPrintInfo(teacher);
}

