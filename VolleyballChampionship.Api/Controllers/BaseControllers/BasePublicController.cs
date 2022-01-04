using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VolleyballChampionship.Api.UnitsOfWork.Base;

namespace VolleyballChampionship.Api.Controllers.BaseControllers
{
    [ApiController]
    public class BasePublicController<TUoW> : BaseApiController where TUoW : BaseUoW
    {
        protected readonly IMapper _mapper;
        protected readonly TUoW _uow;
        protected const string _version = "api/v1";

        public BasePublicController(TUoW uow) : base(uow)
        {
            _uow = uow;
        }

        public BasePublicController(IMapper mapper, TUoW uow) : base(uow)
        {
            _uow = uow;
            _mapper = mapper;
        }
    }
}