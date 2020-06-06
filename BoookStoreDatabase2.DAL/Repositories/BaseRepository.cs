using AutoMapper;
using BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Interfaces;
using BoookStoreDatabase2.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoookStoreDatabase2.DAL.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        protected StoreContext _dbContext;
        protected IMapper _mapper;
        public BaseRepository(StoreContext context, IMapper mapper = null)
        {
            this._dbContext = context;
            _mapper = mapper;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }
    }
}