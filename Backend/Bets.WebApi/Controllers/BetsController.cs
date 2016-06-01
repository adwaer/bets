﻿using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using Bets.Cqrs.Query;

namespace Bets.WebApi.Controllers
{
    [AllowAnonymous]
    public class BetsController : ApiController
    {
        private readonly BetsQuery _betsQuery;

        public BetsController(BetsQuery betsQuery)
        {
            _betsQuery = betsQuery;
        }

        public async Task<IHttpActionResult> Get()
        {
            var date = DateTime.UtcNow.Date;

            try
            {
                var bets = await _betsQuery
                    .Execute(date, date.AddDays(2).AddSeconds(-1))
                    .ToArrayAsync();
                return Ok(bets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}
