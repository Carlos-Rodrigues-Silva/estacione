using Core.Dto.RespostaGoogleAPI;
using Core.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infraestrutura.Services
{
    public class GoogleRespostaEndereco : IGoogleRespostaEndereco
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<RespostaGoogleApi> ObterDadosEndereco(string numero, string RuaOuCep)
        {
            HttpResponseMessage response = await client.GetAsync($"https://maps.googleapis.com/maps/api/geocode/json?address={numero}+{RuaOuCep}&key=AIzaSyCX_AvtVNCQdY8I_6Gxe6-YgqEo1vMEAqc");

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            RespostaGoogleApi resultado = JsonConvert.DeserializeObject<RespostaGoogleApi>(responseBody);

            return resultado;
        }
    }
}
