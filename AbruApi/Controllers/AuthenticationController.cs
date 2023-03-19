using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AbruApi.Dto.AuthDto;
using AbruApi.Helper;
using   AbruApi.Repository.IRepository;

namespace AbruApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected APIResponse _response;
        private IUserRepository _repository;
        public AuthenticationController(IUserRepository repository)
        {
            _repository = repository;
            _response = new();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<APIResponse>> Login([FromBody] LoginRequestDto request)
        {
            var response = await _repository.Login(request);
            if (response.Id == null || string.IsNullOrEmpty(response.Token))
            {
                _response.statusCode = HttpStatusCode.Unauthorized;
                _response.isSuccess = false;
                _response.messages.Add("Username or Password is incorrect");
                return Ok(_response);
            }
            _response.statusCode = HttpStatusCode.OK;
            _response.isSuccess = true;
            _response.messages.Add("Access Granted");
            _response.result = response;

            return Ok(_response);
        }
        [HttpPost("register")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<APIResponse>> Register([FromBody] RegisterationRequestDto request)
        {
            if(!(await _repository.Register(request)))
            {
                _response.statusCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                _response.messages.Add("Failed to create user");
                return Ok(_response);
            }

            _response.statusCode = HttpStatusCode.OK;
            _response.isSuccess = true;
            _response.messages.Add("User created");
            _response.result = true;

            return Ok(_response);
        }
    }
}
