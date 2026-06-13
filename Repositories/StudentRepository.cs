using System;
using System.Collections.Generic;
using System.Linq;
using Models.Students;

namespace TeacherService.Repositories;

public class StudentRepository : IStudentRepository
{
    public List<Student> students;

    public StudentRepository()
    {
        this.students = new List<Student>();
    }

    public Student CreateStudent(Student student)
    {
        this.students.Add(student);

        return student;
    }

    public Student DeleteStudent(Student student)
    {
        this.students.Remove(student);
        return student;
    }


    public List<Student> GetAllStudents()
    {
        return this.students;
    }

    public Student GetStudentById(Guid studentId)
    {
        return this.students.FirstOrDefault(s => s.ID == studentId);
    }

    public Student UpdateStudent(Student student)
    {
        throw new NotImplementedException();
    }
}
