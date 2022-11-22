using Bookshelf.Api.ViewModels;

namespace Bookshelf.Api.Mappers
{
    public class UserToUserViewModelMapper
    {
        public static UserViewModel UserToUserViewModel(Domain.User.User user)
        {
            var userViewModel = new UserViewModel
            {
                UserId = user.Userid,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password
            };
            return userViewModel;
        }
    }
}5