using AutoMapper;
using Mcet.Ucas.Event.Service.Query.Handlers.InMemory;
using Mcet.Ucas.Event.Service.Query.Handlers.InMemory.AutoMapper;
using Mcet.Ucas.Event.Service.Query.Handlers.InMemory.Entities;
using Mcet.Ucas.Event.Service.Query.Handlers.InMemory.Interfaces;
using Mcet.Ucas.Event.Service.Query.Model.Queries;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Mcet.Ucas.Event.Service.Query.Handlers.Tests.Unit.InMemory
{
    [TestFixture]
    [Category("Unit")]
    public class GetEventsQueryHandlerTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Further work would abstract AutoMapper and remove the need for this in a unit test.
            (new AutoMapperConfiguration()).Configure();
            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void Handle_OrderByTitleAsc_ReturnsInCorrectOrder()
        {
            var entities = new List<EventEntity>
            {
                TestData.CreateEntity(title: "ZZZZ"),
                TestData.CreateEntity(title: "MMM"),
                TestData.CreateEntity(title: "AAA")
            };
            var mockDataStore = new Mock<IDataStore>();
            mockDataStore.Setup(m => m.GetEvents()).Returns(entities);

            var handler = new GetEventsQueryHandler(mockDataStore.Object);
            var response = handler.Handle(new GetEventsQuery { OrderBy = "Title", Ascending = true });

            Assert.That(response.Items.First().Id, Is.EqualTo(entities.Last().Id));
            Assert.That(response.Items.Last().Id, Is.EqualTo(entities.First().Id));
        }

        [Test]
        public void Handle_FirstPageRequested_ReturnsCorrectEventsPage()
        {
            var entities = TestData.CreateEntities(6).OrderByDescending(e => e.StartDate);
            var mockDataStore = new Mock<IDataStore>();
            mockDataStore.Setup(m => m.GetEvents()).Returns(entities);

            var handler = new GetEventsQueryHandler(mockDataStore.Object);
            var response = handler.Handle(new GetEventsQuery { PageNumber = 1, PageSize = 5, OrderBy = "StartDate", Ascending = true });

            Assert.That(response.PageNumber, Is.EqualTo(1));
            Assert.That(response.Items.Count(), Is.EqualTo(5));
            var entitiesReversed = entities.Reverse();
            Assert.That(response.Items.First().Id, Is.EqualTo(entitiesReversed.First().Id));
            Assert.That(response.Items.Last().Id, Is.EqualTo(entitiesReversed.Skip(4).First().Id));
        }

        [Test]
        public void Handle_MiddlePageRequested_ReturnsCorrectEventsPage()
        {
            var entities = TestData.CreateEntities(11).OrderByDescending(e => e.StartDate);
            var mockDataStore = new Mock<IDataStore>();
            mockDataStore.Setup(m => m.GetEvents()).Returns(entities);

            var handler = new GetEventsQueryHandler(mockDataStore.Object);
            var response = handler.Handle(new GetEventsQuery { PageNumber = 2, PageSize = 5, OrderBy = "StartDate", Ascending = true });

            Assert.That(response.PageNumber, Is.EqualTo(2));
            Assert.That(response.Items.Count(), Is.EqualTo(5));
            var entitiesReversed = entities.Reverse();
            Assert.That(response.Items.First().Id, Is.EqualTo(entitiesReversed.Skip(5).First().Id));
            Assert.That(response.Items.Last().Id, Is.EqualTo(entitiesReversed.Skip(9).First().Id));
        }

        [Test]
        public void Handle_LastPageRequestedWithNoOverSpill_ReturnsCorrectTotalPages()
        {
            var entities = TestData.CreateEntities(10).OrderByDescending(e => e.StartDate);
            var mockDataStore = new Mock<IDataStore>();
            mockDataStore.Setup(m => m.GetEvents()).Returns(entities);

            var handler = new GetEventsQueryHandler(mockDataStore.Object);
            var response = handler.Handle(new GetEventsQuery { PageSize = 2 });

            Assert.That(response.TotalPages, Is.EqualTo(5));
            Assert.That(response.Items.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Handle_LastPageRequestedWithOverSpill_ReturnsCorrectTotalPages()
        {
            var entities = TestData.CreateEntities(13).OrderByDescending(e => e.StartDate);
            var mockDataStore = new Mock<IDataStore>();
            mockDataStore.Setup(m => m.GetEvents()).Returns(entities);

            var handler = new GetEventsQueryHandler(mockDataStore.Object);
            var response = handler.Handle(new GetEventsQuery { PageSize = 5 });

            Assert.That(response.TotalPages, Is.EqualTo(3));
            Assert.That(response.Items.Count(), Is.EqualTo(5));
        }

        [Test]
        public void Handle_PageSizeRequested_ReturnsCorrectEventsPage()
        {
            var entities = TestData.CreateEntities(10);
            var mockDataStore = new Mock<IDataStore>();
            mockDataStore.Setup(m => m.GetEvents()).Returns(entities);

            var handler = new GetEventsQueryHandler(mockDataStore.Object);
            var response = handler.Handle(new GetEventsQuery { PageSize = 5 });

            Assert.That(response.PageSize, Is.EqualTo(5));
            Assert.That(response.Items.Count(), Is.EqualTo(5));
        }

        [Test]
        public void Handle_DefaultRequest_TotalResultsCorrect()
        {
            var entities = TestData.CreateEntities(4);
            var mockDataStore = new Mock<IDataStore>();
            mockDataStore.Setup(m => m.GetEvents()).Returns(entities);

            var handler = new GetEventsQueryHandler(mockDataStore.Object);
            var response = handler.Handle(new GetEventsQuery());

            Assert.That(response.TotalResults, Is.EqualTo(4));
        }
    }
}
