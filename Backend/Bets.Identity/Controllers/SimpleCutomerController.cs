using System.Threading.Tasks;
using System.Web.Http;
using Bets.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Bets.Identity.Controllers
{
    public class SimpleCutomerController : ApiController
    {
        private readonly SignInManager<SimpleCutomerAccount, int> _signInManager;

        public SimpleCutomerController(IUserStore<SimpleCutomerAccount, int> signInManager)
        {
            //_signInManager = signInManager;
        }

        public async Task<IHttpActionResult> Get(string login, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(login, password, true, shouldLockout: false);
            if (result == SignInStatus.Success)
            {
                return Ok();
            }
            return BadRequest(result.ToString());
        }
    }
}
