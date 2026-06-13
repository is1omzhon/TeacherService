using System;
using System.Collections.Generic;
using System.Linq;
using Models.Students;
using TeacherService.Repositories;

namespace Services.Students;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    
    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    // 1. Student yaratish
    public void CreateStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student), "Student null bo'lishi mumkin emas");
        }
        
        if (string.IsNullOrWhiteSpace(student.FullName))
        {
            throw new ArgumentException("Student ismi bo'sh bo'lishi mumkin emas");
        }
        
        _studentRepository.CreateStudent(student);
    }
    
    // 2. Barcha studentlarni olish
    public List<Student> GetAllStudents()
    {
        return _studentRepository.GetAllStudents();
    }
    
    // 3. ID bo'yicha student olish
    public Student GetStudentById(Guid studentId)
    {
        if (studentId == Guid.Empty)
        {
            throw new ArgumentException("Student ID noto'g'ri");
        }
        
        return _studentRepository.GetStudentById(studentId);
    }
    
    // 4. Studentni yangilash
    public void UpdateStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }
        
        var existingStudent = _studentRepository.GetStudentById(student.Id);
        if (existingStudent == null)
        {
            throw new Exception($"ID {student.Id} bo'lgan student topilmadi");
        }
        
        _studentRepository.UpdateStudent(student);
    }
    
    // 5. ID bo'yicha student o'chirish
    public void DeleteStudentById(Guid studentId)
    {
        if (studentId == Guid.Empty)
        {
            throw new ArgumentException("Student ID noto'g'ri");
        }
        
        var student = _studentRepository.GetStudentById(studentId);
        if (student == null)
        {
            throw new Exception($"ID {studentId} bo'lgan student topilmadi");
        }
        
        _studentRepository.DeleteStudent(student);
    }
    
    // 6. Foydalanuvchidan student ma'lumotlarini olish
    public Student GetStudentFormUser()
    {
        Console.WriteLine("=== Yangi student qo'shish ===");
        
        Console.Write("Ism familiya: ");
        string? fullName = Console.ReadLine();
        
        Console.Write("Sinf (1-11): ");
        if (!int.TryParse(Console.ReadLine(), out int grade))
        {
            grade = 1;
        }
        
        Console.Write("Yoshi: ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            age = 7;
        }
        
        var student = new Student
        {
            Id = Guid.NewGuid(),
            FullName = fullName ?? "Noma'lum",
            Grade = grade,
            Age = age
        };
        
        return student;
    }
    
    // 7. Nom bo'yicha studentlarni qidirish (pagination bilan)
    public List<Student> GetStudentsByName(string name, int pageNumber, int pageSize)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Ism bo'sh bo'lishi mumkin emas");
        }
        
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize < 1) pageSize = 10;
        
        var allStudents = _studentRepository.GetAllStudents();
        
        var filteredStudents = allStudents
            .Where(s => s.FullName.Contains(name, StringComparison.OrdinalIgnoreCase))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        return filteredStudents;
    }
    
    // 8. Student ma'lumotlarini ekranga chiqarish
    public void PrintStudentInfo(Student student)
    {
        if (student == null)
        {
            Console.WriteLine("Student ma'lumotlari topilmadi");
            return;
        }
        
        Console.WriteLine("═══════════════════════════════════");
        Console.WriteLine($"🆔 ID:        {student.Id}");
        Console.WriteLine($"👤 Ism:       {student.FullName}");
        Console.WriteLine($"📚 Sinf:      {student.Grade}-sinf");
        Console.WriteLine($"🎂 Yoshi:     {student.Age}");
        Console.WriteLine("═══════════════════════════════════");
    }
    
    // 9. Studentlar sonini sinf bo'yicha chiqarish
    public void GetStudentCountByClass()
    {
        var allStudents = _studentRepository.GetAllStudents();
        
        var studentsByGrade = allStudents
            .GroupBy(s => s.Grade)
            .OrderBy(g => g.Key)
            .ToList();
        
        Console.WriteLine("\n=== Sinf bo'yicha o'quvchilar soni ===");
        
        if (studentsByGrade.Count == 0)
        {
            Console.WriteLine("Hech qanday student topilmadi");
            return;
        }
        
        foreach (var group in studentsByGrade)
        {
            Console.WriteLine($"{group.Key}-sinf: {group.Count()} ta o'quvchi");
        }
        
        Console.WriteLine($"\nJami studentlar: {allStudents.Count} ta");
    }
}