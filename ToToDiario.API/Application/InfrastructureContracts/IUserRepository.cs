using ToToDiario.API.Domain.Entities;

namespace ToToDiario.API.Application.InfrastructureContracts
{
    public interface IUserRepository
    {
        public Task<int> RegisterUserAsync(User user, CancellationToken ct);

        public Task<List<User>> GetAllAsync(CancellationToken ct);

        public Task<bool> UserExistsAsync(int UserId, CancellationToken ct);
    }
}
