using AutoMapper;
using BLL;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    [Authorize]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly TokenService _tokenService;
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthController(UserService userService,
            TokenService tokenService,
            UserRepository userRepository,
            IMapper mapper)
        {
            _userService = userService;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("registration")]
        public IActionResult Registration([FromBody] RegisterModel model)
        {
            
            if (_userService.IsLoginTaken(model.Login))
            {
                return BadRequest(new ErrorMessageModel()
                {
                    Message = "Login is taken"
                });
            }

            if (_userService.IsNameTaken(model.Name))
            {
                return BadRequest(new ErrorMessageModel()
                {
                    Message = "Name is taken"
                });
            }

            var user = _userService.Register(model.Login, model.Name, model.Password, model.Role);  
            var accessToken = new AccessToken() { Token = _tokenService.GenerateJwtToken(user) };

            return Ok(accessToken);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _userService.Authenticate(_mapper.Map<User>(model));

            if (user == null)
            {
                return Unauthorized(new ErrorMessageModel()
                {
                    Message = "login or password are incorrect"
                });
            }

            var accessToken = new AccessToken() { Token = _tokenService.GenerateJwtToken(user) };

            return Ok(accessToken);
        }
    }
}
