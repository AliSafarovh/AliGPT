using MediatR;
using TraversalProject.CQRS.Results.GuideResults;

namespace TraversalProject.CQRS.Queries.GuideQueries
{
    public class GetGuideByIDQuery:IRequest<GetGuideByIdQueryResult>
    {
        public int Id { get; set; }
        public GetGuideByIDQuery(int id)
        {
            Id = id;
        }
    }
}
