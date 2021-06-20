using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_INTEGRA.Models;

namespace WebAPI_INTEGRA.Services.ServicesEmpresa
{
    public interface IEmpresaRepository
    {
        Task<IEnumerable<Estabelecimento>> GetAll();
        Task<Estabelecimento> GetById(int id);
        void AddEmpresa(Estabelecimento empresa);
        void UpdateEmpresa(Estabelecimento empresa);
        void DeleteEmpresa(int id);
    }
}
