using Mcet.Ucas.Event.Service.Query.Handlers.InMemory.Entities;
using System.Collections.Generic;

namespace Mcet.Ucas.Event.Service.Query.Handlers.InMemory.Interfaces
{
    public interface IDataStore
    {
        IEnumerable<EventEntity> GetEvents();
    }
}
