using AppPrueba.Application.Main.Models;
using System;

namespace AppPrueba.Application.Main.Contracts
{
    public interface IPruebaAppService
    {
        IEnumerable<PruebaModel> GetPrueba();
    }
}
