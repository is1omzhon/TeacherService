using System;
using System.Collections.Generic;
using System.Linq;

namespace TeacherService.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected List<T> _dbSet;
    
    public GenericRepository()
    {
        _dbSet = new List<T>();
    }
    
    public virtual T Create(T entity)
    {
        _dbSet.Add(entity);
        return entity;
    }
    
    public virtual List<T> GetAll()
    {
        return _dbSet.ToList();
    }
    
    public virtual T GetById(Guid id)
    {
        var property = typeof(T).GetProperty("Id");
        if (property != null)
        {
            return _dbSet.FirstOrDefault(x => (Guid)property.GetValue(x)! == id)!;
        }
        return null!;
    }
    
    public virtual T Update(T entity)
    {
        var idProperty = typeof(T).GetProperty("Id");
        if (idProperty != null)
        {
            var id = (Guid)idProperty.GetValue(entity)!;
            var existing = GetById(id);
            if (existing != null)
            {
                _dbSet.Remove(existing);
                _dbSet.Add(entity);
            }
        }
        return entity;
    }
    
    public virtual T Delete(T entity)
    {
        _dbSet.Remove(entity);
        return entity;
    }
}