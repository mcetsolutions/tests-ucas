using Mcet.Ucas.Event.Service.Query.Handlers.InMemory.Entities;
using System;
using System.Collections.Generic;

namespace Mcet.Ucas.Event.Service.Query.Handlers.Tests.Unit.InMemory
{
    internal static class TestData
    {
        private const string Title = "Skiing for Dummies";
        private const string Location = "Milton Keynes Snow Dome";
        private const int Category = 1;
        private const string Description = "Group skiing lesson for complete beginners";
        private const string Organiser = "Snow Dome";

        public static EventEntity CreateEntity(DateTimeOffset? startDate = null, string title = Title, string location = Location, int category = Category, string description = Description, string organiser = Organiser)
        {
            return new EventEntity
            {
                Id = Guid.NewGuid(),
                Title = title,
                Location = location,
                StartDate = startDate ?? DateTimeOffset.UtcNow,
                Category = category,
                Description = description,
                Organiser = organiser
            };
        }

        public static IEnumerable<EventEntity> CreateEntities(int number, DateTimeOffset? baseStartDate = null, string baseTitle = Title, string baseLocation = Location, int baseCategory = Category, string baseDescription = Description, string baseOrganiser = Organiser)
        {
            var events = new List<EventEntity>(number);
            var referenceDate = baseStartDate ?? DateTimeOffset.UtcNow;

            for (int i = 0; i < number; i++)
            {
                var category = (baseCategory + i) % 6;
                var entity = CreateEntity(referenceDate.AddDays(i), $"{baseTitle} {i}", $"{baseLocation} {i}", category,
                    $"{baseDescription} {i}", $"{baseOrganiser} {i}");
                events.Add(entity);
            }

            return events;
        }
    }
}
