using LibraryManagement.Application.Commands;
using LibraryManagement.Application.Response;
using LibraryManagement.Application.Services;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Repositories;
using LibraryManagement.Domain.ValueObjects;

namespace LibraryManagement.Application.CommandHandler
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {

        private readonly IPasswordService _passwordService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;


        public AuthenticationCommandService(
            IPasswordService passwordService,
            ITokenService tokenService,
            IUnitOfWork unitOfWork)
        {
            _tokenService = tokenService;
            _passwordService = passwordService;
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthenticationResponse> Login(string email, string password)
        {
            User? existingUser = await _unitOfWork.Users.GetByEmailAsync(email);
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
            User? existingUser = await _unitOfWork.Users.GetByEmailAsync(email);
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
            await _unitOfWork.Users.AddAsync(user);
            Member member = new Member
            {
                Id = new MemberId(user.Id.Value),
                Name = user.Name,
                Email = user.Email
            };
            await _unitOfWork.Members.AddAsync(member);

            await _unitOfWork.SaveChangesAsync(default);
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
