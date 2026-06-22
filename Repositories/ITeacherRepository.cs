using System.Collections.Generic;
using Models.Teachers;

namespace TeacherService.Repositories
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        List<Teacher> Search(string searchTerm);
        List<Teacher> GetBySubject(string subject);
        List<Teacher> GetTopTeachers(int count);
    }
}