using Core.Dto;
using Core.Entidades.OrdemAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdemController : ControllerBase
    {
        private readonly IOrdemService _ordemService;

        public OrdemController(IOrdemService ordemService)
        {
            _ordemService = ordemService;
        }

        [HttpPost]
        public async Task<ActionResult<Ordem>> CriarOrdem(OrdemDto ordemDto)
        {
            var ordem =  await _ordemService.CriarOrdemAsync(ordemDto.email, ordemDto.cestaId);

            if (ordem == null)
            {
                return BadRequest("Problema para criar a ordem");
            }
            return Ok(ordem);
        }
    }
}
