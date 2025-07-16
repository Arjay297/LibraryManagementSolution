using LibraryManagement.API.Data.Models;
using LibraryManagement.API.Dtos.Response;
using LibraryManagement.API.Repositories;

namespace LibraryManagement.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly IMemberRepository _memberRepository;

        public AuthenticationService(
            IUserRepository userRepository,
            IPasswordService passwordService,
            ITokenService tokenService,
            IMemberRepository memberRepository)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _memberRepository = memberRepository;
        }

        public async Task<AuthenticationResponse> Login(string email, string password)
        {
            User? existingUser = await _userRepository.GetByEmailAsync(email);
            if (existingUser is null)
            {
                return new AuthenticationResponse
                {
                    IsSuccess = false,
                    Message = "Invalid email or password"
                };
            }
            bool isValid = _passwordService.ValidatePassword(email, password, existingUser.PasswordHash);
            if (!isValid)
            {
                return new AuthenticationResponse
                {
                    IsSuccess = false,
                    Message = "Invalid email or password"
                };
            }
                
            return new AuthenticationResponse
            {
                IsSuccess = true,
                Message = "Login Successfull",
                AccessToken = _tokenService.GenerateToken(existingUser)
            };


        }

        public async Task<AuthenticationResponse> RegisterAsync(string name, string email, string password)
        {
            //Check if user already exists
            User? existingUser = await _userRepository.GetByEmailAsync(email);
            if(existingUser is not null)
            {
                return new AuthenticationResponse
                {
                    IsSuccess = false,
                    Message = "User already exists with this email."
                };
            }
            //Create Password Hash
            string passwordHash = _passwordService.HashPassword(email, password);

            //Add to Database
            User user = User.Create(name, email, passwordHash);
            await _userRepository.AddAsync(user);
            Member member = new Member
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
            await _memberRepository.AddAsync(member);

            await _userRepository.SaveChangeAsync();
            //Token Generation
            string accessToken = _tokenService.GenerateToken(user);

            //Wrap to Authentication response success, access_token, "message"
            return new AuthenticationResponse
            {
                IsSuccess = true,
                Message = "User registered successfully.",
                AccessToken = accessToken
            };
        }
    }
}
