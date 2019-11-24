using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.AutoMapperProfiles
{
    public class FilterGroupProfile : Profile
    {
        public FilterGroupProfile()
        {
            CreateMap<Angular.Settings.FilterGroup, LogicBuilder.Expressions.Utils.DataSource.FilterGroup>().ReverseMap();
            CreateMap<Angular.Settings.FilterDefinition, LogicBuilder.Expressions.Utils.DataSource.Filter>()
                    .ForMember(dest => dest.Filters, opt => opt.Ignore())
                    .ForMember(dest => dest.Logic, opt => opt.Ignore())
                    .ForMember(dest => dest.ValueSourceType, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
