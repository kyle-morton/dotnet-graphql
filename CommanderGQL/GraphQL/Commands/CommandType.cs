using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommanderGQL.Data;
using CommanderGQL.Domain;

namespace CommanderGQL.GraphQL
{
    public class CommandType : ObjectType<Command> 
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable command for a given software platform.");

            descriptor
                .Field(c => c.Platform)
                .ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Represents the platform that this executable is designed for.");
        }

        private class Resolvers 
        {
            public Platform GetPlatform([Parent] Command command, [ScopedService] AppDbContext context) 
            {
                return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
            }
        }
    }
}