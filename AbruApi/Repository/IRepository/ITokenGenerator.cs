using AbruApi.Entity;

namespace AbruApi.Repository.IRepository
{
    public interface ITokenGenerator
    {
        string GenerateToken(Guid Id,string Role);
    }
}
