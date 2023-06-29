using MediatR;

namespace Univali.Api.Features.Authors.Commands.DeleteAuthor;

public class DeleteAuthorCommand : IRequest<DeleteAuthorDto>
{
    public int Id { get; set; }
}