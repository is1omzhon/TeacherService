using System.Collections.Generic;
 using Models.Students;

namespace TeacherService.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        List<Student> Search(string searchTerm);
        List<Student> GetByClass(string className);
        List<Student> GetByGPA(double minGPA);
        Dictionary<string, int> GetStudentsCountByClass();
        double AverageGPA { get; }
    }
}