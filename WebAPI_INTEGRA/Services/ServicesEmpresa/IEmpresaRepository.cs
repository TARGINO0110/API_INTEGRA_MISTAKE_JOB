using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_INTEGRA.Models;

namespace WebAPI_INTEGRA.Services.ServicesEmpresa
{
    public interface IEmpresaRepository
    {
        IEnumerable<Empresa> GetAll();
        Empresa GetById(int id);
        void AddEmpresa(Empresa pessoas);
        void UpdateEmpresa(Empresa pessoas);
        void DeleteEmpresa(int id);
    }
}
