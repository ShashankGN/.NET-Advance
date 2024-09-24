using BooksAPI.Data;
using BooksAPI.Models;
using Mapster;
using MediatR;
using System.Runtime.CompilerServices;

namespace BooksAPI.Features.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public double Price { get; set; }
    }
    //public class CreateBookResponse
    //{
    //    public int Id { get; set; }
    //}

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly BookContext _context;

        public CreateBookCommandHandler(BookContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var product=request.Adapt<Book>();
            product.Id = _context.Books.Count() + 1;
            await _context.Books.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;

        }
    }
}
