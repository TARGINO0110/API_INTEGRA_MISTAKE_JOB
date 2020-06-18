using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_INTEGRA.Models;

namespace WebAPI_INTEGRA.Services.SevicesServicos
{
    public interface IServicosRepository
    {
        IEnumerable<Servicos> GetAll();
        Servicos GetById(int id);
        void AddServicos(Servicos servicos);
        void UpdateServicos(Servicos servicos);
        void DeleteServicos(int id);
    }
}
