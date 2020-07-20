using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
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
        public async Task<ActionResult<IEnumerable<Empresa>>> Get()
        {
            try
            {
                var lista = await _empresaRepository.GetAll();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> Get(int id)
        {
            try
            {
                var listaId = await _empresaRepository.GetById(id);
                return Ok(listaId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Empresa empresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _empresaRepository.AddEmpresa(empresa);
                    return Ok(empresa);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Empresa empresa)
        {
            try
            {
                empresa.EmpresaId = id;
                if (ModelState.IsValid)
                {
                    _empresaRepository.UpdateEmpresa(empresa);
                    return Ok(empresa);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid && id > 0)
                {
                    _empresaRepository.DeleteEmpresa(id);
                    return Ok(id);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}