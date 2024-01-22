using ColaPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaPro.Service.Interface
{
    public interface ILoginRepository
    {
        ValueTask CreateAsync(Login login);
        ValueTask DeleteAsync(int Id);
        ValueTask<IEnumerable<Login>> GetAllAsync();
    }
}
