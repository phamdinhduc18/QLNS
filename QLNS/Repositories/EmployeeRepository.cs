using Microsoft.EntityFrameworkCore;
using QLNS.Data;
using QLNS.Helpers;
using QLNS.Helpers.Models;
using QLNS.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Repositories
{
    public class EmployeeRepository : GenericRepository<Employees>
    {
        private readonly DBContext _context;
        private readonly DbSet<Employees> _table;

        public EmployeeRepository(DBContext context) : base(context)
        {
            _context = context;
            _table = context.Set<Employees>();
        }

        public Employees CheckLogin(UserLoginDTO userLogin, out string messsage)
        {
            var user = _table.Where(x => x.Email.Equals(userLogin.Email)).Include(x=>x.Role).FirstOrDefault();
            if (user == null)
            {
                messsage = "wrong email";
                return null;
            }
            if (!Hash.Validate(userLogin.Password, user.PasswordSalt, user.PasswordHash))
            {
                messsage = "wrong password";
                return null;
            }
            messsage = "success";
            return user;
        }

        public async Task AddRefreshTokenAsync(RefreshToken refreshToken, Employees user)
        {
            user.RefreshToken.Add(refreshToken);
            _context.Update(user);
            await SaveAsync();
        }

        public async Task<Employees> GetUserByToken(string token)
        {
            var user = await _table.Include("RefreshToken").SingleOrDefaultAsync(u => u.RefreshToken.Any(t => t.Token == token));
            if (user == null) return null;
            return user;
        }

        internal async Task<bool> RevokeToken(string token)
        {
            var user = await GetUserByToken(token);
            
            if(user==null) return false;
            
            var refreshToken = user.RefreshToken.First(t => t.Token == token);
            
            refreshToken.Revoked = DateTime.UtcNow;
            _context.Update(user);
            _context.SaveChanges();

            return true;
        }

        internal async void UpdateRefreshTokenOfUser(string oldRefreshToken, RefreshToken newRefreshToken, Employees user)
        {
            var refreshToken = user.RefreshToken.Single(x => x.Token == oldRefreshToken);

            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.ReplacedByToken = newRefreshToken.Token;

            user.RefreshToken.Add(newRefreshToken);
            await UpdateAsync(user.EmployeeId, user);
        }

    }
}