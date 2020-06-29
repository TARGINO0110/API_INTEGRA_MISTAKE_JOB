using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_INTEGRA.Models;

namespace WebAPI_INTEGRA.Services.ServicesFuncionario
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> GetAll();
        Task<Funcionario> GetById(int id);
        void AddFuncionario(Funcionario funcionario);
        void UpdateFuncionario(Funcionario funcionario);
        void DeleteFuncionario(int id);
    }
}
