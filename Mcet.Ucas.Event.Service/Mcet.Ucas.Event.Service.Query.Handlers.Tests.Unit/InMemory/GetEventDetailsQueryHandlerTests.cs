using AutoMapper;
using Mcet.Ucas.Event.Service.Query.Handlers.InMemory;
using Mcet.Ucas.Event.Service.Query.Handlers.InMemory.AutoMapper;
using Mcet.Ucas.Event.Service.Query.Handlers.InMemory.Entities;
using Mcet.Ucas.Event.Service.Query.Handlers.InMemory.Interfaces;
using Mcet.Ucas.Event.Service.Query.Handlers.Tests.Unit.InMemory;
using Mcet.Ucas.Event.Service.Query.Model.Queries;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mcet.Ucas.Event.Service.Query.Handlers.Tests.Unit
{
    [TestFixture]
    [Category("Unit")]
    public class GetEventDetailsQueryHandlerTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Further work would abstract AutoMapper and remove the need for this in a unit test.
            (new AutoMapperConfiguration()).Configure();
            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void Handle_EventIdNotFound_ReturnsNull()
        {
            var entities = TestData.CreateEntities(3);
            var mockDataStore = new Mock<IDataStore>();
            mockDataStore.Setup(m => m.GetEvents()).Returns(entities);

            var handler = new GetEventDetailsQueryHandler(mockDataStore.Object);
            var response = handler.Handle(new GetEventDetailsQuery { EventId = Guid.NewGuid() });

            Assert.That(response, Is.Null);
        }

        [Test]
        public void Handle_EventIdFound_ReturnsMatchingEvent()
        {
            var entities = TestData.CreateEntities(3);
            var mockDataStore = new Mock<IDataStore>();
            mockDataStore.Setup(m => m.GetEvents()).Returns(entities);
            var match = entities.Last();

            var handler = new GetEventDetailsQueryHandler(mockDataStore.Object);
            var response = handler.Handle(new GetEventDetailsQuery { EventId = match.Id });

            Assert.That(response.Id, Is.EqualTo(match.Id));
            Assert.That(response.Description, Is.EqualTo(match.Description));
            Assert.That(response.Location, Is.EqualTo(match.Location));
            Assert.That(response.Organiser, Is.EqualTo(match.Organiser));
            Assert.That(response.Title, Is.EqualTo(match.Title));
            Assert.That((int)response.Category, Is.EqualTo(match.Category));
            Assert.That(response.StartDate, Is.EqualTo(match.StartDate));
        }
    }
}
