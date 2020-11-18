using Core.Dto;
using Core.Dto.RespostaGoogleAPI;
using Core.Entidades;
using Core.Interfaces;
using Core.Specifications;
using Infraestrutura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IRepositorioGenerico<Endereco> _repositorioGenerico;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoogleRespostaEndereco _googleRespostaEndereco;
        private static readonly HttpClient client = new HttpClient();

        public EnderecoController(IGoogleRespostaEndereco googleRespostaEndereco, IUnitOfWork unitOfWork)
        {
            _googleRespostaEndereco = googleRespostaEndereco;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("logradourooucep")]
        public async Task<ActionResult<List<RespostaEnderecoDto>>> Estacionamento(ReceberNumeroNomeCep receberRuaOuNomeDto)
        {
            var spec = new EnderecoComEstacionamentoSpecification(receberRuaOuNomeDto.RuaOuCep);
            List<Endereco> enderecoExiste = await _unitOfWork.Repositorio<Endereco>().ListarTodosAsync(spec);

            if (enderecoExiste == null)
            {
                return BadRequest(400);
            }

            var respostaEnderecoDtoLista = new List<RespostaEnderecoDto>();
            var listaEnderecosGoogleApi = new List<Task<RespostaGoogleApi>>();
            foreach (Endereco enderecos in enderecoExiste)
            {
                Task<RespostaGoogleApi> resultado = _googleRespostaEndereco.ObterDadosEndereco(enderecos.Numero, receberRuaOuNomeDto.RuaOuCep);
                listaEnderecosGoogleApi.Add(resultado);

                foreach(var resultadoGoogle in resultado.Result.Results)
                {
                    RespostaEnderecoDto resultadoRespostaEnderecoDto = new RespostaEnderecoDto
                    {
                        Id = enderecos.Id,
                        NomeEstacionamento = enderecos.Estacionamento.NomeEstacionamento,
                        NomeLogradouro = enderecos.NomeLogradouro,
                        Numero = enderecos.Numero,
                        PrecoHora = enderecos.Estacionamento.PrecoHora,
                        FormattedAddress = resultadoGoogle.FormattedAddress,
                        Latitude = resultadoGoogle.Geometry.Location.Lat,
                        Longitude = resultadoGoogle.Geometry.Location.Lng,
                        FotoEstacionamento = "https://localhost:5001/imagens/parkauto.png"
                    };
                    respostaEnderecoDtoLista.Add(resultadoRespostaEnderecoDto);
                }
            }

            return respostaEnderecoDtoLista;
        }

        [HttpGet("localizacao")]
        public async Task<ActionResult<RespostaEnderecoDto>> Localizacao()
        {
            var localizacao = await _unitOfWork.Repositorio<Core.Entidades.Location>().ListarTodosAsync();
            return Ok(localizacao);
        }
    }
}
