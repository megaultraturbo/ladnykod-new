using System.Threading.Tasks;
using Bookshelf.IData.User;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;

namespace BookReview.Data.Sql.User
{
    public class UserRepository : IUserRepository
    {
        private readonly BookReviewDbContext _context;

        public UserRepository(BookReviewDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddUser(Domain.User.User user)
        {
            var userDAO = new DAO.User
            {
                Email = user.Email,
                UserName = user.UserName,
                Gender = user.Gender,
                BirthDate = user.BirthDate,
                RegistrationDate = user.RegistrationDate,
                EditionDate = user.EditionDate,
                IsActiveUser = user.IsActiveUser,
                IsBannedUser = user.IsBannedUser,
                ReviewCount = user.ReviewCount,
            };
            await _context.AddAsync(userDAO);
            await _context.SaveChangesAsync();
            return userDAO.UserId;
        }

        public async Task<Domain.User.User> GetUser(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            return new Domain.User.User(user.UserId,
                user.UserName,
                user.Email,
                user.RegistrationDate,
                user.EditionDate,
                user.Gender,
                user.BirthDate,
                user.IsBannedUser,
                user.IsActiveUser,
                user.ReviewCount,
                user.AccountDescription,
                user.IconHref);
        }

        public async Task<Domain.User.User> GetUser(string userName)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserName == userName);
            return new Domain.User.User(user.UserId,
                user.UserName,
                user.Email,
                user.RegistrationDate,
                user.EditionDate,
                user.Gender,
                user.BirthDate,
                user.IsBannedUser,
                user.IsActiveUser,
                user.ReviewCount,
                user.AccountDescription,
                user.IconHref);
        }

        public async Task EditUser(Domain.User.User user)
        {
            var editUser = await _context.User.FirstOrDefaultAsync(x => x.UserId == user.Id);
            editUser.UserName = user.UserName;
            editUser.Email = user.Email;
            editUser.Gender = user.Gender;
            editUser.BirthDate = user.BirthDate;
            editUser.EditionDate = user.EditionDate;
            await _context.SaveChangesAsync();
        }
    }
}
