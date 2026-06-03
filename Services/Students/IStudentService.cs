using System;
using Models.Students;

namespace Services.Students;

public interface IStudentService
{
    Student GetStudentFormUser();
    void CreateStudent(Student student);
    Student [] GetAllStudents();
    void PrintStudentInfo(Student student);
    Student GetStudentById(Guid studentId);
    void UpdateStudent (Student student); 
    void DeleteStudentById(Guid studentId);
    }
