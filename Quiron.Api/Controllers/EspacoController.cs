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
    public class EspacoController : ControllerBase
    {
        private readonly IEspacoService _espacoService;

        public EspacoController(IEspacoService espacoService)
            => _espacoService = espacoService;

        /// <summary>
        /// Consulta de espaços.
        /// </summary>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Não foi possível realizar a consulta.</response>
        [HttpGet]
        [EnableQuery()]
        [ProducesResponseType(typeof(IQueryable<EspacoDto>), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Get()
            => Ok(_espacoService.GetAll());

        /// <summary>
        /// Consulta de espaços por id.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Consulta realizada com sucesso.</response>        
        /// <response code="400">Não foi possível realizar a consulta.</response>
        /// <response code="404">Espaço não localizado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EspacoDto), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Get(Guid id)
        {
            EspacoDto espaco = _espacoService.FindById(id);
            if (espaco == null)
            {
                return NotFound();
            }

            return Ok(espaco);
        }

        /// <summary>
        /// Criar espaço.
        /// </summary>
        /// <param name="espaco"></param>
        /// <response code="200">Espaço criado com sucesso.</response>
        /// <response code="400">Não foi possível criar o espaço.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Post(EspacoDto espaco)
        {
            if (!ModelState.IsValid)
            {
                new QuironException("Os dados para criação do espaço são inválidos.");
            }

            _espacoService.Create(espaco);
            return Ok();
        }

        /// <summary>
        /// Atualizar espaço.
        /// </summary>
        /// <param name="espaco"></param>
        /// <response code="200">Espaço atualizado com sucesso.</response>
        /// <response code="400">Não foi possível atualizar o espaço.</response>
        /// <response code="404">Espaço não localizado.</response>
        [HttpPut]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Put(EspacoDto espaco)
        {
            if (!ModelState.IsValid)
            {
                new QuironException("Os dados para atualização do espaço são inválidos.");
            }

            if ((espaco.Id == null) || (_espacoService.FindById(espaco.Id) == null))
            {
                return NotFound();
            }

            _espacoService.Update(espaco);
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
        [ProducesResponseType(typeof(EspacoDto), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Delete(Guid id)
        {
            EspacoDto espaco = _espacoService.FindById(id);
            if (espaco == null)
            {
                return NotFound();
            }

            _espacoService.Remove(espaco);
            return Ok();
        }
    }
}