using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Authors.Commands.UpdateAuthor;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, UpdateAuthorDto>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public UpdateAuthorCommandHandler(IPublisherRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<UpdateAuthorDto> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        bool success = false;

        var authorFromDatabase = await _repository.GetAuthorByIdAsync(request.Dto.AuthorId);

        if(authorFromDatabase != null) {
            _repository.UpdateAuthor(authorFromDatabase, request.Dto);
            await _repository.SaveChangesAsync();

            success = true;
        }

        return new UpdateAuthorDto { Success = success };
    }
}