using System;
using System.Threading.Tasks;
using Bookshelf.Api.BindingModels;
using Bookshelf.Api.Validation;
using Bookshelf.Api.ViewModels;
using Bookshelf.Data.Sql;
using Bookshelf.Data.SQL.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : Controller
    {
        private readonly BookshelfDbContext _context;

        public UserController(BookshelfDbContext context)
        {
            _context = context;
        }
        
        [HttpGet(template:"GetAllUsers")]
        public  List<User> GetAllUsers()
        {
            return  _context.User.ToList();
        }

        [HttpGet("{userId:min(1)}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserByID(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);

            if (user != null)
            {
                return Ok(new UserViewModel
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password,
                });
            }

            return NotFound();
        }

        [HttpGet("name/{username}", Name = "GetUserByUserName")]
        public async Task<IActionResult> GetUserByUserName(string username)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Username == username);

            if (user != null)
            {
                
                return Ok(new UserViewModel
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password,
                });
            }

            return NotFound();
        }

        [ValidateModel]
        //        [Consumes("application/x-www-form-urlencoded")]
        //        [HttpPost("create", Name = "CreateUser")]
        public async Task<IActionResult> Post([FromBody] CreateUser createUser)
        {
            var user = new User
            {

                Username = createUser.Username,
                Email = createUser.Email,
                Password = createUser.Password,
            };
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return Created(user.UserId.ToString(), new UserViewModel
            {
                UserId = user.UserId,
                Username = createUser.Username,
                Email = createUser.Email,
                Password = createUser.Password,
            });
        }

        [ValidateModel]
        [HttpPatch("edit/{userId:min(1)}", Name = "EditUser")]
        //        public async Task<IActionResult> EditUser([FromBody] EditUser editUser,[FromQuery] int userId)
        public async Task<IActionResult> EditUser([FromBody] EditUser editUser, int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            
            user.Username = editUser.Username;
            user.Email = editUser.Email;
            user.Password = editUser.Password;
            
            await _context.SaveChangesAsync();
            return NoContent();
            return Ok(new UserViewModel
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
            });
        }

        [HttpDelete("delete/{userId:min(1)}", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            var reviewpref =  _context.ReviewPreference.Where(x => x.UserId == userId);
            _context.ReviewPreference.RemoveRange(reviewpref);
            
            var review =  _context.Review.Where(x => x.UserId == userId);
            _context.Review.RemoveRange(review);
            
            var bookpref =  _context.BookPreference.Where(x => x.UserId == userId);
            _context.BookPreference.RemoveRange(bookpref);
            
            var authorpref =  _context.AuthorPreference.Where(x => x.UserId == userId);
            _context.AuthorPreference.RemoveRange(authorpref);
            
            
            _context.User.Remove(user);

            await _context.SaveChangesAsync();
            return NoContent();
        }

    }

    /*public class ApiVersionAttribute : Attribute
    {
        public ApiVersionAttribute(string s)
        {
            throw new NotImplementedException();
        }
    }*/
}
