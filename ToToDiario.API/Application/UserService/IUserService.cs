using ToToDiario.API.Application.Models;

namespace ToToDiario.API.Application.UserService
{
    public interface IUserService
    {
        public Task<UserConfirmacion> RegisterUserAsync(UserRegisterDto userDto, CancellationToken ct);

        public Task<UsersDto> GetAllAsync(CancellationToken ct);
    }

}
