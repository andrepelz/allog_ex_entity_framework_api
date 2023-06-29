using AutoMapper;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, CreateAuthorDto>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public CreateAuthorCommandHandler(IPublisherRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public  async Task<CreateAuthorDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var newAuthor = _mapper.Map<Author>(request.Dto);

        _repository.AddAuthor(newAuthor);
        await _repository.SaveChangesAsync();

        var authorToReturn = _mapper.Map<CreateAuthorDto>(newAuthor);
        
        return authorToReturn;
    }
}