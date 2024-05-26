using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class userController : ControllerTemplate
    {
        private IUserService _userService;
        private IMapper _mapper;

        public userController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]

        public IEnumerable<UserReadDto> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserReadDto>? GetOne(Guid userId)
        {
            var user = _userService.GetOne(userId);
            return Ok(user);
        }

        [HttpPatch("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserReadDto> UpdateOne(Guid userId, [FromBody] UserUpdateDto updatedUser)
        {
            if (updatedUser is not null)
            {
                UserReadDto user = _userService.UpdateOne(userId, updatedUser);
                return Ok(user);

            }
            return BadRequest();
        }

        [HttpPost("SignUp")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserReadDto> SignUp([FromBody] UserCreateDto newUser)
        {
            if (newUser is not null)
            {
                var createdUser = _userService.SignUp(newUser);
                return CreatedAtAction(nameof(SignUp), createdUser);
            }
            return BadRequest();
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<string> Login([FromBody] UserLogin User)
        {
            if (User is not null)
            {

                string token = _userService.Login(User);
                if (token is null) return BadRequest();

                return Ok(token);
            }
            return BadRequest();
        }

        [HttpDelete("{userId}")]
        [Authorize(Roles = "Admin")]
        public void Delete(Guid userId)
        {
            _userService.Delete(userId);
        }
    }
}