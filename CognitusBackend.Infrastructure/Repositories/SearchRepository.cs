using CognitusBackend.Domain.Entities;
using CognitusBackend.Domain.Repositories;
using CognitusBackend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CognitusBackend.Infrastructure.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly Context _context;

        public SearchRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<UserSearch>> GetUserSearchAsync(Guid userId)
        {
            return await _context.UserSearches
                .Where(s => s.UserId == userId)
                .Take(5)
                .ToListAsync();
        }

        public async Task setLastSearch(UserSearch DataLastSearch)
        {
            await _context.UserSearches.AddAsync(DataLastSearch);
            await _context.SaveChangesAsync();
        }
    }
}

