using CognitusBackend.Domain.Entities;

namespace CognitusBackend.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> getByEmailAsync(string email);
        Task<User?> getByIdAsync(Guid Id);
        Task setUserAsync(User user);
    }
}
