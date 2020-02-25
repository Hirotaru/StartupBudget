using System;
using System.Collections.Generic;

namespace StartupBudget.Abstractions
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Save();
    }
}
