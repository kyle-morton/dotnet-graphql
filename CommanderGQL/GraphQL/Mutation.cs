using CommanderGQL.Data;
using CommanderGQL.Domain;
using CommanderGQL.GraphQL.Commands;
using CommanderGQL.GraphQL.Platforms;
using HotChocolate.Subscriptions;

namespace CommanderGQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(
            AddPlatformInput input, 
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender, 
            CancellationToken cancellationToken
        ) 
        {
            var platform = new Platform 
            {
                Name = input.name,
                LicenseKey = ""
            };

            context.Platforms.Add(platform);
            await context.SaveChangesAsync();

            // send out to subscribers
            await eventSender.SendAsync(nameof(Subscription.OnPlatformCreate), platform, cancellationToken);

            return new AddPlatformPayload(platform);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommandAsync(
            AddCommandInput input, 
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender, 
            CancellationToken cancellationToken
        ) 
        {
            var command = new Command {
                HowTo = input.howTo,
                CommandLine = input.commandLine,
                PlatformId = input.platformId
            };

            context.Commands.Add(command);
            await context.SaveChangesAsync(cancellationToken);

            return new AddCommandPayload(command);
        }
    }
}