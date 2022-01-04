using Microsoft.AspNetCore.Mvc;
using VolleyballChampionship.Api.UnitsOfWork.Base;

namespace VolleyballChampionship.Api.Controllers.BaseControllers
{
    public abstract class BaseApiController : Controller
    {
        private BaseUoW _uow;

        public BaseApiController(BaseUoW uow)
        {
            _uow = uow;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing == true)
            {
                _uow?.Dispose();
            }
        }
    }
}
