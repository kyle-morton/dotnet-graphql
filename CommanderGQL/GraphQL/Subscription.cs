using CommanderGQL.Domain;

namespace CommanderGQL.GraphQL
{
    public class Subscription
    {

        [Subscribe]
        [Topic]
        public Platform OnPlatformCreate([EventMessage] Platform platform) => platform;
    }
}