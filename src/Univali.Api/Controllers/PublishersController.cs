using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Univali.Api.Features.Publishers.CreatePublisher;
using Univali.Api.Features.Publishers.UpdatePublisher;
using Univali.Api.Features.Publishers.Commands.DeletePublisher;
using Univali.Api.Features.Publishers.Queries.GetPublisherDetail;
using Univali.Api.Features.Publishers.Queries.GetPublisherWithCoursesDetail;
using Univali.Api.Models;

namespace Univali.Api.Controllers;

[Route("api/publishers")]
[Authorize]
public class PublishersController : MainController
{
    private readonly IMediator _mediator;

    public PublishersController(IMediator mediator) {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("{publisherId}", Name = "GetPublisherById")]
    public async Task<ActionResult <GetPublisherDetailDto>> GetPublisherById(int publisherId) {
        var getPublisherQuery = new GetPublisherDetailQuery { PublisherId = publisherId };
        var publisherToReturn = await _mediator.Send(getPublisherQuery);

        return publisherToReturn != null ? Ok(publisherToReturn) : NotFound();
    }

    [HttpGet("with-courses/{publisherId}")]
    public async Task<ActionResult <GetPublisherWithCoursesDetailDto>> GetPublisherWithCoursesById(int publisherId) {
        var getPublisherWithCoursesQuery = new GetPublisherWithCoursesDetailQuery { PublisherId = publisherId };
        var publisherToReturn = await _mediator.Send(getPublisherWithCoursesQuery);

        return publisherToReturn != null ? Ok(publisherToReturn) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult <PublisherDto>> CreatePublisher (PublisherForCreationDto publisherForCreationDto) {
        var createPublisherCommand = new CreatePublisherCommand { Dto = publisherForCreationDto };
        var publisherToReturn = await _mediator.Send(createPublisherCommand);

        return CreatedAtRoute(
            "GetPublisherById",
            new { publisherId = publisherToReturn.PublisherId },
            publisherToReturn
        );   
    }

    [HttpPut("{publisherId}")]
    public async Task<ActionResult> UpdatePublisher (int publisherId, PublisherForUpdateDto publisherForUpdateDto) {
        if(publisherForUpdateDto.PublisherId != publisherId) return BadRequest();

        var updatePublisherCommand = new UpdatePublisherCommand { Dto = publisherForUpdateDto };
        var result = await _mediator.Send(updatePublisherCommand);

        return result.Success ? NoContent() : NotFound();
    }

    [HttpDelete("{publisherId}")]
    public async Task<ActionResult> DeletePublisher(int publisherId) {
        var deletePublisherCommand = new DeletePublisherCommand {PublisherId = publisherId};
        var result = await _mediator.Send(deletePublisherCommand);

        return result.Success ? NoContent() : NotFound();
    }
}