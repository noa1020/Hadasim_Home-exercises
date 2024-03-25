using CoronaManagementSystem.Models;

namespace CoronaManagementSystem.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        Task<bool> Delete(string id);
        Task<bool> Update(User newUser);
        Task<User?> GetById(string id);
        Task<bool> Add(User newUser);
    }
}