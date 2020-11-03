using Core.Dto.RespostaGoogleAPI;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGoogleRespostaEndereco
    {
        Task<RespostaGoogleApi> ObterDadosEndereco(string RuaOuCep);
    }
}
