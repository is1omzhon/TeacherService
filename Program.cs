using System;
using System.Collections.Generic;
using System.Linq;
using Models.Students; 
using Models.Teachers;
using TeacherService.Repositories;                  
using TeacherServiceApp.Services.Students;
using TeacherServiceApp.Services.Teachers;
using TeacherService.Exceptions;

using TeacherServiceApp.Services.Teachers;

// ========== DEPENDENCY INJECTION ==========
StudentRepository _studentRepo = new StudentRepository();
TeacherRepository _teacherRepo = new TeacherRepository();

StudentService _studentService = new StudentService(_studentRepo);
TeacherService _teacherService = new TeacherService(_teacherRepo);

while (true)
{
    Console.Clear();
    Console.WriteLine("🏫 SCHOOL MANAGEMENT SYSTEM");
    Console.WriteLine("═══════════════════════════════════");
    Console.WriteLine("1. Student");
    Console.WriteLine("2. Teacher");
    Console.WriteLine("3. Generics Demo");
    Console.WriteLine("4. Exit");
    Console.Write("\n👉 Tanlang: ");

    switch (Console.ReadLine())
    {
        case "1": StudentMenu(); break;
        case "2": TeacherMenu(); break;
        case "3": GenericsDemo(); break;
        case "4": return;
        default: ShowError("Noto'g'ri tanlov!"); break;
    }
}

// ============================================================
// ========== STUDENT MENU ==========
// ============================================================
void StudentMenu()
{
    Console.Clear();
    Console.WriteLine("📚 STUDENT MANAGEMENT");
    Console.WriteLine("═══════════════════════════════════");
    Console.WriteLine("1. CREATE");
    Console.WriteLine("2. READ");
    Console.WriteLine("3. UPDATE");
    Console.WriteLine("4. DELETE");
    Console.WriteLine("5. COUNT BY CLASS");
    Console.WriteLine("6. BACK");
    Console.Write("\n👉 Tanlang: ");

    switch (Console.ReadLine())
    {
        case "1": CreateStudent(); break;
        case "2": ReadStudents(); break;
        case "3": UpdateStudent(); break;
        case "4": DeleteStudent(); break;
        case "5": GetStudentCountByClass(); break;
        case "6": return;
        default: ShowError("Noto'g'ri tanlov!"); break;
    }
}

// ========== STUDENT CREATE ==========
void CreateStudent()
{
    try
    {
        var student = _studentService.GetStudentFormUser();
        _studentService.CreateStudent(student);
        Console.WriteLine("✅ Student created successfully!");
    }
    catch (ValidationException ex)
    {
        ShowError($"Validation Error: {ex.Message}");
    }
    catch (Exception ex)
    {
        ShowError($"Unexpected Error: {ex.Message}");
    }
    Wait();
}

// ========== STUDENT READ ==========
void ReadStudents()
{
    try
    {
        var students = _studentService.GetAllStudents();
        if (!students.Any())
        {
            Console.WriteLine("📭 No students found!");
            Wait();
            return;
        }

        students.ForEach(_studentService.PrintStudentInfo);
        Console.WriteLine($"\n📌 Total: {students.Count} students");
    }
    catch (Exception ex)
    {
        ShowError($"Error: {ex.Message}");
    }
    Wait();
}

// ========== STUDENT UPDATE ==========
void UpdateStudent()
{
    try
    {
        Console.Write("Enter Student ID: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            ShowError("Invalid GUID format!");
            return;
        }

        var existing = _studentService.GetStudentById(id);
        Console.WriteLine($"Current: {existing.FullName}");

        Console.WriteLine("Enter new information:");
        var updated = _studentService.GetStudentFormUser();
        updated.ID = id;
        _studentService.UpdateStudent(updated);
        Console.WriteLine("✅ Student updated successfully!");
    }
    catch (ValidationException ex)
    {
        ShowError($"Validation Error: {ex.Message}");
    }
    catch (NotFoundException ex)
    {
        ShowError($"Not Found: {ex.Message}");
    }
    catch (Exception ex)
    {
        ShowError($"Unexpected Error: {ex.Message}");
    }
    Wait();
}

// ========== STUDENT DELETE ==========
void DeleteStudent()
{
    try
    {
        Console.Write("Enter Student ID: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            ShowError("Invalid GUID format!");
            return;
        }

        _studentService.DeleteStudentById(id);
        Console.WriteLine("✅ Student deleted successfully!");
    }
    catch (NotFoundException ex)
    {
        ShowError($"Not Found: {ex.Message}");
    }
    catch (Exception ex)
    {
        ShowError($"Error: {ex.Message}");
    }
    Wait();
}

// ========== STUDENT COUNT BY CLASS ==========
void GetStudentCountByClass()
{
    try
    {
        _studentService.GetStudentCountByClass();
    }
    catch (NotFoundException ex)
    {
        ShowError($"Not Found: {ex.Message}");
    }
    catch (Exception ex)
    {
        ShowError($"Error: {ex.Message}");
    }
    Wait();
}

// ============================================================
// ========== TEACHER MENU ==========
// ============================================================
void TeacherMenu()
{
    Console.Clear();
    Console.WriteLine("👨‍🏫 TEACHER MANAGEMENT");
    Console.WriteLine("═══════════════════════════════════");
    Console.WriteLine("1. CREATE");
    Console.WriteLine("2. READ");
    Console.WriteLine("3. UPDATE");
    Console.WriteLine("4. DELETE");
    Console.WriteLine("5. BACK");
    Console.Write("\n👉 Tanlang: ");

    switch (Console.ReadLine())
    {
        case "1": CreateTeacher(); break;
        case "2": ReadTeachers(); break;
        case "3": UpdateTeacher(); break;
        case "4": DeleteTeacher(); break;
        case "5": return;
        default: ShowError("Noto'g'ri tanlov!"); break;
    }
}

// ========== TEACHER CREATE ==========
void CreateTeacher()
{
    try
    {
        var teacher = _teacherService.GetTeachersFromUser();
        _teacherService.CreateTeacher(teacher);
        Console.WriteLine("✅ Teacher created successfully!");
    }
    catch (ValidationException ex)
    {
        ShowError($"Validation Error: {ex.Message}");
    }
    catch (Exception ex)
    {
        ShowError($"Unexpected Error: {ex.Message}");
    }
    Wait();
}

// ========== TEACHER READ ==========
void ReadTeachers()
{
    try
    {
        var teachers = _teacherService.GetAllTeachers().Where(t => t != null).ToList();
        if (!teachers.Any())
        {
            Console.WriteLine("📭 No teachers found!");
            Wait();
            return;
        }

        teachers.ForEach(_teacherService.TeacherPrintInfo);
        Console.WriteLine($"\n📌 Total: {teachers.Count} teachers");
    }
    catch (Exception ex)
    {
        ShowError($"Error: {ex.Message}");
    }
    Wait();
}

// ========== TEACHER UPDATE ==========
void UpdateTeacher()
{
    try
    {
        Console.Write("Enter Teacher ID: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            ShowError("Invalid GUID format!");
            return;
        }

        var existing = _teacherService.GetTeacherById(id);
        Console.WriteLine($"Current: {existing.FullName}");

        Console.WriteLine("Enter new information:");
        var updated = _teacherService.GetTeachersFromUser();
        updated.Id = id;
        _teacherService.UpdateTeacher(updated);
        Console.WriteLine("✅ Teacher updated successfully!");
    }
    catch (ValidationException ex)
    {
        ShowError($"Validation Error: {ex.Message}");
    }
    catch (NotFoundException ex)
    {
        ShowError($"Not Found: {ex.Message}");
    }
    catch (Exception ex)
    {
        ShowError($"Unexpected Error: {ex.Message}");
    }
    Wait();
}

// ========== TEACHER DELETE ==========
void DeleteTeacher()
{
    try
    {
        Console.Write("Enter Teacher ID: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            ShowError("Invalid GUID format!");
            return;
        }

        _teacherService.DeleteTeacherById(id);
        Console.WriteLine("✅ Teacher deleted successfully!");
    }
    catch (NotFoundException ex)
    {
        ShowError($"Not Found: {ex.Message}");
    }
    catch (Exception ex)
    {
        ShowError($"Error: {ex.Message}");
    }
    Wait();
}

// ============================================================
// ========== GENERICS DEMO ==========
// ============================================================
void GenericsDemo()
{
    try
    {
        Console.Clear();
        Console.WriteLine("📦 GENERICS DEMO");
        Console.WriteLine("═══════════════════════════════════\n");

        var pair = new Pair<int, string>(1, "Nodir");
        var collection = new List<Pair<int, string>>
        {
            pair,
            new Pair<int, string>(2, "Akobir Davlatov")
        };
        collection.ForEach(p => p.Display());

        var studentPair = new Pair<string, Student>("A", new Student());
        Console.WriteLine($"\nStudent Pair: {studentPair.Key} -> {studentPair.Value?.FirstName ?? "null"}");

        var stringBox = new Box<string>("ABCD");
        var intBox = new Box<int>(123);
        Console.WriteLine($"String Box: {stringBox.Value}");
        Console.WriteLine($"Int Box: {intBox.Value}");

        string comName = "Apple";
        comName.Print();

        Console.WriteLine("\n✅ Generics demo completed!");
    }
    catch (Exception ex)
    {
        ShowError($"Error in Generics Demo: {ex.Message}");
    }
    Wait();
}

// ============================================================
// ========== HELPERS ==========
// ============================================================

// ❌ Xatolikni qizil rangda chiqarish
void ShowError(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\n❌ {message}");
    Console.ResetColor();
}

// ⏳ Foydalanuvchi tugma bosguncha kutish
void Wait()
{
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}

// ============================================================
// ========== GENERICS CLASSES ==========
// ============================================================

public class Pair<TKey, TValue>
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }

    public Pair(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }

    public void Display()
    {
        Console.WriteLine($"Key: {Key}, Value: {Value}");
    }
}

public class Box<T>
{
    public T Value { get; set; }

    public Box(T value)
    {
        Value = value;
    }
}

public static class PrintExtension
{
    public static void Print<T>(this T value)
    {
        Console.WriteLine(value);
    }
}