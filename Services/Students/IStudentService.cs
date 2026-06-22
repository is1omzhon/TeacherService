using System;
using System.Collections.Generic;
using Models.Students;

namespace TeacherServiceApp.Services.Students
{
    public interface IStudentService
    {
        // CRUD
        void CreateStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudentById(Guid studentId);
        void UpdateStudent(Student student);
        void DeleteStudentById(Guid studentId);

        // User Input
        Student GetStudentFormUser();

        List<Student> GetStudentsByName(string name, int pageNumber, int pageSize);

        void PrintStudentInfo(Student student);
        void GetStudentCountByClass();

        // Statistics
        double GetAverageGPA();
        int GetTotalCount();
    }
}