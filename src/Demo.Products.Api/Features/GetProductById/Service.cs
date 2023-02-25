namespace Demo.Products.Api.Features.GetProductById
{
    using Infrastructure.DataAccess;

    public interface IProductSearchByIdService
    {
        Task<ProductDataModel> GetAsync(Request request);
    }

    public class ProductSearchByIdService : IProductSearchByIdService
    {
        public async Task<ProductDataModel> GetAsync(Request request)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            // returning a mocked product
            return new ProductDataModel(
                request.CorrelationId,
                request.ProductId,
                "keyboard",
                DateTime.UtcNow
            );
        }
    }
}
