using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AbruApi.DataAccess;
using AbruApi.Dto.AuthDto;
using AbruApi.Entity;
using AbruApi.Repository.IRepository;

namespace AbruApi.Repository
{
    public class UserRepository :Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ITokenGenerator _tokenGenerator;
        public UserRepository(ApplicationDbContext db, ITokenGenerator tokenGenerator) : base(db)
        {
            _db = db;
            _tokenGenerator = tokenGenerator;
        }
        public async Task<bool> IsUninqueUser(string username,string email)
        {
            var user =await _db.Users.FirstOrDefaultAsync(x=>x.UserName.ToLower() == username || x.Email.ToLower()==email);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto request)
        {
            var user =await _db.Users.FirstOrDefaultAsync(u=>u.UserName.ToLower()==request.UserName.ToLower() 
                        && u.Password==request.Password);
            if (user == null)
            {
                return new LoginResponseDto();
            }
            LoginResponseDto response = new LoginResponseDto()
            {
                Id=user.Id,
                Name=user.Name,
                UserName=user.UserName,
                Role=user.Role,
                Token = _tokenGenerator.GenerateToken(user.Id,user.Role)
            };
            return response;
        }

        public async Task<bool> Register(RegisterationRequestDto request)
        {
            if(!(await IsUninqueUser(request.UserName,request.Email)))
            {
                return false;
            }        
            User user = new User()
            {
                Name = request.Name,
                UserName = request.UserName,
                Password = request.Password,
                Email = request.Email,
                Role="User"
            };
            await CreatAsync(user);
            return true;
        }

        public async Task<bool> Update(User request)
        {
            var user = await GetAsync(u=>u.Id==request.Id,false);
            if (user == null)
            {
                return false;
            }
            if (!(await IsUninqueUser(user.UserName, user.Email)))
            {
                return false;
            }
            _db.Update(user);
            return true;
        }
    }
}
