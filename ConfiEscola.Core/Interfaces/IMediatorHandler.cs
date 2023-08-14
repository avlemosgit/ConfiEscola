using ConfiEscola.Core.Commands;
using ConfiEscola.Core.Events;
using System.Threading.Tasks;

namespace ConfiEscola.Core.Interfaces
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
