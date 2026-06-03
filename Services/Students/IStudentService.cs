using System;
using System.Collections.Generic;
using Models.Students;

namespace Services.Students;

public interface IStudentService
{
    void InsertStudent(Student student);
    Student GetStudentFormUser();
    void CreateStudent(Student student);
    List<Student> GetAllStudents();
    void PrintStudentInfo(Student student);
    Student GetStudentById(Guid studentId);
    void UpdateStudent (Student student); 
    void DeleteStudentById(Guid studentId);
    }
