using Core.Entidades;
using Core.Entidades.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Identity
{
    public class AppIdentityDbContextSeedData
    {
        public static async Task AppIdentitySeedData(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var usuario = new AppUser
                {
                    DisplayName = "Teste",
                    Email = "teste@teste.com",
                    UserName = "teste@teste.com",
                    Endereco = new Core.Entidades.Identity.Endereco
                    {
                        Nome = "teste",
                        Número = "1",
                        TipoLogradouro = "Rua",
                        Cep = "00000-000",
                        Bairro = "teste",
                        Cidade = "teste",
                        Estado = "teste"
                    }
                };

                await userManager.CreateAsync(usuario, "Pa$$w0rd");
            }
        }
    }
}
