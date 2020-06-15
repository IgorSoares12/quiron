using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Quiron.Domain.Dto;
using Quiron.Domain.Exception;
using Quiron.Domain.Interfaces.Services;
using System;
using System.Linq;

namespace Quiron.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _estadoService;

        public EstadoController(IEstadoService estadoService)
            => _estadoService = estadoService;

        /// <summary>
        /// Consulta de espaços.
        /// </summary>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        [HttpGet]
        [EnableQuery()]
        [ProducesResponseType(typeof(IQueryable<EstadoDto>), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Get()
            => Ok(_estadoService.GetAll());

        /// <summary>
        /// Consulta de espaços por id.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Consulta realizada com sucesso.</response>        
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Espaço não localizado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EstadoDto), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Get(Guid id)
        {
            EstadoDto estado = _estadoService.FindById(id);
            if (estado == null)
            {
                return NotFound();
            }

            return Ok(estado);
        }

        /// <summary>
        /// Criar espaço.
        /// </summary>
        /// <param name="estado"></param>
        /// <response code="200">Espaço criado com sucesso.</response>
        /// <response code="400">Não foi possível criar o espaço.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Post(EstadoDto estado)
        {
            if (!ModelState.IsValid)
            {
                new QuironException("Os dados para criação do espaço são inválidos.");
            }

            _estadoService.Create(estado);
            return Ok();
        }

        /// <summary>
        /// Atualizar espaço.
        /// </summary>
        /// <param name="estado"></param>
        /// <response code="200">Espaço atualizado com sucesso.</response>
        /// <response code="400">Não foi possível atualizar o espaço.</response>
        /// <response code="404">Espaço não localizado.</response>
        [HttpPut]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Put(EstadoDto estado)
        {
            if (!ModelState.IsValid)
            {
                new QuironException("Os dados para atualização do espaço são inválidos.");
            }

            if ((estado.Id == null) || (_estadoService.FindById(estado.Id) == null))
            {
                return NotFound();
            }

            _estadoService.Update(estado);
            return Ok();
        }

        /// <summary>
        /// Excluir espaço.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Exclusão realizada com sucesso.</response>        
        /// <response code="400">Não foi possível realizar a exclusão.</response>
        /// <response code="404">Espaço não localizado.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EstadoDto), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Delete(Guid id)
        {
            EstadoDto estado = _estadoService.FindById(id);
            if (estado == null)
            {
                return NotFound();
            }

            _estadoService.Remove(estado);
            return Ok();
        }
    }
}