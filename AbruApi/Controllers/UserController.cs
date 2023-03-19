using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AbruApi.Dto;
using AbruApi.Helper;
using AbruApi.Repository.IRepository;

namespace AbruApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class UserController : ControllerBase
    {
        protected APIResponse _response;
        private IUserRepository _userRepository;
        public UserController(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
            _response = new();
        }

        [HttpGet]
        [Authorize(Roles ="Admin,User")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<APIResponse>> Get(Guid? Id)
        {
            if(Id!=null)
            {
                var user = await _userRepository.GetAsync(u => u.Id == Id, false);
                if (user != null)
                {
                    _response.statusCode = HttpStatusCode.OK;
                    _response.isSuccess = true;
                    _response.messages.Add("Successfuly Fecth User");
                    _response.result = user;
                    return Ok(_response);
                }
                _response.statusCode = HttpStatusCode.NotFound;
                _response.isSuccess = false;
                _response.messages.Add("User Not FOund");
                return Ok(_response);
            }
            var users = await _userRepository.GetAllAsync();
            if (users != null)
            {
                _response.statusCode = HttpStatusCode.OK;
                _response.isSuccess = true;
                _response.messages.Add("Successfuly Fecth Users");
                _response.result = await _userRepository.GetAllAsync();
                return Ok(_response);
            }
            _response.statusCode = HttpStatusCode.NotFound;
            _response.isSuccess = true;
            _response.messages.Add("Users Not Found");
     
            return Ok(_response);
        }

        

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<APIResponse>> Delete(Guid id)
        {
            var user = await _userRepository.GetAsync(u=>u.Id==id,false);
            if(user != null)
            {
                await _userRepository.DeleteAsync(user);  
                _response.statusCode = HttpStatusCode.OK;
                _response.isSuccess = true;
                _response.messages.Add("User Deleted");
                return Ok(_response);
                
            }
            _response.statusCode = HttpStatusCode.BadRequest;
            _response.isSuccess = false;
            _response.messages.Add("Faild to Delete");
            return Ok(_response);
        }

        [HttpGet("role")]
        public async Task<ActionResult<APIResponse>> Role(Guid? id)
        {
            var role = await _userRepository.GetAsync(u => u.Id == id, false);
            if (role==null || id==null)
            {
                _response.statusCode = HttpStatusCode.NotFound;
                _response.isSuccess = false;
                _response.messages.Add("User Not Found");
                return Ok(_response) ;
            }
            _response.statusCode = HttpStatusCode.OK; 
            _response.isSuccess = true;
            _response.messages.Add("User Found");
            _response.result = role.Role;
            return Ok(_response);
        }

    }
}
