using System;
using System.Collections.Generic;
using System.Linq;
using Models.Students;

namespace TeacherService.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository() : base("students.json") { }

        protected override Guid GetEntityId(Student entity) => entity.Id;

        public List<Student> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return GetAll();

            return _items.Values
                .Where(s => s.FirstName.Contains(searchTerm) ||
                           s.LastName.Contains(searchTerm) ||
                           s.ClassRoom.Contains(searchTerm))
                .ToList();
        }

        public List<Student> GetByClass(string className)
        {
            return _items.Values.Where(s => s.ClassRoom == className).ToList();
        }

        public List<Student> GetByGPA(double minGPA)
        {
            return _items.Values.Where(s => s.GPA >= minGPA)
                           .OrderByDescending(s => s.GPA)
                           .ToList();
        }

        public Dictionary<string, int> GetStudentsCountByClass()
        {
            return _items.Values
                .GroupBy(s => s.ClassRoom)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public double AverageGPA
        {
            get
            {
                if (_items.Count == 0) return 0;
                return _items.Values.Average(s => s.GPA);
            }
        }
    }
}