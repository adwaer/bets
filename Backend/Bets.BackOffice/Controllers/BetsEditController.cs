using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Bets.BackOffice.Controllers
{
    [Authorize]
    public class BetsEditController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            return Ok();
        }
    }
}