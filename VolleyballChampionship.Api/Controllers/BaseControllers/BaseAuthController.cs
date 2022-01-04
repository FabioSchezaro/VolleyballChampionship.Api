using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VolleyballChampionship.Api.Controllers.BaseControllers
{
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class BaseAuthController : ControllerBase
    {
    }
}
