using System.Threading.Tasks;
using Bookshelf.IData.User;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Bookshelf.Data.SQL.DAO;

namespace Bookshelf.Data.Sql.User
{
    public class UserRepository: IUserRepository
    {
        private readonly BookshelfDbContext _context;

        public UserRepository(BookshelfDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddUser(Domain.User.User user)
        {
            var userDAO =  new SQL.DAO.User { 
                Username = user.Username,
                Email = user.Email,
                Password = user.Password
            };
            await _context.AddAsync(userDAO);
            await _context.SaveChangesAsync();
            return userDAO.UserId;
        }

        public async Task<Domain.User.User> GetUser(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x=>x.UserId == userId);
            return new Domain.User.User(user.UserId,
                user.Username,
                user.Email, 
                user.Password);
        }

        public async Task<Domain.User.User> GetUser(string userName)
        {
            var user = await _context.User.FirstOrDefaultAsync(x=>x.Username == userName);
            return new Domain.User.User(user.UserId,
                user.Username,
                user.Email, 
                user.Password);
        }

        public async Task EditUser(Domain.User.User user)
        {
            var editUser = await _context.User.FirstOrDefaultAsync(x=>x.UserId == user.UserId);
            editUser.Username = user.Username;
            editUser.Email = user.Email;
            editUser.Password = user.Password;
            await _context.SaveChangesAsync();
        }
    }

}