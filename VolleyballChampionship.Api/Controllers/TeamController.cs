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
    [Route(_version + "/Team")]
    public class TeamController : BasePublicController<TeamUoW>
    {
        #region Properties

        const string _controllerName = "Times";

        #endregion

        #region Constructor

        public TeamController(TeamUoW uow, IMapper mapper) : base(mapper, uow)
        {
        }

        #endregion

        #region Methods

        /// <summary>Pesquisa de Campeonatos</summary>
        /// <remarks>Retorna todos os campeonatos</remarks>
        /// <returns>Lista de campeonatos</returns>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(List<TeamResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            List<TeamInfo> list = await _uow._team.GetAllAsync();

            return Ok(_mapper.Map<List<TeamResponse>>(list));
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(List<ChampionshipResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<dynamic>> Insert([FromBody] TeamRequest entity)
        {
            var inserted = await _uow._team.InsertAsync(_mapper.Map<TeamInfo>(entity));

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
        public async Task<ActionResult<dynamic>> Update([FromBody] TeamRequest entity)
        {
            var updated = await _uow._team.UpdateAsync(_mapper.Map<TeamInfo>(entity));

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
        public async Task<ActionResult<dynamic>> Delete([FromBody] TeamRequest entity)
        {

            var deleted = await _uow._team.DeleteAsync(_mapper.Map<TeamInfo>(entity));

            if (deleted)
                return Ok(new { message = "Campeonato removido com sucesso." });

            return BadRequest(new { message = "Erro ao remover campeonato." });

        }

        #endregion
    }
}
