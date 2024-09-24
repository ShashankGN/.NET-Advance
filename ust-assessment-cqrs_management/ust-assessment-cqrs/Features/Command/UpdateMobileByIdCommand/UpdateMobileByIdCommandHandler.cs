using MediatR;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using ust_assessment_cqrs.Data;

namespace ust_assessment_cqrs.Features.Command.UpdateMobileByIdCommand
{
    public class UpdateMobileByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }

        public string Features { get; set; }

        public double Price { get; set; }
    }
    public class UpdateMobileByIdCommandHandler : IRequestHandler<UpdateMobileByIdCommand, bool>
    {
        private readonly MobileContext _context;
        public UpdateMobileByIdCommandHandler(MobileContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateMobileByIdCommand request, CancellationToken cancellationToken)
        {
            var mobile=await _context.Mobiles.FirstOrDefaultAsync(x=>x.Id == request.Id);
            if (mobile != null)
            {
                mobile.Name = request.Name;
                mobile.Manufacturer = request.Manufacturer;
                mobile.Features = request.Features;
                mobile.Price = request.Price;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
