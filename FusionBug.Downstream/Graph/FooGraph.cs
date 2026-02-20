using FluentValidation.Results;
using FusionBug.Downstream.Models;

namespace FusionBug.Downstream.Graph;

public class Utilities
{
    public static IError ConvertResultError(string message, List<ValidationFailure> failures)
    {
        return ErrorBuilder.New()
            .SetMessage(message ?? "An error occurred")
            .SetExtension("validationFailures",
                failures
                    .Select(x => new Dictionary<string, object?>
                    {
                        { "errorCode", x.ErrorCode },
                        { "errorMessage", x.ErrorMessage },
                        { "propertyName", x.PropertyName },
                        { "attemptedValue", x.AttemptedValue },
                        { "severity", x.Severity }
                    })
                    .ToList())
            .Build();
    }

}

public class FooGraph
{
    public async Task<IEnumerable<Foo>> GetFoo(string? barInput)
    {
        throw new GraphQLException(
            Utilities.ConvertResultError("validation failure", new List<ValidationFailure>())
        );
    }
}