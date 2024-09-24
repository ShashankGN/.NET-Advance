using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using ust_assessment_cqrs.Data;
using ust_assessment_cqrs.Models;

namespace ust_assessment_cqrs.Features.Query.GetAllMobileQuery
{
    public class GetAllMobileQuery:IRequest<IEnumerable<Mobile>>
    {

    }
    public class GetAllMobileQueryHandler : IRequestHandler<GetAllMobileQuery, IEnumerable<Mobile>>
    {
        private readonly MobileContext _context;
        public GetAllMobileQueryHandler(MobileContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Mobile>> Handle(GetAllMobileQuery request, CancellationToken cancellationToken)
        {
            var mobiles = await _context.Mobiles.ToListAsync();
            return mobiles;
        }
    }
}
