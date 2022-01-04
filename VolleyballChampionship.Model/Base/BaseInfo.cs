using Dapper.Contrib.Extensions;
using System;

namespace VolleyballChampionship.Model.Base
{
    public class BaseInfo
    {
        [ExplicitKey]
        public int Id { get; set; }
        public int? CreateUser { get; set; }
        public int? UpdateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}