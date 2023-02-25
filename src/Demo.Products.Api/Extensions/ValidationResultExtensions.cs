namespace Demo.Products.Api.Extensions
{
    using System.Net;
    using FluentValidation.Results;
    using Microsoft.AspNetCore.Mvc;

    public static class ValidationResultExtensions
    {
        public static ProblemDetails ToProblemDetails(this IEnumerable<ValidationFailure> validationFailures)
        {
            var errors = validationFailures.ToDictionary(x => x.PropertyName, x => x.ErrorMessage);

            var problemDetails = new ProblemDetails
            {
                Type = "ValidationError",
                Detail = "invalid request, please check the error list for more details",
                Status = (int)HttpStatusCode.BadRequest,
                Title = "invalid request",
            };

            problemDetails.Extensions.Add("errors", errors);
            return problemDetails;
        }
    }
}
