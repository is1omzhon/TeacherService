using System;
using System.Collections.Generic;
using Models.Students;

namespace TeacherService.Repositories;

public interface IStudentRepository
{
    Student CreateStudent(Student student);
    List<Student> GetAllStudents();
    Student GetStudentById(Guid studentId);
    Student UpdateStudent(Student student);
    Student DeleteStudent(Student student);
}