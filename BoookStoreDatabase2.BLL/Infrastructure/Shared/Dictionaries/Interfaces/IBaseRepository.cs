using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Interfaces
{
    public interface IBaseRepository
    {
        Task<bool> SaveChangesAsync();
    }
}
