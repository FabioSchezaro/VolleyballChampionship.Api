using VolleyballChampionship.Model.Enums;

namespace VolleyballChampionship.Api.Requests
{
    public class ChampionshipRequest
    {
        /// <summary>
        /// Id do campeonato
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descrição do campeonato
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Status do campeonato (1 - Em progresso | 2 - Finalizado | 3 - Cancelado)
        /// </summary>
        public ChampionshipStatusEnum Status { get; set; }
    }
}
