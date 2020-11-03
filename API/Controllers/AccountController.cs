using Core.Dto;
using Core.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<UserDto> Login([FromBody] LoginDto loginDto)
        {
            var usuarioExiste = await _userManager.FindByEmailAsync(loginDto.Email);

            if (usuarioExiste == null) return null;

            var resultado = await _signInManager.CheckPasswordSignInAsync(usuarioExiste, loginDto.Senha, false);

            if (!resultado.Succeeded) return null;

            var usuario = new UserDto
            {
                DisplayName = usuarioExiste.DisplayName,
                Email = loginDto.Email,
                Token = "Esse é o token do usuário"
            };

            return usuario;
        }

        [HttpPost("registrar")]
        public async Task<UserDto> Registrar([FromBody] RegistrarDto registrarDto)
        {
            //var usuarioExiste = _userManager.FindByEmailAsync(registrarDto.Email);

            //if (usuarioExiste == null)
            //{
            //    return null;
            //}

            var cadastarUsuario = new AppUser
            {
                DisplayName = registrarDto.DisplayName,
                Email = registrarDto.Email,
                UserName = registrarDto.Email
            };

            var resultado = await _userManager.CreateAsync(cadastarUsuario, registrarDto.Senha);

            if (!resultado.Succeeded)
            {
                return null;
            }

            return new UserDto
            {
                DisplayName = cadastarUsuario.DisplayName,
                Email = cadastarUsuario.Email,
                Token = "Token teste"
            };
        }


    }
}
