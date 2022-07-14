using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [HttpPost]
        public IActionResult Post(User user)
        {
            _userRepository.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { firebaseUserId = user.FirebaseUserId }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user) //may want to update based on FireBaseId
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _userRepository.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) //may want to delete based on firebaseId.
        {
            _userRepository.DeleteUser(id);
            return NoContent();
        }


        [HttpGet("{firebaseUserId}")]
        public IActionResult GetUser(string firebaseUserId)
        {
            return Ok(_userRepository.GetByFirebaseUserId(firebaseUserId));
        }



        [HttpGet("GetCurrentUser")]
        public IActionResult GetLoggedInUser()
        {
            User user = GetCurrentUserProfile();
            user.FirebaseUserId = "ENCRYPTED ID";
            return Ok(user);
        }

        [HttpGet("DoesUserExist/{firebaseUserId}")]
        public IActionResult DoesUserExist(string firebaseUserId)
        {
            var user = _userRepository.GetByFirebaseUserId(firebaseUserId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok();
        }



        private User GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userRepository.GetByFirebaseUserId(firebaseUserId);
        }

        
    }
}
