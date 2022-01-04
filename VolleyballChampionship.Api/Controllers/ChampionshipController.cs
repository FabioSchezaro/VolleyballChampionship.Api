using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolleyballChampionship.Api.Controllers.BaseControllers;
using VolleyballChampionship.Api.Requests;
using VolleyballChampionship.Api.Responses;
using VolleyballChampionship.Api.UnitsOfWork;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Api.Controllers
{
    [Route(_version + "/Championship")]
    public class ChampionshipController : BasePublicController<ChampionshipUoW>
    {
        #region Properties

        const string _controllerName = "Campeonatos";

        #endregion

        #region Constructor

        public ChampionshipController(ChampionshipUoW uow, IMapper mapper) : base(mapper, uow)
        {
        }

        #endregion

        #region Methods

        /// <summary>Pesquisa de campeonatos</summary>
        /// <remarks>Retorna todos os campeonatos</remarks>
        /// <returns>Lista de campeonatos</returns>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(List<ChampionshipResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            List<ChampionshipInfo> list = await _uow._championship.GetAllAsync();

            return Ok(_mapper.Map<List<ChampionshipResponse>>(list));
        }

        /// <summary>Pesquisa de campeonatos por ID</summary>
        /// <remarks>Retorna um dos campeonatos</remarks>
        /// <returns>Campeonato</returns>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpGet("GetByParameters")]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(ChampionshipResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync([FromQuery] ChampionshipRequest entity)
        {
            List<ChampionshipResponse> info = new List<ChampionshipResponse>();

            if (entity.Id != 0)
                info.Add(_mapper.Map<ChampionshipResponse>(await _uow._championship.GetByIdAsync(entity.Id)));
            else
                info.AddRange(_mapper.Map<List<ChampionshipResponse>>(await _uow._championship.GetByParametersAsync(_mapper.Map<ChampionshipInfo>(entity))));

            if (info.Count > 0)
                return Ok(info);

            return NotFound("Nenhum registro encontrado");
        }

        /// <summary>Insere o campeonato</summary>
        /// <remarks>Mensagem de sucesso ou erro</remarks>
        /// <returns>Retorna mensagem de sucesso ou erro</returns>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpPost]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(List<ChampionshipResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<dynamic>> Insert([FromBody] ChampionshipRequest entity)
        {
            var inserted = await _uow._championship.InsertAsync(_mapper.Map<ChampionshipInfo>(entity));

            if (inserted)
                return Ok(new { message = "Campeonato inserido com sucesso." });

            return BadRequest(new { message = "Erro ao salvar campeonato." });
        }

        /// <summary>Atualiza o campeonato</summary>
        /// <remarks>Mensagem de sucesso ou erro</remarks>
        /// <returns>Retorna mensagem de sucesso ou erro</returns>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpPut]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(List<ChampionshipResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<dynamic>> Update([FromBody] ChampionshipRequest entity)
        {
            var updated = await _uow._championship.UpdateAsync(_mapper.Map<ChampionshipInfo>(entity));

            if (updated)
                return Ok(new { message = "Campeonato atualizado com sucesso." });

            return BadRequest(new { message = "Erro ao atualizar campeonato." });
        }

        /// <summary>Deleta os campeonatos</summary>
        /// <remarks>Mensagem de sucesso ou erro</remarks>
        /// <returns>Retorna mensagem de sucesso ou erro</returns>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpDelete]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(List<ChampionshipResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<dynamic>> Delete([FromBody] ChampionshipRequest entity)
        {

            var deleted = await _uow._championship.DeleteAsync(_mapper.Map<ChampionshipInfo>(entity));

            if (deleted)
                return Ok(new { message = "Campeonato removido com sucesso." });

            return BadRequest(new { message = "Erro ao remover campeonato." });

        }

        #endregion
    }
}
