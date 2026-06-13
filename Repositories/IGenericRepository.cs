using System;
using System.Collections.Generic;

namespace TeacherService.Repositories;

public interface IGenericRepository<T> where T : class
{
    T Create(T entity);
    List<T> GetAll();
    T GetById(Guid id);
    T Update(T entity);
    T Delete(T entity);
}