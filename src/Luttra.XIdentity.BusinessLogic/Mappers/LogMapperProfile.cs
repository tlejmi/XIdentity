using AutoMapper;
using Luttra.XIdentity.BusinessLogic.Dtos.Log;
using Luttra.XIdentity.EntityFramework.Entities;
using Luttra.XIdentity.EntityFramework.Extensions.Common;
using Skoruba.AuditLogging.EntityFramework.Entities;

namespace Luttra.XIdentity.BusinessLogic.Mappers
{
    public class LogMapperProfile : Profile
    {
        public LogMapperProfile()
        {
            CreateMap<Log, LogDto>(MemberList.Destination)
                .ReverseMap();
            
            CreateMap<PagedList<Log>, LogsDto>(MemberList.Destination)
                .ForMember(x => x.Logs, opt => opt.MapFrom(src => src.Data));

            CreateMap<AuditLog, AuditLogDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<AuditLog>, AuditLogsDto>(MemberList.Destination)
                .ForMember(x => x.Logs, opt => opt.MapFrom(src => src.Data));
        }
    }
}
