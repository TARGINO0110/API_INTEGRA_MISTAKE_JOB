﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_INTEGRA.Models;
using WebAPI_INTEGRA.Services.SevicesServicos;

namespace WebAPI_INTEGRA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        private readonly IServicosRepository _servicosRepository;

        public ServicosController(IServicosRepository servicosRepository)
        {
            _servicosRepository = servicosRepository;
        }

        [HttpGet]
        public IEnumerable<Servicos> Get()
        {
            return _servicosRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Servicos Get(int id)
        {
            return _servicosRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Servicos servicos)
        {
            if (ModelState.IsValid)
                _servicosRepository.AddServicos(servicos);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Servicos servicos)
        {
            servicos.ServicosId = id;
            if (ModelState.IsValid)
                _servicosRepository.UpdateServicos(servicos);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _servicosRepository.DeleteServicos(id);
        }
    }
}