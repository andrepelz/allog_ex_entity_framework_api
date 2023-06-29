using MediatR;

namespace Univali.Api.Features.Publishers.Commands.DeletePublisher;

public class DeletePublisherCommand : IRequest<DeletePublisherDto>
{
    public int PublisherId {get;set;}
}