using AutoMapper;
using BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Interfaces;
using BoookStoreDatabase2.BLL.Models.DTO;
using BoookStoreDatabase2.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BoookStoreDatabase2.DAL.Repositories
{
    public class ApplicationUsersRepository : BaseRepository, IApplicationUsersRepository
    {
        public ApplicationUsersRepository(StoreContext storesDbContext, IMapper mapper = null) : base(storesDbContext, mapper)
        {
        }

        public async Task<List<ApplicationUsersDTO>> GetAll()
        {
            var result = await _dbContext.Users?.Select(x => new ApplicationUsersDTO
            {
                FirstName = x.Customer != null ? x.Customer.FirstName : x.Employee.FirstName,
                LastName = x.Customer != null ? x.Customer.LastName : x.Employee.LastName,
                UserType = x.Customer != null ? "Customer" : "Administrator",
                UserName = x.UserName,
                Email = x.Email
            })?.ToListAsync();
            return result;
        }
    }
}
