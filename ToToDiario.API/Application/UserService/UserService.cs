using ToToDiario.API.Application.InfrastructureContracts;
using ToToDiario.API.Application.Models;
using ToToDiario.API.Application.UserService;
using ToToDiario.API.Domain.Entities;
using ToToDiario.API.Domain.Shared.ExtensionsMethods;
using static ToToDiario.API.Domain.Enums.Enums;

namespace ToToDiario.API.Services.UserService
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }


        public async Task<UsersDto> GetAllAsync(CancellationToken ct)
        {
            var Users = await _userRepository.GetAllAsync(ct);

            var UsersList = new UsersDto();

            if (Users is not null && Users.Count > 0)
            {
                UsersList.Users = Users.Select(o => new UserBaseDto
                {
                    Apellidos = o.Apellidos,
                    Nombres = o.Nombres,
                    UserId = o.UserId,
                }).ToList();
                UsersList.Result = ResultStatus.Success;
                UsersList.ResultMessage = ResultStatus.Success.GetDescription();

                return UsersList;
            }
            UsersList.Users = Enumerable.Empty<UserBaseDto>();
            UsersList.Result = ResultStatus.NoRecords;
            UsersList.ResultMessage = ResultStatus.NoRecords.GetDescription();

            return UsersList;
        }

        public async Task<UserConfirmacion> RegisterUserAsync(UserRegisterDto userDto, CancellationToken ct)
        {
            var user = new User
            {
                Apellidos = userDto.Apellidos,
                Nombres = userDto.Nombres,
            };

            var userEntityId = await _userRepository.RegisterUserAsync(user, ct);

            var UserConfirmacion = new UserConfirmacion();
            UserConfirmacion.UserId = userEntityId;
            if (userEntityId > 0)
            {
                UserConfirmacion.Result = ResultStatus.Success;
                UserConfirmacion.ResultMessage = ResultStatus.Success.GetDescription();
                return UserConfirmacion;
            }

            UserConfirmacion.Result = ResultStatus.Error;
            UserConfirmacion.ResultMessage = ResultStatus.Error.GetDescription();
            return UserConfirmacion;
        }
    }
}
