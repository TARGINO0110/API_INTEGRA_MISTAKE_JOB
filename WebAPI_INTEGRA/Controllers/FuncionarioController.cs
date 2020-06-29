using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_INTEGRA.Models;
using WebAPI_INTEGRA.Services.ServicesFuncionario;

namespace WebAPI_INTEGRA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Funcionario>> Get()
        {
            return await _funcionarioRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Funcionario> Get(int id)
        {
            return await _funcionarioRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Funcionario funcionario)
        {
            if (ModelState.IsValid)
                _funcionarioRepository.AddFuncionario(funcionario);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Funcionario funcionario)
        {
            funcionario.FuncionarioId = id;
            if (ModelState.IsValid)
                _funcionarioRepository.UpdateFuncionario(funcionario);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _funcionarioRepository.DeleteFuncionario(id);
        }
    }
}