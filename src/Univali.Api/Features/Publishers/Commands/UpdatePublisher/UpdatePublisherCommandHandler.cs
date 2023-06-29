using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Publishers.UpdatePublisher;

public class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommand, UpdatePublisherDto>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public UpdatePublisherCommandHandler(IPublisherRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<UpdatePublisherDto> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
    {
        bool success = false;

        var publisherFromDatabase = await _repository.GetPublisherByIdAsync(request.Dto.PublisherId);

        if(publisherFromDatabase != null) {
            _repository.UpdatePublisher(publisherFromDatabase, request.Dto);
            await _repository.SaveChangesAsync();

            success = true;
        }

        return new UpdatePublisherDto { Success = success };
    }
}