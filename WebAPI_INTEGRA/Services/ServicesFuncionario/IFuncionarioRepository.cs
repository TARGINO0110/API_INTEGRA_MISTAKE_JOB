using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_INTEGRA.Models;

namespace WebAPI_INTEGRA.Services.ServicesFuncionario
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Profissional>> GetAll();
        Task<Profissional> GetById(int id);
        void AddFuncionario(Profissional funcionario);
        void UpdateFuncionario(Profissional funcionario);
        void DeleteFuncionario(int id);
    }
}
