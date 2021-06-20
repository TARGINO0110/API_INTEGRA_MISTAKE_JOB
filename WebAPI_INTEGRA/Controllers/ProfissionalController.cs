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
    public class ProfissionalController : ControllerBase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public ProfissionalController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profissional>>> Get()
        {
            try
            {
                var lista = await _funcionarioRepository.GetAll();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profissional>> Get(int id)
        {
            try
            {
                var listaId = await _funcionarioRepository.GetById(id);
                return Ok(listaId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Profissional funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _funcionarioRepository.AddFuncionario(funcionario);
                    return Ok(funcionario);
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
        public IActionResult Put(int id, [FromBody] Profissional funcionario)
        {
            try
            {
                funcionario.FuncionarioId = id;
                if (ModelState.IsValid)
                {
                    _funcionarioRepository.UpdateFuncionario(funcionario);
                    return Ok(funcionario);
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
                    _funcionarioRepository.DeleteFuncionario(id);
                    return Ok(id);
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
    }
}