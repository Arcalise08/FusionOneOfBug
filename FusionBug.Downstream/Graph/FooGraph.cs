using FusionBug.Downstream.Models;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Mvc;

namespace FusionBug.Downstream.Graph;

public class SomeError
{
    public string Test { get; set; }
}

public class FooGraph
{
    public async Task<IEnumerable<Foo>> GetFoo(FooBarInput barInput)
    {
        throw new GraphQLException(
            ErrorBuilder.New()
                .SetMessage("Something went wrong")
                .SetExtension("bar", new List<SomeError>
                {
                    new()
                    {
                        Test = "test"
                    }
                })
                .Build()
        );
    }
}