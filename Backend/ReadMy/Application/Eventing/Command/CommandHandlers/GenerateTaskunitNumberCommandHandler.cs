using Application.Eventing.Command.Commands;

using Infrastructure;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Eventing.Command.CommandHandlers
{
    public class GenerateTaskunitNumberCommandHandler : IRequestHandler<GenerateTaskunitNumberCommand, string>
    {
        private readonly ReadMyDbContext context;

        public GenerateTaskunitNumberCommandHandler(ReadMyDbContext context)
        {
            this.context = context;
        }
        public async Task<string> Handle(GenerateTaskunitNumberCommand request, CancellationToken cancellationToken)
        {
            var number = Guid.NewGuid()
                .ToString()
                .Substring(25);

            while (await context.Taskunits.AnyAsync(x => x.SerialNumber == number, cancellationToken))
            {
                number = Guid.NewGuid()
                    .ToString()
                    .Substring(25);
            }

            return number!;
        }
    }
}
