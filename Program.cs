using System;
using System.Reflection.Metadata;
using Models.Students;
using Models.Teachers;
using Services.Students;
using Services.Teachers;


StudentService studentService = new StudentService();
TeacherService teacherService = new TeacherService();

string userChoice = string.Empty;

do
{
    Console.WriteLine("\nSchool Management System ga xush kelibsiz! \n\t1. Student \n\t2. Teacher");
    Console.Write("Tanlang: ");

    string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1": 
            {
                Console.WriteLine("\nStudent bo'limi \n\t1. CREATE (Qo'shish) \n\t2. READ (Ko'rish)  \n\t3. UPDATE (Yangilash)  \n\t4. DELETE (O'chirish) ");
                Console.Write("Tanlang: ");

                string choiceFunction = Console.ReadLine();

                switch (choiceFunction.ToLower())
                {
                    case "1":
                        Student newStudent = studentService.GetStudentFormUser();
                        if (newStudent != null)
                        {
                            studentService.CreateStudent(newStudent);
                        }
                        break;

                    case "2":
                        Student[] allStudents = studentService.GetAllStudents();
                        foreach (var student in allStudents)
                        {
                            if (student != null)
                            {
                                studentService.PrintStudentInfo(student);
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Enter Student ID to update: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid updateId))
                        {
                            Student exStudent = studentService.GetStudentById(updateId);
                            if (exStudent != null)
                            {
                                Console.WriteLine("Enter new information:");
                                Student updatedStudent = studentService.GetStudentFormUser();
                                if (updatedStudent != null)
                                {
                                    updatedStudent.ID = updateId;
                                    studentService.UpdateStudent(updatedStudent);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Student not found!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid GUID format!");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Student ID to delete: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid deleteId))
                        {
                            studentService.DeleteStudentById(deleteId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid GUID format!");
                        }
                        break;

                    default:
                        Console.WriteLine(" Bunday amal mavjud emas!");
                        break;
                }
            }
            break;

        case "2":  
            {
                Console.WriteLine("\nTeacher bo'limi \n\t1. CREATE (Qo'shish) \n\t2. READ (Ko'rish)  \n\t3. UPDATE (Yangilash) \n\t4. DELETE (O'chirish)");
                Console.Write("Tanlang: ");

                string choiceFunction = Console.ReadLine();

                switch (choiceFunction.ToLower())
                {
                    case "1":
                        Teacher newTeacher = teacherService.GetTeachersFromUser();
                        if (newTeacher != null)
                        {
                            teacherService.CreateTeacher(newTeacher);
                        }
                        break;

                    case "2":
                        Teacher[] allTeachers = teacherService.GetAllTeachers();
                        foreach (var teacher in allTeachers)
                        {
                            if (teacher != null)
                            {
                                teacherService.TeacherPrintInfo(teacher);
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Enter Teacher ID to update: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid updateTeacherId))
                        {
                            Teacher exTeacher = teacherService.GetTeacherById(updateTeacherId);
                            if (exTeacher != null)
                            {
                                Console.WriteLine("Enter new information:");
                                Teacher updatedTeacher = teacherService.GetTeachersFromUser();
                                if (updatedTeacher != null)
                                {
                                    updatedTeacher.Id = updateTeacherId;
                                    teacherService.UpdateTeacher(updatedTeacher);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Teacher not found!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid GUID format!");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Teacher ID to delete: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid deleteTeacherId))
                        {
                            teacherService.DeleteTeacherById(deleteTeacherId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid GUID format!");
                        }
                        break;

                    default:
                        Console.WriteLine("Bunday amal mavjud emas!");
                    break;
                }
            }
            break;

        default:
            Console.WriteLine("Bunday amal mavjud emas!");
            break;
    }
    Console.Write("\nDasturni davom ettirishni xohlaysizmi? (ha/yoq): ");
    userChoice = Console.ReadLine();

} while (userChoice.ToLower() == "ha");
