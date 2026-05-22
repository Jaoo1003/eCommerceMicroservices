using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.Entities.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest request)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(request.Email, request.Password);
            if (user == null)
            {
                return null;
            }

            return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = Guid.NewGuid().ToString() };
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest request)
        {
            ApplicationUser newUser = _mapper.Map<ApplicationUser>(request);

            ApplicationUser? registeredUser = await _userRepository.AddUser(newUser);
            
            if(registeredUser == null) return null;

            return _mapper.Map<AuthenticationResponse>(registeredUser);
        }
    }
}
