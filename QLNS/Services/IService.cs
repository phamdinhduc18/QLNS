using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.Services
{
    public interface IService<T>
    {
        public T Create(T data);
        public IEnumerable<T> Gets();
        public T Get(object Id);
        public T Update(object Id, T data);
        public T Delete(object Id);

        public Task<T> CreateAsync(T data);
        public Task<IEnumerable<T>> GetsAsync();
        public Task<T> GetAsync(object Id);
        public Task<T> UpdateAsync(object Id, T data);
        public Task<T> DeleteAsync(object Id);

        //public Task<T> UpdateStatus(object Id);

    }
}