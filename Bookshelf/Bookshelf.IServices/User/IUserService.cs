using System.Threading.Tasks;
using Bookshelf.IServices.Requests;

namespace Bookshelf.IServices.User
{
    public interface IUserService
    {
        Task<Bookshelf.Domain.User.User> GetUserByUserId(int userId);
        Task<Bookshelf.Domain.User.User> GetUserByUserName(string userName);
        Task<Bookshelf.Domain.User.User> CreateUser(CreateUser createUser);
        Task EditUser(EditUser createUser, int userId);
    }
}