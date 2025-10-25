using Saref.Models.User;

namespace Saref.Services.UserService
{
    public interface IUser
    {
        Task<User> CreateUser(User user);
        Task<User> GetUser(User user);
        //Task<User> UpdateUser(User user);
        //Task<User> DeleteUser(User user);

    }
}
