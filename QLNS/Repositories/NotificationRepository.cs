using Microsoft.EntityFrameworkCore;
using QLNS.Data;
using QLNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Repositories
{
    public class NotificationRepository:GenericRepository<Notifications>
    {
        private readonly DBContext _contex;
        private readonly DbSet<Notifications> _table;

        public NotificationRepository(DBContext context) : base(context)
        {
            _contex = context;
            _table = context.Set<Notifications>();
        }
    }
}
