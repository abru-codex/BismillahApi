using AbruApi.Dto.AuthDto;
using AbruApi.Entity;

namespace AbruApi.Repository.IRepository
{
    public interface IUserRepository:IRepository<User>
    {
        Task<bool> IsUninqueUser(string username,string email);
        Task<LoginResponseDto> Login(LoginRequestDto request);
        Task<bool> Register(RegisterationRequestDto request);
        Task<bool> Update(User entity);

    }
}
