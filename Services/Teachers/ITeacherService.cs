using System;
using System.Collections.Generic;
using Models.Teachers;

namespace TeacherServiceApp.Services.Teachers
{
    public interface ITeacherService
    {
        // CRUD
        void CreateTeacher(Teacher teacher);
        List<Teacher> GetAllTeachers();
        Teacher GetTeacherById(Guid teacherId);
        void UpdateTeacher(Teacher teacher);
        void DeleteTeacherById(Guid teacherId);

        // User Input
        Teacher GetTeachersFromUser();

        // Print
        void TeacherPrintInfo(Teacher teacher);
    }
}