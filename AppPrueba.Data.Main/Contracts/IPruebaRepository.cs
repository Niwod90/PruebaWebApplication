using System;
using AppPrueba.Data.Main.Entities;

namespace AppPrueba.Data.Main.Contracts
{
    public interface IPruebaRepository
    {
        UsersEntity GetFirstUsers();

        IEnumerable<UsersEntity> GetUsers();

        Task<IEnumerable<UsersEntity>> GetUsersAll();
    }
}
