using AbruApi.Entity;

namespace AbruApi.Dto.AuthDto
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
