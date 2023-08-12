﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaApiWeb.Entidades;

using SistemaApiWeb.Entidades;
using SistemaApiWeb.DAO;

namespace SistemaApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioApiController : ControllerBase
    {
        //Listar Paises
        [HttpGet("GetPaises")]
        public async Task<ActionResult<List<Pais>>> GetPais() 
        {
            var lista = await Task.Run(() => (new PaisDAO()).GetPaises());
            return Ok(lista);  //okObjectResult rpta
        }


        // CLiente CRUD
        [HttpGet("GetClientes")]
        public async Task<ActionResult<List<Cliente>>> GetCliente()
        {
            var lista = await Task.Run(() => (new ClienteDAO()).GetClientes());
            return Ok(lista);
        }

        [HttpPost("AddCliente")]
        public async Task<ActionResult<String>> InsertarCliente(Cliente cliente)
        {
            var mensaje = await Task.Run(() => (new ClienteDAO()).Agregar(cliente));
            return Ok(mensaje);
        }

        [HttpPut("UpdateCliente")]
        public async Task<ActionResult<String>> ActualizarCliente(Cliente cliente)
        {
            var mensaje = await Task.Run(() => (new ClienteDAO()).Actualizar(cliente));
            return Ok(mensaje);
        }


    }
}







