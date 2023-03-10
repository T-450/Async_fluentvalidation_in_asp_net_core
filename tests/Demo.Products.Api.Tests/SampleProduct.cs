namespace Demo.Products.Api.Tests
{
    using Core;
    using FluentValidation;

    public record class SampleProduct(string Id, string Name);

    public class SampleProductValidator : ModelValidatorBase<SampleProduct>
    {
        public SampleProductValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("id is not null");
            RuleFor(x => x.Name).MustAsync(async (s, t) =>
            {
                await Task.Delay(TimeSpan.FromSeconds(1), t);
                return !string.IsNullOrWhiteSpace(s);
            });
        }
    }
}
