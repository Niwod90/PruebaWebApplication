using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPrueba.DomainService.Main.Contracts;

namespace AppPrueba.DomainService.Main.DomainService
{
    public class PruebaDomainService : IPruebaDomainService
    {
        public PruebaDomainService() { }

        public string Cadena()
        {
            return "Cadena";
        }
    }
}
