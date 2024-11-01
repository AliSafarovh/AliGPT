using DataAccessLayer.Concrete;
using MediatR;
using TraversalProject.CQRS.Queries.GuideQueries;
using TraversalProject.CQRS.Results.GuideResults;

namespace TraversalProject.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIDQuery, GetGuideByIdQueryResult>
    {
        private readonly Context _context;
        public GetGuideByIDQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<GetGuideByIdQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.Id);
            return new GetGuideByIdQueryResult
            {
                GuideId = values.GuidId,
                Description = values.Description,
                Name = values.Name
            };
           
        }
    }
}
