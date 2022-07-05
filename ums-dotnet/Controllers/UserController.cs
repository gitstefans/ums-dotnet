using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ums_dotnet.Entities;
using ums_dotnet.Models;
using ums_dotnet.Services;

namespace ums_dotnet.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            var newUser = _mapper.Map<Entities.User>(user);
            await _userRepository.AddUserAsync(newUser);
            await _userRepository.SaveChangesAsync();
            var userToReturn = _mapper.Map<Models.UserDto>(newUser);
            //return Ok();
            return CreatedAtRoute("GetUser",
                new
                {
                    userId = userToReturn.Id,
                },
                userToReturn);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateUser(int userId, UserForCreationDto user)
        {
            var userExist = await _userRepository.GetUserAsync(userId);
            if(userExist == null)
            {
                return NotFound();
            }

            _mapper.Map(user, userExist);

            await _userRepository.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var userToDelete = await _userRepository.GetUserAsync(id);

            if(userToDelete == null)
            {
                return NotFound();
            }

            _userRepository.DeleteUser(userToDelete);
            await _userRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
