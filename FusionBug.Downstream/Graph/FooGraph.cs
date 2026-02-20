using FluentValidation.Results;
using FusionBug.Downstream.Models;

namespace FusionBug.Downstream.Graph;

public class Utilities
{
    public static IError ConvertResultError(string message, List<string> failures)
    {
        return ErrorBuilder.New()
            .SetMessage(message ?? "An error occurred")
            .SetExtension("validationFailures", failures)
            .Build();
    }

}

public class FooGraph
{
    public async Task<IEnumerable<Foo>> GetFoo(string? barInput)
    {
        throw new GraphQLException(
            Utilities.ConvertResultError("validation failure", [])
        );
    }
}