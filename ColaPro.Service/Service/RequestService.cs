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
    public class RequestService : IRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestService(ApplicationDbContext context)
        {
            _context = context;
        }
         public async ValueTask CreateAsync(Request request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();

        }
        public async ValueTask DeleteAsync(int Id)
        {
            Request request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == Id);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }

        public async ValueTask<IEnumerable<Request>> GetAllAsync()
        {
            IEnumerable<Request> requests = await _context.Requests.ToListAsync();

            return requests;
        }

       
    }
}
