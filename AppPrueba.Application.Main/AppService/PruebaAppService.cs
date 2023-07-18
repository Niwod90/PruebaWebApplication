using System.Collections;
using AppPrueba.Application.Main.Contracts;
using AppPrueba.Application.Main.Models;
using AppPrueba.Data.Main;
using AppPrueba.Data.Main.Contracts;
using AppPrueba.Data.Main.Entities;

namespace AppPrueba.Application.Main
{
    public class PruebaAppService : IPruebaAppService
    {
        private readonly IPruebaRepository _repository;

        public PruebaAppService(IPruebaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<PruebaModel> GetPrueba()
        {
            var pruebaModel = new PruebaModel();

            var data = _repository.GetUsers();

            return data.Select(x => new PruebaModel { Id = x.UserID, Name = x.UserName });
        }
    }
}
