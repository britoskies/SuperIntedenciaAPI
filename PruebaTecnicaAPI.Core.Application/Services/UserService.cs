using AutoMapper;
using PruebaTecnicaAPI.Core.Application.Dtos.Account;
using PruebaTecnicaAPI.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI.Core.Application.Services
{
    public class UserService: IUserService
    {

        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public UserService(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginDto dto)
        {
            AuthenticationRequest request = _mapper.Map<AuthenticationRequest>(dto);
            AuthenticationResponse response = await _accountService.AuthenticationAsync(request);
            return response;
        }

        public async Task SignOutAsync()
        {
            await _accountService.SignOutAsync();
        }
    }
}
