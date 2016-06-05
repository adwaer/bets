using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Adwaer.Entity;

namespace Bets.Cqrs.Command
{
    public class SaveCommand : ICommand
    {
        private readonly DbContext _dbContext;

        public SaveCommand(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Execute(object par)
        {
            _dbContext
                .Set(par.GetType())
                .Add(par);

            await _dbContext.SaveChangesAsync();
        }
    }
}
