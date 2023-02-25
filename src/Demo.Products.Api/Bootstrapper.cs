namespace Demo.Products.Api
{
    using Features.AddProduct;
    using Features.GetProductById;

    public static class Bootstrapper
    {
        public static void RegisterApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<ICreateProductService, CreateProductService>();
            builder.Services.AddSingleton<IProductSearchByIdService, ProductSearchByIdService>();
        }
    }
}
