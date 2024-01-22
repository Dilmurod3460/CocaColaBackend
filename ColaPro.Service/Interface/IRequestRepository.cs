using ColaPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaPro.Service.Interface
{
    public interface IRequestRepository
    {
        ValueTask CreateAsync(Request request);
       ValueTask  DeleteAsync(int number);
        ValueTask<IEnumerable<Request>> GetAllAsync();
    }
}
