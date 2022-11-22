using System.Threading.Tasks;
using Bookshelf.Data.Sql.User;
using Bookshelf.IData.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Bookshelf.Data.Sql.Tests.User
{
    public class UserRepositoryTest
    {
        public IConfiguration Configuration { get; }
        private BookshelfDbContext _context;
        private IUserRepository _userRepository;

        public UserRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookshelfDbContext>();
            optionsBuilder.UseMySQL(
                "server=localhost;userid=root;pwd=;port=3306;database=bookshelf_db;");
            _context = new BookshelfDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _userRepository = new UserRepository(_context);
        }

        [Fact]
        public async Task AddUser_Returns_Correct_Response()
        {
            var user = new Domain.User.User("Username", "Email@email.com", "Fajnehaslo");

            var userId = await _userRepository.AddUser(user);

            var createdUser = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            Assert.NotNull(createdUser);

            _context.User.Remove(createdUser);
            await _context.SaveChangesAsync();
        }
    }
}