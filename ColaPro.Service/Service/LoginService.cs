using ColaPro.DataAccess.DataContext;
using ColaPro.Domain.Entities;
using ColaPro.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaPro.Service.Service
{
    public class LoginService : ILoginRepository
    {
        private readonly ApplicationDbContext _context;

        public LoginService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async ValueTask CreateAsync(Login model)
        {
            await _context.Logins.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async ValueTask DeleteAsync(int Id)
        {
            Login login = await _context.Logins.FirstOrDefaultAsync(x => x.Id == Id);
            if (login != null)
            {
                _context.Logins.Remove(login);
                await _context.SaveChangesAsync();
            }
        }

        public async ValueTask<IEnumerable<Login>> GetAllAsync()
        {
            IEnumerable<Login> logins = await _context.Logins.ToListAsync();

            return logins;
        }
    }
}
