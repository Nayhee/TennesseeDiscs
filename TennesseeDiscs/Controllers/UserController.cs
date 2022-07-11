using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TennesseeDiscs.Models;
using TennesseeDiscs.Repositories;

namespace TennesseeDiscs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userRepository.GetAllUsers());
        }

        // https://localhost:5001/api/user/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // https://localhost:5001/api/User/
        [HttpPost]
        public IActionResult Post(User user)
        {
            _userRepository.AddUser(user);
            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        // https://localhost:5001/api/user/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _userRepository.UpdateUser(user);
            return NoContent();
        }

        // https://localhost:5001/api/User/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
}
