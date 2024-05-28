using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using sda_onsite_2_csharp_backend_teamwork_The_countryside_developers.src.Exceptions;

namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private IConfiguration _config;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration config)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _config = config;
        }

        public IEnumerable<UserReadDto> GetAll()
        {

            IEnumerable<UserReadDto> usersReadDto = _mapper.Map<IEnumerable<UserReadDto>>(_userRepository.GetAll());
            return usersReadDto;
        }


        public UserReadDto? GetOne(Guid userId)
        {
            // Check if user exists
            User? user = _userRepository.GetOne(userId);
            if (user is null) throw CustomErrorException.NotFound($"Error: User with id: {userId} is not found");
            // Carry on
            UserReadDto userReadDto = _mapper.Map<UserReadDto>(user);
            return userReadDto;
        }


        public UserReadDto UpdateOne(Guid userId, UserUpdateDto updatedUser)

        {
            // 1. Check If user exists
            User? targetUser = _userRepository.GetOne(userId);
            if (targetUser is null) throw CustomErrorException.NotFound($"Error: User with id: {userId} is not found");
            // 2. Check if the new  email is already used
            User? userEmailCheck = _userRepository.GetOneByEmail(updatedUser.Email);
            if (userEmailCheck is not null) throw CustomErrorException
            .UserAlreadyExists($"Error: Email {updatedUser.Email} is already used, please use another email !");
            // Carry on
            User updatedUserDto = _mapper.Map<User>(updatedUser);
            updatedUserDto = _userRepository.UpdateOne(targetUser, updatedUserDto);
            UserReadDto updatedUserReadDto = _mapper.Map<UserReadDto>(updatedUserDto);
            return updatedUserReadDto;
        }


        public UserReadDto SignUp(UserCreateDto newUser)
        {


            // Check if email is already in use
            User? foundUser = _userRepository.GetOneByEmail(newUser.Email);
            if (foundUser is not null) throw CustomErrorException
            .UserAlreadyExists($"Error: Email {newUser.Email} is already used, please sign in or use another email !");
            // Carry on
            byte[] pepper = Encoding.UTF8.GetBytes(_config["Jwt_Pepper"]);
            PasswordUtils.HashPassword(newUser.Password, out string hashedPassword, pepper);
            newUser.Password = hashedPassword;

            User userCreateDto = _mapper.Map<User>(newUser);
            userCreateDto = _userRepository.CreateOne(userCreateDto);
            UserReadDto userReadDto = _mapper.Map<UserReadDto>(userCreateDto);
            return userReadDto;

        }

        public string? Login(UserLogin userLogin)
        {
            Console.WriteLine($"{userLogin.Email}");
            Console.WriteLine($"{userLogin.Password}");
            // Check if the user exists by email
            User? user = _userRepository.GetOneByEmail(userLogin.Email);
            if (user is null) throw CustomErrorException.WrongCredentials("Error: Wrong Credentials! !");
            // Check if the password is correct
            byte[] pepper = Encoding.UTF8.GetBytes(_config["Jwt_Pepper"]);
            bool matchedPassword = PasswordUtils.VerifyPassword(userLogin.Password, user.Password, pepper);
            if (!matchedPassword) throw CustomErrorException.WrongCredentials("Error: Wrong Credentials !");
            // Carry on
            var claims = new[]
             {
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt_SigningKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt_Issuer"],
                audience: _config["Jwt_Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;

        }

        public void Delete(Guid targetUserId)
        {
            User targetUser = _userRepository.GetOne(targetUserId);
            _userRepository.Delete(targetUser);
            return;
        }
    }
}