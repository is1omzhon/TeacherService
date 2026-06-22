using System;
using System.Collections.Generic;
using System.Linq;
using Models.Teachers;

namespace TeacherService.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository() : base("teachers.json") { }

        protected override Guid GetEntityId(Teacher entity) => entity.Id;

        public List<Teacher> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return GetAll();

            return _items.Values
                .Where(t => t.FirstName.Contains(searchTerm) ||
                           t.LastName.Contains(searchTerm) ||
                           t.Subject.Contains(searchTerm))
                .ToList();
        }

        public List<Teacher> GetBySubject(string subject)
        {
            return _items.Values.Where(t => t.Subject == subject).ToList();
        }

        public List<Teacher> GetTopTeachers(int count)
        {
            return _items.Values.OrderByDescending(t => t.Salary).Take(count).ToList();
        }
    }
}

