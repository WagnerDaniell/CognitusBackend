using CognitusBackend.Domain.Entities;

namespace CognitusBackend.Domain.Repositories
{
    public interface ISearchRepository
    {
        Task<List<UserSearch>> GetUserSearchAsync(Guid id);
        Task setLastSearch(UserSearch DataLastSearch);
    }
}
