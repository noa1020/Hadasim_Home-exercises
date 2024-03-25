using Microsoft.AspNetCore.Mvc;
using CoronaManagementSystem.Interfaces;
using CoronaManagementSystem.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http.Features;

namespace CoronaManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        
        //Get all users.
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            var users = userService.GetAll();
            return Ok(users);
        }

        //Get user by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(string id)
        {
            var myUser = await userService.GetById(id);
            if (myUser == null)
            {
                return NotFound();
            }
            return Ok(myUser);
        }
        
        //Add new user.
        [HttpPost]
        public async Task<IActionResult> CreateAsync(User newUser)
        {
            if (newUser == null)
            {
                return BadRequest("User object is null");
            }
            var existingUser = await userService.GetById(newUser.UserId!);
            if (existingUser != default)
            {
                return BadRequest("User ID already exists");
            }
            try
            {
                var tasks = new List<Task> { userService.Add(newUser) };
                await Task.WhenAll(tasks);
                return CreatedAtAction(nameof(CreateAsync), new { id = newUser.UserId }, newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
       
        //Update an existing user.
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(User userToUpdate)
        {
            if (userToUpdate == null)
            {
                return BadRequest("User object is null");
            }
            User? user = await userService.GetById(userToUpdate.UserId!);
            if (user == null)
            {
                return NotFound("User not found");
            }
            try
            {
                await userService.Update(userToUpdate);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        //Delete user by ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            try
            {
                await userService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
