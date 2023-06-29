using AutoMapper;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Models;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Courses.Commands.CreateCourse;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCourseCommand, CreateCourseDto> {
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(IPublisherRepository repository, IMapper mapper) 
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }



    public async Task<CreateCourseDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken) 
    {
        List<int> authorIds = request.Dto.Authors
            .Select(a => a.AuthorId)
            .ToList();

        if(! await _repository.AuthorsExistAsync(authorIds)) return null!;

        CreateCourseDto courseToReturn = null!;
        var publisherFromDatabase = await _repository.GetPublisherByIdAsync(request.PublisherId);

        if(publisherFromDatabase != null) {
            var courseWithoutAuthorsDto = _mapper.Map<CourseForCreationDto>(request.Dto);
            var newCourse = _mapper.Map<Course>(courseWithoutAuthorsDto);
            newCourse.Authors = await _repository.GetAuthorsAsync(authorIds);

            _repository.AddCourse(publisherFromDatabase, newCourse);
            await _repository.SaveChangesAsync();

            courseToReturn = _mapper.Map<CreateCourseDto>(newCourse);
        }
        
        return courseToReturn;
    }
}