using System;
using System.Collections.Generic;
using Models.Teachers;

namespace TeacherService.Repositories;

public interface ITeacherRepository
{
    Teacher CreateTeacher(Teacher teacher);
    List<Teacher> GetAllTeachers();
    Teacher GetTeacherById(Guid teacherId);
    Teacher UpdateTeacher(Teacher teacher);
    Teacher DeleteTeacher(Teacher teacher);
}