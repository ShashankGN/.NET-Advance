using MediatR;
using Microsoft.EntityFrameworkCore;
using ust_assessment_cqrs.Data;
using ust_assessment_cqrs.Models;

namespace ust_assessment_cqrs.Features.Query.GetMobileByIdQuery
{
    public class GetMobileByIdQuery : IRequest<Mobile>
    {
        public int Id { get; set; }
    }
    public class GetMobileByIdQueryHandler : IRequestHandler<GetMobileByIdQuery, Mobile>
    {
        private readonly MobileContext _context;
        public GetMobileByIdQueryHandler(MobileContext context)
        {
            _context = context;
        }
        public async Task<Mobile> Handle(GetMobileByIdQuery request, CancellationToken cancellationToken)
        {
            var result=await _context.Mobiles.FirstOrDefaultAsync(x=>x.Id==request.Id);
            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}
