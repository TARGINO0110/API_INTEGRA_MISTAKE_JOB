using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_INTEGRA.Models;
using WebAPI_INTEGRA.Services.SevicesServicos;

namespace WebAPI_INTEGRA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServicosController : ControllerBase
    {
        private readonly IServicosRepository _servicosRepository;

        public ServicosController(IServicosRepository servicosRepository)
        {
            _servicosRepository = servicosRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicos>>> Get()
        {
            try
            {
                var lista = await _servicosRepository.GetAll();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servicos>> Get(int id)
        {
            try
            {
                var listaId = await _servicosRepository.GetById(id);
                return Ok(listaId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Servicos servicos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _servicosRepository.AddServicos(servicos);
                    return Ok(servicos);
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
        public IActionResult Put(int id, [FromBody] Servicos servicos)
        {
            try
            {
                servicos.ServicosId = id;
                if (ModelState.IsValid)
                {
                    _servicosRepository.UpdateServicos(servicos);
                    return Ok(servicos);
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
                    _servicosRepository.DeleteServicos(id);
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