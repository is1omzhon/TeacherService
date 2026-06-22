using System;
using System.Collections.Generic;
using System.Linq;
using TeacherService.Utils;

namespace TeacherService.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected Dictionary<Guid, T> _items;
        protected readonly FileStorage _storage;
        protected readonly string _fileName;

        protected GenericRepository(string fileName)
        {
            _fileName = fileName;
            _storage = new FileStorage(_fileName);
            _items = _storage.Load<Dictionary<Guid, T>>() ?? new Dictionary<Guid, T>();
        }

        public virtual T GetById(Guid id)
        {
            return _items.TryGetValue(id, out var item) ? item : null;
        }

        public virtual List<T> GetAll()
        {
            return _items.Values.ToList();
        }

        public virtual void Add(T entity)
        {
            var id = GetEntityId(entity);
            if (_items.ContainsKey(id))
            {
                Console.WriteLine($"❌ Entity with this ID already exists!");
                return;
            }

            _items.Add(id, entity);
            SaveChanges();
            Console.WriteLine($"✅ Entity added successfully!");
        }

        public virtual void Update(T entity)
        {
            var id = GetEntityId(entity);
            if (!_items.ContainsKey(id))
            {
                Console.WriteLine($"❌ Entity not found!");
                return;
            }

            _items[id] = entity;
            SaveChanges();
            Console.WriteLine($"✅ Entity updated successfully!");
        }

        public virtual void Delete(Guid id)
        {
            if (_items.Remove(id))
            {
                SaveChanges();
                Console.WriteLine($"✅ Entity deleted successfully!");
            }
            else
            {
                Console.WriteLine($"❌ Entity not found!");
            }
        }

        public virtual int Count => _items.Count;

        public void SaveChanges()
        {
            _storage.Save(_items);
        }

        protected abstract Guid GetEntityId(T entity);
    }
}