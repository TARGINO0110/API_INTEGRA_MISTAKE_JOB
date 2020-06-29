using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_INTEGRA.Models;
using WebAPI_INTEGRA.Services.ServicesEmpresa;

namespace WebAPI_INTEGRA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaController(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Empresa>> Get()
        {
            return await _empresaRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Empresa> Get(int id)
        {
            return await _empresaRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Empresa empresa)
        {
            if (ModelState.IsValid)
                _empresaRepository.AddEmpresa(empresa);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Empresa empresa)
        {
            empresa.EmpresaId = id;
            if (ModelState.IsValid)
                _empresaRepository.UpdateEmpresa(empresa);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _empresaRepository.DeleteEmpresa(id);
        }
    }
}