using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITokenService
    {
        string CriarToken(AppUser usuario);
    }
}
