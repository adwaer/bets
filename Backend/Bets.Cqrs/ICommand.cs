using System.Threading.Tasks;

namespace Bets.Cqrs
{
    public interface ICommand
    {
        Task Execute(object par);
    }
    public interface ICommand<in T>
    {
        Task Execute(T par);
    }
}
