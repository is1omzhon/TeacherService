using System;
using System.Collections.Generic;

namespace TeacherService.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(Guid id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
        int Count { get; }
        void SaveChanges();
    }
}