using System;
using System.Collections.Generic;
using Models.Students;

namespace Services.Students;



public interface IStudentService
{
  
    void CreateStudent(Student student);
    List<Student> GetAllStudents();
    Student GetStudentById(Guid studentId);
    void UpdateStudent(Student student);
    void DeleteStudentById(Guid studentId);
    
    Student GetStudentFormUser();
    List<Student> GetStudentsByName(string name, int pageNumber, int pageSize);
 
    void PrintStudentInfo(Student student);
    
    void GetStudentCountByClass();
}