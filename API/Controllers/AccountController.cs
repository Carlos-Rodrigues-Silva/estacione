using API.Extensions;
using Core.Dto;
using Core.Entidades;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            //var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            //var usuario = await _userManager.FindByEmailAsync(email);

            var usuario = await _userManager.EncontrarPeloEmailPeloClaimsPrinciple(HttpContext.User);

            return new UserDto
            {
                DisplayName = usuario.DisplayName,
                Email = usuario.Email,
                Token = _tokenService.CriarToken(usuario)
            };
        }

        [HttpGet("emailexiste")]
        public async Task<ActionResult<bool>> CheckEmailExistAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [Authorize]
        [HttpGet("endereco")]
        public async Task<ActionResult<EnderecoDto>> ObterEnderecousuario()
        {
            //var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            //var usuario = await _userManager.FindByEmailAsync(email);

            var usuario = await _userManager.EncontrarUsuarioPeloClaimsPrincipleComEnderecoAsync(HttpContext.User);

            //return usuario.Endereco;

            return new EnderecoDto
            {
                Nome = usuario.Endereco.Nome,
                Número = usuario.Endereco.Número,
                TipoLogradouro = usuario.Endereco.TipoLogradouro,
                Cep = usuario.Endereco.Cep,
                Bairro = usuario.Endereco.Bairro,
                Cidade = usuario.Endereco.Cidade,
                Estado = usuario.Endereco.Estado,
            };
        }

        [Authorize]
        [HttpPut("endereco")]
        public async Task<ActionResult<EnderecoDto>> AtualizarEnderecoUsuario([FromBody] EnderecoDto enderecoDto)
        {
            var usuario = await _userManager.EncontrarUsuarioPeloClaimsPrincipleComEnderecoAsync(HttpContext.User);

            usuario.Endereco = new Core.Entidades.Identity.Endereco
            {
                Nome = enderecoDto.Nome,
                Número = enderecoDto.Número,
                TipoLogradouro = enderecoDto.TipoLogradouro,
                Cep = enderecoDto.Cep,
                Bairro = enderecoDto.Bairro,
                Cidade = enderecoDto.Cidade,
                Estado = enderecoDto.Estado,
            };

            var resultado = await _userManager.UpdateAsync(usuario);

            if (resultado.Succeeded)
            {
                return Ok(
                new EnderecoDto
                {
                    Nome = usuario.Endereco.Nome,
                    Número = usuario.Endereco.Número,
                    TipoLogradouro = usuario.Endereco.TipoLogradouro,
                    Cep = usuario.Endereco.Cep,
                    Bairro = usuario.Endereco.Bairro,
                    Cidade = usuario.Endereco.Cidade,
                    Estado = usuario.Endereco.Estado,
                });
            }

            return BadRequest("Problema ao atualizar o usuário ");
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            var usuarioExiste = await _userManager.FindByEmailAsync(loginDto.Email);

            if (usuarioExiste == null) return BadRequest("Usuário não autorizado");

            var resultado = await _signInManager.CheckPasswordSignInAsync(usuarioExiste, loginDto.Senha, false);

            if (!resultado.Succeeded) return BadRequest("Usuário não autorizado");

            var usuario = new UserDto
            {
                DisplayName = usuarioExiste.DisplayName,
                Email = loginDto.Email,
                Token = _tokenService.CriarToken(usuarioExiste)
            };

            return usuario;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UserDto>> Registrar([FromBody] RegistrarDto registrarDto)
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
                return BadRequest("Usuário não autorizado");
            }

            return new UserDto
            {
                DisplayName = cadastarUsuario.DisplayName,
                Email = cadastarUsuario.Email,
                Token = _tokenService.CriarToken(cadastarUsuario)
            };
        }
    }
}
