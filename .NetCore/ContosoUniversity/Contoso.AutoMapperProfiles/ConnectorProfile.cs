using AutoMapper;
using Contoso.Angular.Settings;
using LogicBuilder.Forms.Parameters;

namespace Contoso.AutoMapperProfiles
{
    public class ConnectorProfile : Profile
    {
        public ConnectorProfile()
        {
            CreateMap<CommandButton, ConnectorParameters>()
                .ConstructUsing((src, context) => new ConnectorParameters
                {
                    ConnectorData = context.Mapper.Map<CommandButtonData>(src)
                })
                .ForMember(dest => dest.ConnectorData, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.ButtonIcon, opts => opts.MapFrom(src => ((CommandButtonData)src.ConnectorData).ButtonIcon))
                .ForMember(dest => dest.Cancel, opts => opts.MapFrom(src => ((CommandButtonData)src.ConnectorData).Cancel))
                .ForMember(dest => dest.ClassString, opts => opts.MapFrom(src => ((CommandButtonData)src.ConnectorData).ClassString))
                .ForMember(dest => dest.GridCommandButton, opts => opts.MapFrom(src => ((CommandButtonData)src.ConnectorData).GridCommandButton))
                .ForMember(dest => dest.GridId, opts => opts.MapFrom(src => ((CommandButtonData)src.ConnectorData).GridId));
            CreateMap<CommandButtonData, CommandButton>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ShortString, opt => opt.Ignore())
                .ForMember(dest => dest.LongString, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
