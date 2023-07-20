using AppPrueba.Application.Main.Models;
using System;

namespace AppPrueba.Application.Main.Contracts
{
    public interface IPruebaAppService
    {
        PruebaModel GetFirstUsers();

        IEnumerable<PruebaModel> GetPrueba();

        Task<IEnumerable<PruebaModel>> GetPruebaAsync();
    }
}
