using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommanderGQL.Data;
using CommanderGQL.Domain;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        public IQueryable<Platform> GetPlatform([Service] AppDbContext context)
        {
            return context.Platforms;
        }
    }
}