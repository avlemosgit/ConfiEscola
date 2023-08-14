using ConfiEscola.Core.Events;

namespace ConfiEscola.Core.Interfaces
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
