using Microsoft.EntityFrameworkCore;
using QLNS.Data;
using QLNS.Enums;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DBContext _context;
        private readonly DbSet<T> _table;
        public GenericRepository(DBContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public virtual T Create(T data)
        {
            _table.Add(data);
            _context.SaveChanges();
            return data;
        }

        public virtual async Task<T> CreateAsync(T data)
        {
            await _table.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public virtual T Delete(object Id)
        {
            T t = _table.Find(Id);
            _table.Remove(t);
            _context.SaveChanges();
            return t;
        }

        public virtual async Task<T> DeleteAsync(object Id)
        {
            T t = await _table.FindAsync(Id);
            _table.Remove(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public IEnumerable<T> Find(Func<T, bool> condition) => _table.Where(condition);

        public T FindOne(Func<T, bool> condition) => _table.Where(condition).FirstOrDefault();

        public virtual T Get(object Id) => _table.Find(Id);

        public virtual async Task<T> GetAsync(object Id) => await _table.FindAsync(Id);

        public virtual IEnumerable<T> Gets() => _table.ToList();

        public virtual async Task<IEnumerable<T>> GetsAsync() => await _table.ToListAsync();

        public virtual void Save() => _context.SaveChanges();

        public virtual async Task SaveAsync() => await _context.SaveChangesAsync();

        public virtual T Update(object Id, T data)
        {
            var entity = _table.Find(Id);
            if (entity == null) return default;
            _context.Entry(entity).CurrentValues.SetValues(data);
            _context.SaveChanges();
            return data;
        }

        public virtual async Task<T> UpdateAsync(object Id, T data)
        {
            var entity = _table.Find(Id);
            if (entity == null) return default;
            _context.Entry(entity).CurrentValues.SetValues(data);
            await _context.SaveChangesAsync();
            return data;
        }


        public Employees GetEmployeeSuperior(int currentEmployeeId)
        {
            var currentEmployee = _context.Employees.Include(x => x.Role).FirstOrDefault(x => x.EmployeeId == currentEmployeeId);
            if (currentEmployee.Role.RoleName == RoleName.Staff.ToString() || currentEmployee.Role.RoleName == RoleName.Leader.ToString())
            {
                return _context.Employees.FirstOrDefault(x => x.Status == true);
            }
            //typeof trả về kiểu của  lớp RoleName
            //var e = (RoleName)Enum.Parse(typeof(RoleName), currentEmployee.Role.RoleName);
            //var index = Array.IndexOf(Enum.GetValues(e.GetType()), e) - 1;
            //var roleSupervisorName = (Enum.GetValues(e.GetType())).GetValue(index >= 0 ? index : 0);
            return _context.Employees.FirstOrDefault(x => x.Status == true );
        }
    }
}
