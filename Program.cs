using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Models.Students;
using Models.Teachers;
using Services.Students;
using Services.Teachers;


// StudentService studentService = new StudentService();
// TeacherService teacherService = new TeacherService();

// string userChoice = string.Empty;

// do
// {
//     Console.WriteLine("\nSchool Management System ga xush kelibsiz! \n\t1. Student \n\t2. Teacher");
//     Console.Write("Tanlang: ");

//     string userInput = Console.ReadLine();

//     switch (userInput)
//     {
//         case "1":
//             {
//                 Console.WriteLine("\nStudent bo'limi \n\t1. CREATE (Qo'shish) \n\t2. READ (Ko'rish)  \n\t3. UPDATE (Yangilash)  \n\t4. DELETE (O'chirish) ");
//                 Console.Write("Tanlang: ");

//                 string choiceFunction = Console.ReadLine();

//                 switch (choiceFunction.ToLower())
//                 {
//                     case "1":
//                         Student newStudent = studentService.GetStudentFormUser();
//                         if (newStudent != null)
//                         {
//                             studentService.CreateStudent(newStudent);
//                         }
//                         break;

//                     case "2":
//                         List<Student> allStudents = studentService.GetAllStudents();
//                         if (allStudents.Count == 0)
//                         {
//                             Console.WriteLine("📭 No students found!");
//                         }
//                         else
//                         {
//                             foreach (var student in allStudents)
//                             {
//                                 if (student != null)
//                                 {
//                                     studentService.PrintStudentInfo(student);
//                                 }
//                             }
//                             Console.WriteLine($"\n📌 Total: {allStudents.Count} students");
//                         }
//                         break;

//                     case "3":
//                         Console.Write("Enter Student ID to update: ");
//                         if (Guid.TryParse(Console.ReadLine(), out Guid updateId))
//                         {
//                             Student exStudent = studentService.GetStudentById(updateId);
//                             if (exStudent != null)
//                             {
//                                 Console.WriteLine("Enter new information:");
//                                 Student updatedStudent = studentService.GetStudentFormUser();
//                                 if (updatedStudent != null)
//                                 {
//                                     updatedStudent.ID = updateId;
//                                     studentService.UpdateStudent(updatedStudent);
//                                 }
//                             }
//                             else
//                             {
//                                 Console.WriteLine("Student not found!");
//                             }
//                         }
//                         else
//                         {
//                             Console.WriteLine("Invalid GUID format!");
//                         }
//                         break;

//                     case "4":
//                         Console.Write("Enter Student ID to delete: ");
//                         if (Guid.TryParse(Console.ReadLine(), out Guid deleteId))
//                         {
//                             studentService.DeleteStudentById(deleteId);
//                         }
//                         else
//                         {
//                             Console.WriteLine("Invalid GUID format!");
//                         }
//                         break;
//                     case "5":
//                         {
//                             studentService.GetStudentCountByClass();
//                             break;
//                         }


//                     default:
//                         Console.WriteLine(" Bunday amal mavjud emas!");
//                         break;
//                 }
//             }
//             break;

//         case "2":
//             {
//                 Console.WriteLine("\nTeacher bo'limi \n\t1. CREATE (Qo'shish) \n\t2. READ (Ko'rish)  \n\t3. UPDATE (Yangilash) \n\t4. DELETE (O'chirish)");
//                 Console.Write("Tanlang: ");

//                 string choiceFunction = Console.ReadLine();

//                 switch (choiceFunction.ToLower())
//                 {
//                     case "1":
//                         Teacher newTeacher = teacherService.GetTeachersFromUser();
//                         if (newTeacher != null)
//                         {
//                             teacherService.CreateTeacher(newTeacher);
//                         }
//                         break;

//                     case "2":
//                         Teacher[] allTeachers = teacherService.GetAllTeachers();
//                         foreach (var teacher in allTeachers)
//                         {
//                             if (teacher != null)
//                             {
//                                 teacherService.TeacherPrintInfo(teacher);
//                             }
//                         }
//                         break;

//                     case "3":
//                         Console.Write("Enter Teacher ID to update: ");
//                         if (Guid.TryParse(Console.ReadLine(), out Guid updateTeacherId))
//                         {
//                             Teacher exTeacher = teacherService.GetTeacherById(updateTeacherId);
//                             if (exTeacher != null)
//                             {
//                                 Console.WriteLine("Enter new information:");
//                                 Teacher updatedTeacher = teacherService.GetTeachersFromUser();
//                                 if (updatedTeacher != null)
//                                 {
//                                     updatedTeacher.Id = updateTeacherId;
//                                     teacherService.UpdateTeacher(updatedTeacher);
//                                 }
//                             }
//                             else
//                             {
//                                 Console.WriteLine("Teacher not found!");
//                             }
//                         }
//                         else
//                         {
//                             Console.WriteLine("Invalid GUID format!");
//                         }
//                         break;

//                     case "4":
//                         Console.Write("Enter Teacher ID to delete: ");
//                         if (Guid.TryParse(Console.ReadLine(), out Guid deleteTeacherId))
//                         {
//                             teacherService.DeleteTeacherById(deleteTeacherId);
//                         }
//                         else
//                         {
//                             Console.WriteLine("Invalid GUID format!");
//                         }
//                         break;

//                     default:
//                         Console.WriteLine("Bunday amal mavjud emas!");
//                         break;
//                 }
//             }
//             break;

//         default:
//             Console.WriteLine("Bunday amal mavjud emas!");
//             break;
//     }
//     Console.Write("\nDasturni davom ettirishni xohlaysizmi? (ha/yoq): ");
//     userChoice = Console.ReadLine();

// } while (userChoice.ToLower() == "ha");

// var pair = new Pair<int, string> (1, "Nodir");

// var collection = new List<Pair<int, string>>();
// collection.Add(pair);
// collection.Add(new Pair<int, string> (2 , "Akobir davlatov"));

// collection.ForEach(pair => pair.Display());

// var studentPair = new Pair<string, Student>("A", new Student());

// // StringBox strBox = new StringBox();
// // strBox.Value = "Test";

// // IntBox intBox = new IntBox();
// // {
// //     Value = 10;
// // };

// var stringBox = new Box<string>("ABCD");
// var intBox = new Box<int>(123);

string comName  = "Apple";
comName.Print();



public class Pair<TKey, TValue>
{
    public TKey Key {get;set;}
    public TValue Value {get; set;} 

    public Pair(TKey key, TValue value)
    {
        this.Key = key;
        this.Value = value;  
    }

    public void Display()
    {
        Console.WriteLine($" Key : {this.Key} Value: {this.Value}");
    }
}

public class StringBox
{
    public string Value {get; set;}
}

public class IntBox
{
    public int Value {get; set;}
}

public class Box<T>
{
    public T Value {get; set;}

    public Box(T value)
    {
        this.Value = value;
    }
}

public static class PrintExtension
{
    public static void Print<T>(this T value)
    {
        Console.WriteLine(value);
    }
}


