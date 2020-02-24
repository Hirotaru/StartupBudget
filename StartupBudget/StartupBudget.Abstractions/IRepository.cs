using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupBudget.Abstractions
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T GetById(int? id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Save();
    }
}
