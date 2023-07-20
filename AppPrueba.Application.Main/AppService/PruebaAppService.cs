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

        public PruebaModel GetFirstUsers()
        {
            var pruebaModel = new PruebaModel();

            var data = _repository.GetFirstUsers();

            return new PruebaModel { Id = data.UserID, Name = data.UserName };
        }

        public IEnumerable<PruebaModel> GetPrueba()
        {
            var data = _repository.GetUsers();

            return data.Select(x => new PruebaModel { Id = x.UserID, Name = x.UserName });
        }

        public async Task<IEnumerable<PruebaModel>> GetPruebaAsync()
        {
            var res = await this._repository.GetUsersAll();

            return res.Select(x => new PruebaModel {  Id = x.UserID, Name = x.UserName });
        }
    }
}
