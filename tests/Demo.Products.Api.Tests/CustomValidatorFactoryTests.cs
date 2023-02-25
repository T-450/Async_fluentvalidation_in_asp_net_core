namespace Demo.Products.Api.Tests
{
    using Core.Filters;
    using FluentAssertions;
    using FluentValidation;
    using Microsoft.Extensions.DependencyInjection;

    public class CustomValidatorFactoryTests
    {
        [Fact]
        public void TransientValidators()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IValidator<SampleProduct>, SampleProductValidator>()
                .BuildServiceProvider();

            var factory = new CustomValidatorFactory(serviceProvider);
            factory.GetValidatorFor(typeof(SampleProduct)).Should().NotBeNull();
        }

        [Fact]
        public void ScopedValidators()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IValidator<SampleProduct>, SampleProductValidator>()
                .BuildServiceProvider();

            var factory = new CustomValidatorFactory(serviceProvider);
            factory.GetValidatorFor(typeof(SampleProduct)).Should().NotBeNull();
        }

        [Fact]
        public void SingletonValidators()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IValidator<SampleProduct>, SampleProductValidator>()
                .BuildServiceProvider();

            var factory = new CustomValidatorFactory(serviceProvider);
            factory.GetValidatorFor(typeof(SampleProduct)).Should().NotBeNull();
        }
    }
}
