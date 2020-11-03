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
            // Obter cesta de compras
            CestaCliente cesta = await _basketRepository.GetBasketAsync(cestaId);

            // Obter itens 
            var itens = new List<VagaAlugada>();
            foreach (BasketItem item in cesta.ItensCestaCliente)
            {
                //Estacionamento estacionamento = await _dataContext.Estacionamentos.FindAsync(item.Id);
                //Estacionamento estacionamento = await _context.Estacionamentos.Include(e => e.Endereco).FirstOrDefaultAsync(x => x.Id == item.Id);
                var spec = new EstacionamentoComEnderecoSpecification(item.Id);
                Estacionamento estacionamento = await _unitOfWork.Repositorio<Estacionamento>().ObterEntidadeComSpec(spec);
                VagaOrdenada vagaOrdenada = new VagaOrdenada(estacionamento.NomeEstacionamento, estacionamento.Endereco.NomeLogradouro, estacionamento.Endereco.Numero, estacionamento.Endereco.Cep, estacionamento.Endereco.Bairro, estacionamento.Endereco.Cidade, estacionamento.Endereco.Estado);
                VagaAlugada vagaAlugada = new VagaAlugada(vagaOrdenada, (decimal)estacionamento.PrecoHora, item.Quantidade);
                itens.Add(vagaAlugada);
            }

            // Calcular total
            var total = itens.Sum(ItensCestaCliente => ItensCestaCliente.Preco * ItensCestaCliente.Quantidade);

            // verificar se a ordem já existe

            // Criar ordem nova 
            Ordem ordem = new Ordem(itens, emailComprador, total /*cestaCliente.PaymentIntentId*/);
            _unitOfWork.Repositorio<Ordem>().Adicionar(ordem);

            // salvar no banco de dados
            var resultado = await _unitOfWork.Complete();

            // Se o resultado for zero retornar null
            if (resultado <= 0) return null;

            // Deletar cesta de compras (por que a ordem já foi retornada e salva)
            await _basketRepository.DeleteBasketAsync(cestaId);

            //retorna nova ordem
            return ordem;
        }

        public Task<Ordem> ObterOrdemPeloId(int id, string emailComprador)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Ordem>> ObterOrdensAsync(string emailComprador)
        {
            throw new NotImplementedException();
        }
    }
}
