using System;
using System.Data.Entity;
using System.Linq;
using Autofac.Extras.NLog;
using Bets.Cqrs.Criteria;
using Bets.Domain;

namespace Bets.Cqrs.Query
{
    public class BetsQuery : IQuery<BetCondition, IQueryable<Bet>>
    {
        private readonly DbContext _dbContext;
        private readonly ILogger _logger;

        public BetsQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
            //_logger = logger;
        }

        public IQueryable<Bet> Execute(BetCondition condition)
        {
            try
            {
                return _dbContext
                    .Set<Bet>()
                    .Where(bet => bet.ShowDate >= condition.StartDate && bet.ShowDate <= condition.EndDate)
                    .OrderByDescending(b => b.ShowDate);
            }
            catch (Exception ex)
            {
                //_logger.Error(ex);
                throw;
            }
        }
    }
}
