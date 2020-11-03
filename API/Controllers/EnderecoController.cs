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
        //private readonly DataContext _context;
        private readonly IRepositorioGenerico<Endereco> _repositorioGenerico;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoogleRespostaEndereco _googleRespostaEndereco;
        private static readonly HttpClient client = new HttpClient();

        public EnderecoController(IGoogleRespostaEndereco googleRespostaEndereco, IUnitOfWork unitOfWork)
        {
            _googleRespostaEndereco = googleRespostaEndereco;
            _unitOfWork = unitOfWork;
        }

        #region Teste

        //[HttpGet("enderecos")]
        //public async Task<ActionResult<List<Estacionamento>>> Estacionamentos()
        //{
        //    return Ok(await _context.Estacionamentos.Include(e => e.Endereco.Logradouro).ToListAsync());
        //}


        //[HttpGet("endereco/{id}")]
        //public async Task<ActionResult<List<Estacionamento>>> Estacionamento(int id)
        //{
        //    var estacionamento = await _context.Estacionamentos.Include(e => e.Endereco.Logradouro).FirstOrDefaultAsync(x => x.Id == id);

        //    if (estacionamento == null)
        //    {
        //        return BadRequest("Estacionamento não cadastrado!");
        //    }

        //    return Ok(estacionamento);
        //}

        #endregion

        [HttpPost("logradourooucep")]
        public async Task<ActionResult<RespostaEnderecoDto>> Estacionamento(ReceberRuaOuNomeDto receberRuaOuNomeDto)
        {
            //var estacionamento = await _context.Estacionamentos.Include(e => e.Endereco.Logradouro).FirstOrDefaultAsync(x => x.NomeEstacionamento.ToLower() == receberRuaOuNomeDto.RuaOuCep.ToLower());
            //var enderecoExistee = await _context.Enderecos.Include(x => x.Estacionamento).FirstOrDefaultAsync(x => x.NomeLogradouro == receberRuaOuNomeDto.RuaOuCep.ToLower() || x.Cep == receberRuaOuNomeDto.RuaOuCep.ToLower());

            var spec = new EnderecoComEstacionamentoSpecification(receberRuaOuNomeDto.RuaOuCep);
            var enderecoExiste = await _unitOfWork.Repositorio<Endereco>().ObterEntidadeComSpec(spec);


            if (enderecoExiste == null)
            {
                return BadRequest("Nenhum estacionamento encontrado nessa rua");
            }

            Task<RespostaGoogleApi> resultado = _googleRespostaEndereco.ObterDadosEndereco(receberRuaOuNomeDto.RuaOuCep);

            return new RespostaEnderecoDto
            {
                FormattedAddress = resultado.Result.Results[0].FormattedAddress,
                Latitude = resultado.Result.Results[0].Geometry.Location.Lat,
                Longitude = resultado.Result.Results[0].Geometry.Location.Lng,
                NomeEstacionamento = enderecoExiste.Estacionamento.NomeEstacionamento,
                NomeLogradouro = enderecoExiste.NomeLogradouro,
                Numero = enderecoExiste.Numero,
                PrecoHora = enderecoExiste.Estacionamento.PrecoHora,
            };
        }

        [HttpGet("localizacao")]
        public async Task<ActionResult<RespostaEnderecoDto>> Localizacao()
        {
            var localizacao = await _repositorioGenerico.ListarTodosAsync();

            return Ok(localizacao);
        }
    }
}
