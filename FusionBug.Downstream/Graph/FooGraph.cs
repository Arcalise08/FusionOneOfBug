using FusionBug.Downstream.Models;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Mvc;

namespace FusionBug.Downstream.Graph;

public class FooGraph
{
    public async Task<IEnumerable<Foo>> GetFoo(FooBarInput barInput)
    {
        throw new NotImplementedException();
    }
}