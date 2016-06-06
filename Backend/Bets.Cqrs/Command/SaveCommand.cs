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
            var type = par.GetType();
            var ipProp = type.GetProperty("Id");
            if (!ipProp.PropertyType.IsValueType)
            {
                throw new NotImplementedException();
            }
            if (ipProp.GetValue(par) == Activator.CreateInstance(ipProp.PropertyType))
            {
                _dbContext.Entry(par).State = EntityState.Added;
            }
            else
            {
                _dbContext.Entry(par).State = EntityState.Modified;
            }
            
            await _dbContext.SaveChangesAsync();
        }
    }
}
