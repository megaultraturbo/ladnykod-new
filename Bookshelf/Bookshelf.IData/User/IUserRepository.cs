using System.Threading.Tasks;

namespace Bookshelf.IData.User
{
    public interface IUserRepository
    {
        Task<int> AddUser(Bookshelf.Domain.User.User user);
        Task<Bookshelf.Domain.User.User> GetUser(int userId);
        Task<Bookshelf.Domain.User.User> GetUser(string userName);
        Task EditUser(Domain.User.User user);
    }
}