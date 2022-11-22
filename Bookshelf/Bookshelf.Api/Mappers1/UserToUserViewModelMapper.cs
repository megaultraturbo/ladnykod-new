using Bookshelf.Api.ViewModels;

namespace Bookshelf.Api.Mappers1;

public class UserToUserViewModelMapper
{
    public static UserViewModel UserToUserViewModel(Domain.User.User user)
    {
        var userViewModel = new UserViewModel
        {
            UserId = user.UserId,
            Email = user.Email,
            Password = user.Password,
            Username = user.Username
        };
        return userViewModel;
    }
}