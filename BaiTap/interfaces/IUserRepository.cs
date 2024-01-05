using BaiTap.Models;

namespace BaiTap.interfaces
{
    public interface IUserRepository
    { 
        ICollection<User> GetUsers();
        User GetUser(int id);
        User GetUser(string username);
        bool UserExists(int userId);
        bool CreateUser( User user);
        bool UpdateUser( User user );
        bool DeleteUser(User user);
        bool Save();
            

        }
    }
