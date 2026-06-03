using System;
using System.Collections.Generic;
using Models.Teachers;

namespace Services.Teachers;

public interface ITeacherService
{

    void InsertTeacher(Teacher teacher);
    Teacher GetTeachersFromUser();
    void CreateTeacher(Teacher teacher);
    List<Teacher> GetAllTeachers();
    void TeacherPrintInfo(Teacher teacher);
    Teacher GetTeacherById(Guid teacherId);
    void UpdateTeacher (Teacher student);
    void DeleteTeacherById(Guid teacherId);

}