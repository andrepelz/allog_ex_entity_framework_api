using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Authors.Commands.DeleteAuthor;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, DeleteAuthorDto>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public DeleteAuthorCommandHandler(IPublisherRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<DeleteAuthorDto> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        bool success = false;

        var authorFromDatabase = await _repository.GetAuthorByIdAsync(request.Id);

        if(authorFromDatabase != null) {
            _repository.RemoveAuthor(authorFromDatabase);
            await _repository.SaveChangesAsync();

            success = true;
        }

        return new DeleteAuthorDto { Success = success };
    }
}