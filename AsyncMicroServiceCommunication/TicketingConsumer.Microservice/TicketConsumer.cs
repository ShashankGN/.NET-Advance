using MassTransit;
using Shared;
using System.Text.Json;

namespace TicketingConsumer.Microservice
{
    public class TicketConsumer : IConsumer<Ticket>
    {
        public async Task Consume(ConsumeContext<Ticket> context)
        {
            var data = context.Message;
            Console.WriteLine(JsonSerializer.Serialize(data));
        }
    }
}
