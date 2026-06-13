using System;
using System.Collections.Generic;
using Models.Teachers;

namespace TeacherService.Repositories;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{
    public Teacher CreateTeacher(Teacher teacher)
    {
        return Create(teacher);
    }
    
    public List<Teacher> GetAllTeachers()
    {
        return GetAll();
    }
    
    public Teacher GetTeacherById(Guid teacherId)
    {
        return GetById(teacherId);
    }
    
    public Teacher UpdateTeacher(Teacher teacher)
    {
        return Update(teacher);
    }
    
    public Teacher DeleteTeacher(Teacher teacher)
    {
        return Delete(teacher);
    }
}

