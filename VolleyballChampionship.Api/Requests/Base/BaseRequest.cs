using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolleyballChampionship.Api.Requests.Base
{
    public class BaseRequest
    {
        public int Id { get; set; }
        public int? CreatorUser { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
