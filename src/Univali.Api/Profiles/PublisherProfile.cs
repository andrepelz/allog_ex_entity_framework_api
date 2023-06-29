using AutoMapper;
using Univali.Api.Entities;
using Univali.Api.Features.Publishers.CreatePublisher;
using Univali.Api.Features.Publishers.Queries.GetPublisherDetail;
using Univali.Api.Features.Publishers.Queries.GetPublisherWithCoursesDetail;
using Univali.Api.Models;

namespace Univali.Api.Profiles;

public class PublisherProfile : Profile
{
    public PublisherProfile ()
    {
        CreateMap<Publisher, PublisherDto>();

        CreateMap<PublisherForCreationDto, Publisher>();
        CreateMap<PublisherForUpdateDto, Publisher>();
        CreateMap<PublisherDto, Publisher>();


        // CQRS
        CreateMap<Publisher, GetPublisherDetailDto>();
        CreateMap<Publisher, GetPublisherWithCoursesDetailDto>();
        CreateMap<Publisher, CreatePublisherDto>();
    }
}