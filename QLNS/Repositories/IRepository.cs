using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.Repositories
{
    public interface IRepository<T>
    {
        public T Create(T data);
        public IEnumerable<T> Gets();
        public T Get(object Id);
        public T FindOne(Func<T, bool> condition);
        public IEnumerable<T> Find(Func<T, bool> condition);
        public T Update(object Id, T data);
        public T Delete(object Id);
        public void Save();
        public Task<T> CreateAsync(T data);
        public Task<IEnumerable<T>> GetsAsync();
        public Task<T> GetAsync(object Id);
        public Task<T> UpdateAsync(object Id, T data);
        public Task<T> DeleteAsync(object Id);
        public Task SaveAsync();
        public Employees GetEmployeeSuperior(int currentEmployeeId);

    }


}