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
    [Route(_version + "/Group")]
    public class GroupController : BasePublicController<GroupUoW>
    {
        #region Properties

        const string _controllerName = "Grupos";

        #endregion

        #region Constructor

        public GroupController(GroupUoW uow, IMapper mapper) : base(mapper, uow)
        {
        }

        #endregion

        #region Methods

        /// <summary>Pesquisa de grupos</summary>
        /// <remarks>Retorna todos os grupos</remarks>
        /// <returns>Lista de grupos</returns>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(List<GroupResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            List<GroupInfo> list = await _uow._group.GetAllAsync();

            return Ok(_mapper.Map<List<GroupResponse>>(list));
        }

        /// <summary>Pesquisa de gupos por ID</summary>
        /// <remarks>Retorna um dos grupos</remarks>
        /// <returns>Campeonato</returns>
        /// <response code="400">Bad Request</response> 
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpGet("GetByParameters")]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(GroupResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GroupRequest entity)
        {
            List<GroupResponse> info = new List<GroupResponse>();

            if (entity.Id != 0)
                info.Add(_mapper.Map<GroupResponse>(await _uow._group.GetByIdAsync(entity.Id)));
            else
                info.AddRange(_mapper.Map<List<GroupResponse>>(await _uow._group.GetByParametersAsync(_mapper.Map<GroupInfo>(entity))));

            if (info.Count > 0)
                return Ok(info);

            return NotFound("Nenhum registro encontrado");
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(List<GroupResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<dynamic>> Insert([FromBody] GroupRequest entity)
        {
            var inserted = await _uow._group.InsertAsync(_mapper.Map<GroupInfo>(entity));

            if (inserted)
                return Ok(new { message = "Grupo inserido com sucesso." });

            return BadRequest(new { message = "Erro ao salvar grupo." });
        }

        /// <summary>Atualiza o grupo</summary>
        /// <remarks>Mensagem de sucesso ou erro</remarks>
        /// <returns>Retorna mensagem de sucesso ou erro</returns>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpPut]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(List<GroupResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<dynamic>> Update([FromBody] GroupRequest entity)
        {
            var updated = await _uow._group.UpdateAsync(_mapper.Map<GroupInfo>(entity));

            if (updated)
                return Ok(new { message = "Grupo atualizado com sucesso." });

            return BadRequest(new { message = "Erro ao atualizar grupo." });
        }

        /// <summary>Deleta os grupos</summary>
        /// <remarks>Mensagem de sucesso ou erro</remarks>
        /// <returns>Retorna mensagem de sucesso ou erro</returns>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="200">Ok</response>
        [HttpDelete]
        [SwaggerOperation(Tags = new[] { _controllerName })]
        [ProducesResponseType(typeof(List<GroupResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<dynamic>> Delete([FromBody] GroupRequest entity)
        {

            var deleted = await _uow._group.DeleteAsync(_mapper.Map<GroupInfo>(entity));

            if (deleted)
                return Ok(new { message = "Grupo removido com sucesso." });

            return BadRequest(new { message = "Erro ao remover grupo." });

        }


        #endregion
    }
}
