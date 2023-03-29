using Microsoft.EntityFrameworkCore;
using ToToDiario.API.Application.InfrastructureContracts;
using ToToDiario.API.Domain.Entities;

namespace ToToDiario.API.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllAsync(CancellationToken ct)
        {
            return await _context.Users.Select(
                u => new User {
                        Nombres = u.Nombres,
                        Apellidos = u.Apellidos,
                        UserId= u.UserId
                    })
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<int> RegisterUserAsync(User user, CancellationToken ct)
        {
            await _context.Users.AddAsync(user,ct);   
            int result = await _context.SaveChangesAsync(ct);

            if(result > 0)
            {
                return user.UserId;
            }
            return 0;
        }

        public async Task<bool> UserExistsAsync(int UserId, CancellationToken ct)
        {
            return await _context.Users.AnyAsync(u => u.UserId == UserId,ct);
        }
    }
}
