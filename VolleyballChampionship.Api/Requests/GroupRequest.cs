using Dapper.Contrib.Extensions;
using VolleyballChampionship.Api.Requests.Base;

namespace VolleyballChampionship.Api.Requests
{
    public class GroupRequest : BaseRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [Write(false)]
        public int ChampionshipId { get; set; }
    }
}
