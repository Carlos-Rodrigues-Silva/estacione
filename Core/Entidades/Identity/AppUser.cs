using Core.Entidades.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entidades
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }

        public Identity.Endereco Endereco { get; set; }
    }
}
