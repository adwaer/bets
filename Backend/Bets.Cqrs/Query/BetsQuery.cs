using System;
using System.Data.Entity;
using System.Linq;
using Autofac.Extras.NLog;
using Bets.Domain;

namespace Bets.Cqrs.Query
{
    public class BetsQuery : IQuery<DateTime, DateTime, IQueryable<Bet>>
    {
        private readonly DbContext _dbContext;
        private readonly ILogger _logger;

        public BetsQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
            //_logger = logger;
        }

        public IQueryable<Bet> Execute(DateTime startDate, DateTime endDate)
        {
            try
            {
                return _dbContext
                    .Set<Bet>()
                    .Where(bet => bet.ShowDate >= startDate && bet.ShowDate <= endDate);
            }
            catch (Exception ex)
            {
                //_logger.Error(ex);
                throw;
            }
        }
    }
}
