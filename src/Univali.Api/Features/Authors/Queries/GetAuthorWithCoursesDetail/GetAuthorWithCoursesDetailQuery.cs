using MediatR;

namespace Univali.Api.Features.Authors.Queries.GetAuthorWithCoursesDetail;

public class GetAuthorWithCoursesDetailQuery : IRequest<GetAuthorWithCoursesDetailDto>
{
    public int Id { get; set; }
}