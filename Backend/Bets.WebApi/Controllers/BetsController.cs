using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using Bets.Cqrs.Command;
using Bets.Cqrs.Criteria;
using Bets.Cqrs.Query;
using Bets.WebApi.ViewModel;

namespace Bets.WebApi.Controllers
{
    public class BetsController : ApiController
    {
        private readonly BetsQuery _betsQuery;
        private readonly SaveCommand _saveCommand;

        public BetsController(BetsQuery betsQuery, SaveCommand saveCommand)
        {
            _betsQuery = betsQuery;
            _saveCommand = saveCommand;
        }

        [AllowAnonymous]
        public async Task<IHttpActionResult> Get()
        {
            BetCondition model = null;
            if (model == null)
            {
                model = new BetCondition
                {
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date.AddDays(2).AddSeconds(-1),
                    Count = 17
                };
            }

            try
            {
                var bets = await _betsQuery
                    .Execute(model)
                    .ToArrayAsync();
                return Ok(bets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        public async Task<IHttpActionResult> Post(BetAddModel model)
        {
            var bet = model.ConvertToBet();
            bet.MakeDate = DateTime.UtcNow;

            await _saveCommand.Execute(bet);

            return Ok();
        }
    }
}
