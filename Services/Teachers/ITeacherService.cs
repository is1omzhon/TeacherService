using System;
using Models.Teachers;

namespace Services.Teachers;

public interface ITeacherService
{
    Teacher GetTeachersFromUser();
    void CreateTeacher(Teacher teacher);
    Teacher [] GetAllTeachers();
    void TeacherPrintInfo(Teacher teacher);

    // GET
    Teacher GetTeacherById(Guid teacherId);
   
   // UPDATE 
    void UpdateTeacher (Teacher student);

    // DELETE 
    void DeleteTeacherById(Guid teacherId);

}