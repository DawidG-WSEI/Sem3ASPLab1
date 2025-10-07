using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Artists.Queries;
using CleanArchitecture.Application.Songs.Queries;
using CleanArchitecture.Application.Listeners.Queries;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Application.Common.Mappings;

public class DomainMappingProfile : Profile
{
    public DomainMappingProfile()
    {
        CreateMap<Artist, ArtistDto>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username.Value))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
            .ForMember(dest => dest.PayoutTier, opt => opt.MapFrom(src => src.PayoutTier.Name));

        CreateMap<Song, SongDto>();

        CreateMap<Listener, ListenerDto>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username.Value))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value));

        CreateMap<Username, string>().ConvertUsing(u => u.Value);
        CreateMap<EmailAddress, string>().ConvertUsing(e => e.Value);
        CreateMap<PayoutTier, string>().ConvertUsing(p => p.Name);
    }
}