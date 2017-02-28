using AutoMapper;
using Mcet.Ucas.Event.Service.Query.Handlers.InMemory.Entities;
using Mcet.Ucas.Event.Service.Query.Interfaces;
using Mcet.Ucas.Event.Service.Query.Model.ReadModels;

namespace Mcet.Ucas.Event.Service.Query.Handlers.InMemory.AutoMapper
{
    public class AutoMapperConfiguration : IAutoMapperConfiguration
    {
        public void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<EventEntity, EventSummaryModel>();

                cfg.CreateMap<EventEntity, EventDetailsModel>()
                    .IncludeBase<EventEntity, EventSummaryModel>();
            });
        }
    }
}
