using BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Interfaces;
using BoookStoreDatabase2.BLL.Infrastructure.Shared.Responses;
using BoookStoreDatabase2.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoookStoreDatabase2.BLL.Infrastructure.Shared.Services
{
   public class ApplicationUsersService : IApplicationUsersService
    {
        private IApplicationUsersRepository _applicationUsersRepository { get; }

        public ApplicationUsersService(IApplicationUsersRepository applicationUsersRepository)
        {
            _applicationUsersRepository = applicationUsersRepository;
        }

        public async Task<Response<List<ApplicationUsersDTO>>> GetAllUsers()
        {
            try
            {
                var result = await _applicationUsersRepository.GetAll();
                return new Response<List<ApplicationUsersDTO>> { Success = true, Data = result };
            }
            catch (Exception ex)
            {
                return new Response<List<ApplicationUsersDTO>> { Success = false, Message = ex.GetBaseException().Message };
            }
        }
    }
}
