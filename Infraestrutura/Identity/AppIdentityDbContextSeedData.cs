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
                    DisplayName = "Carlos Rodrigues",
                    Email = "carlos@email.com",
                    UserName = "carlos@email.com",
                    Endereco = new Core.Entidades.Identity.Endereco
                    {
                        Nome = "Ady Lobo Sotto Maior",
                        Número = "175",
                        TipoLogradouro = "Rua",
                        Cep = "82990-211",
                        Bairro = "Cajuru",
                        Cidade = "Curitiba",
                        Estado = "Paraná"
                    }
                };

                await userManager.CreateAsync(usuario, "Pa$$w0rd");
            }
        }
    }
}
