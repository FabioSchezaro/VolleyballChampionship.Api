using System;

namespace VolleyballChampionship.Api.Responses.Base
{
    public class BaseResponse
    {
        public int Id { get; set; }
        public int? CreatorUser { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
