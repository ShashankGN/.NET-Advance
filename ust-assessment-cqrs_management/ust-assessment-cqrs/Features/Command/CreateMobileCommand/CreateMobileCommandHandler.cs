using Mapster;
using MediatR;
using Microsoft.Extensions.Configuration.Ini;
using ust_assessment_cqrs.Data;
using ust_assessment_cqrs.Models;

namespace ust_assessment_cqrs.Features.Command.CreateMobileCommand
{
    public class CreateMobileCommand:IRequest<int>
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }

        public string Features { get; set; }

        public double Price { get; set; }
    }
    public class CreateMobileCommandHandler : IRequestHandler<CreateMobileCommand, int>
    {
        private readonly MobileContext _context;
        public CreateMobileCommandHandler(MobileContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateMobileCommand request, CancellationToken cancellationToken)
        {
            var incoming = request.Adapt<Mobile>();
            //if (_context.Mobiles.Count() == 0)
            //{
            //    incoming.Id = _context.Mobiles.Count() + 1;
            //}
            //else
            //{
            //    incoming.Id = _context.Mobiles.Max(x => x.Id) + 1;
            //}
            incoming.Id=_context.Mobiles.Count()==0? _context.Mobiles.Count() + 1: _context.Mobiles.Max(x => x.Id) + 1;
            await _context.Mobiles.AddAsync(incoming);
            await _context.SaveChangesAsync();
            return incoming.Id;
        }
    }
}
