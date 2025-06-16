using CognitusBackend.Domain.Entities;
using CognitusBackend.Domain.Repositories;
using CognitusBackend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CognitusBackend.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task<User?> getByEmailAsync(string email) 
        { 
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User?> getByIdAsync(Guid Id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task setUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
