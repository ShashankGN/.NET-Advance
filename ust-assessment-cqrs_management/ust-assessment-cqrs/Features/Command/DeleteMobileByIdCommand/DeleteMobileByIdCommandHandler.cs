using MediatR;
using Microsoft.EntityFrameworkCore;
using ust_assessment_cqrs.Data;

namespace ust_assessment_cqrs.Features.Command.DeleteMobileByIdCommand
{
    public class DeleterMobileByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
    public class DeleteMobileByIdCommandHandler : IRequestHandler<DeleterMobileByIdCommand, bool>
    {
        private readonly MobileContext _context;
        public DeleteMobileByIdCommandHandler(MobileContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleterMobileByIdCommand request, CancellationToken cancellationToken)
        {
            var mobile=await _context.Mobiles.FirstOrDefaultAsync(x=>x.Id==request.Id);
            if (mobile != null)
            {
                _context.Mobiles.Remove(mobile);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
