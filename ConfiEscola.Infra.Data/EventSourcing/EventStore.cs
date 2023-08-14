using System.Text.Json;
using ConfiEscola.Core.Events;
using ConfiEscola.Core.Interfaces;

namespace ConfiEscola.Infra.Data.EventSourcing
{
    public class EventStore : IEventStore
    {
        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonSerializer.Serialize(theEvent);
            var storedEvent = new StoredEvent(theEvent, serializedData, "_user.Name");
        }
    }
}
