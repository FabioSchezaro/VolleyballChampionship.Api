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
    [Route(_version + "/Player")]
    public class PlayerController : BasePublicController<PlayerUoW>
    {
        #region Properties

        const string _controllerName = "Jogadores";

        #endregion

        #region Constructor

        public PlayerController(PlayerUoW uow, IMapper mapper) : base(mapper, uow)
        {
        }

        #endregion

        #region Methods

        /// <summary>Pesquisa de jogadores</summary>
        /// <remarks>Retorna todos os jogadores</remarks>
        /// <returns>Lista de jogadores</returns>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(List<PlayerResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            List<PlayerInfo> list = await _uow._player.GetAllAsync();

            return Ok(_mapper.Map<List<PlayerResponse>>(list));
        }

        /// <summary>Pesquisa de jogadores por ID</summary>
        /// <remarks>Retorna um dos jogadores</remarks>
        /// <returns>Campeonato</returns>
        /// <response code="400">Bad Request</response> 
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpGet("GetByParameters")]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(PlayerResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync([FromQuery] PlayerRequest entity)
        {
            List<PlayerResponse> info = new List<PlayerResponse>();

            if (entity.Id != 0)
                info.Add(_mapper.Map<PlayerResponse>(await _uow._player.GetByIdAsync(entity.Id)));
            else
                info.AddRange(_mapper.Map<List<PlayerResponse>>(await _uow._player.GetByParametersAsync(_mapper.Map<PlayerInfo>(entity))));

            if (info.Count > 0)
                return Ok(info);

            return NotFound("Nenhum registro encontrado");
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(List<ChampionshipResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<dynamic>> Insert([FromBody] PlayerRequest entity)
        {
            var inserted = await _uow._player.InsertAsync(_mapper.Map<PlayerInfo>(entity));

            if (inserted)
                return Ok(new { message = "Jogador inserido com sucesso." });

            return BadRequest(new { message = "Erro ao salvar jogador." });
        }

        /// <summary>Atualiza o jogador</summary>
        /// <remarks>Mensagem de sucesso ou erro</remarks>
        /// <returns>Retorna mensagem de sucesso ou erro</returns>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpPut]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(List<ChampionshipResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<dynamic>> Update([FromBody] PlayerRequest entity)
        {
            var updated = await _uow._player.UpdateAsync(_mapper.Map<PlayerInfo>(entity));

            if (updated)
                return Ok(new { message = "Jogador atualizado com sucesso." });

            return BadRequest(new { message = "Erro ao atualizar jogador." });
        }

        /// <summary>Deleta os jogadores</summary>
        /// <remarks>Mensagem de sucesso ou erro</remarks>
        /// <returns>Retorna mensagem de sucesso ou erro</returns>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpDelete]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(List<ChampionshipResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<dynamic>> Delete([FromBody] PlayerRequest entity)
        {

            var deleted = await _uow._player.DeleteAsync(_mapper.Map<PlayerInfo>(entity));

            if (deleted)
                return Ok(new { message = "Jogador removido com sucesso." });

            return BadRequest(new { message = "Erro ao remover jogador." });

        }

        #endregion
    }
}
