using Core.Entidades;
using Core.Entidades.OrdemAggregate;
using Core.Interfaces;
using Core.Specifications;
using Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Services
{
    public class OrdemService : IOrdemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _basketRepository;

        public OrdemService(IUnitOfWork unitOfWork, IBasketRepository basketRepository)
        {
            _unitOfWork = unitOfWork;
            _basketRepository = basketRepository;
        }
        public async Task<Ordem> CriarOrdemAsync(string emailComprador, string cestaId)
        {
            CestaCliente cesta = await _basketRepository.GetBasketAsync(cestaId);

            var itens = new List<VagaAlugada>();
            foreach (BasketItem item in cesta.ItensCestaCliente)
            {
                var spec = new EstacionamentoComEnderecoSpecification(item.Id);
                Estacionamento estacionamento = await _unitOfWork.Repositorio<Estacionamento>().ObterEntidadeComSpec(spec);
                VagaOrdenada vagaOrdenada = new VagaOrdenada(estacionamento.NomeEstacionamento, estacionamento.Endereco.NomeLogradouro, estacionamento.Endereco.Numero, estacionamento.Endereco.Cep, estacionamento.Endereco.Bairro, estacionamento.Endereco.Cidade, estacionamento.Endereco.Estado);
                VagaAlugada vagaAlugada = new VagaAlugada(vagaOrdenada, (decimal)estacionamento.PrecoHora, item.Quantidade);
                itens.Add(vagaAlugada);
            }

            var total = itens.Sum(ItensCestaCliente => ItensCestaCliente.Preco * ItensCestaCliente.Quantidade);

            Ordem ordem = new Ordem(itens, emailComprador, total);
            _unitOfWork.Repositorio<Ordem>().Adicionar(ordem);

            var resultado = await _unitOfWork.Complete();

            if (resultado <= 0) return null;

            await _basketRepository.DeleteBasketAsync(cestaId);

            return ordem;
        }

        public async Task<Ordem> ObterOrdemPeloId(int id, string emailComprador)
        {
            var spec = new OrdemComVagasOrdenadasSpecification(id, emailComprador);

;           return await _unitOfWork.Repositorio<Ordem>().ObterEntidadeComSpec(spec);
        }


        public async Task<IReadOnlyList<Ordem>> ObterOrdensAsync(string emailComprador)
        {
            var spec = new OrdemComVagasOrdenadasSpecification(emailComprador);
            return await _unitOfWork.Repositorio<Ordem>().ListarTodosAsync(spec);
        }
    }
}
