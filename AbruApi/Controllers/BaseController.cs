using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AbruApi.Dto;
using AbruApi.Helper;
using AbruApi.Repository.IRepository;

namespace AbruApi.Controllers
{

    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;
        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected APIResponse Response<T, TResponseDto>(HttpStatusCode statusCode, bool isSuccess, string message, T? result)
        {
            return new APIResponse
            {
                statusCode = statusCode,
                isSuccess = isSuccess,
                messages = new List<string> { message },
                result = _mapper.Map<T, TResponseDto>(result)
            };
        }
    }
}
