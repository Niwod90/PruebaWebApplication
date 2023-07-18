using System;
using AppPrueba.Data.Main.Entities;

namespace AppPrueba.Data.Main.Contracts
{
    public interface IPruebaRepository
    {
        IEnumerable<UsersEntity> GetUsers();
    }
}
