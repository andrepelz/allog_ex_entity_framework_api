using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univali.Api.Features.Authors.Commands.CreateAuthor;
using Univali.Api.Features.Authors.Commands.UpdateAuthor;
using Univali.Api.Features.Authors.Commands.DeleteAuthor;
using Univali.Api.Features.Authors.Queries.GetAuthorDetail;
using Univali.Api.Features.Authors.Queries.GetAuthorWithCoursesDetail;
using Microsoft.AspNetCore.Authorization;
using Univali.Api.Models;

namespace Univali.Api.Controllers;

[Route("api/authors")]
[Authorize]
public class AuthorsController : MainController
{
    private readonly IMediator _mediator;

    public AuthorsController(IMediator mediator) {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("{authorId}", Name = "GetAuthorById")]
    public async Task<ActionResult <GetAuthorDetailDto>> GetAuthorById(int authorId) {
        var getAuthorQuery = new GetAuthorDetailQuery {Id = authorId};
        var authorToReturn = await _mediator.Send(getAuthorQuery);

        return authorToReturn != null ? Ok(authorToReturn) : NotFound();
    }

    [HttpGet("with-courses/{authorId}")]
    public async Task<ActionResult <GetAuthorWithCoursesDetailDto>> GetAuthorWithCourses(int authorId) {
        var getAuthorWithCoursesQuery = new GetAuthorWithCoursesDetailQuery {Id = authorId};
        var authorToReturn = await _mediator.Send(getAuthorWithCoursesQuery);

        return authorToReturn != null ? Ok(authorToReturn) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult <CreateAuthorDto>> CreateAuthor(AuthorForCreationDto authorForCreationDto) {
        var createAuthorCommand = new CreateAuthorCommand { Dto = authorForCreationDto };
        var authorToReturn = await _mediator.Send(createAuthorCommand);

        return CreatedAtRoute(
            "GetAuthorById",
            new { authorId = authorToReturn.AuthorId },
            authorToReturn
        );
    }

    [HttpPut("{authorId}")]

    public async Task<ActionResult> UpdateAuthor(int authorId, AuthorForUpdateDto authorForUpdateDto) {
        if(authorForUpdateDto.AuthorId != authorId) return BadRequest();

        var updateAuthorCommand = new UpdateAuthorCommand { Dto = authorForUpdateDto };
        var result = await _mediator.Send(updateAuthorCommand);

        return result.Success ? NoContent() : NotFound();
    }

    [HttpDelete("{authorId}")]
    public async Task<ActionResult> DeleteAuthor(int authorId) {
        var deleteAuthorCommand = new DeleteAuthorCommand { Id = authorId };
        var result = await _mediator.Send(deleteAuthorCommand);

        return result.Success ? NoContent() : NotFound();
    }
}