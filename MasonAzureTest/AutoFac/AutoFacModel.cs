using Autofac;
using MasonAzureTest.Services;

namespace MasonAzureTest.AutoFac
{
    public static class AutoFacModule
    {
        public static ContainerBuilder RegisterTypes()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ShopperService>().AsImplementedInterfaces();
            builder.RegisterType<ProductService>().AsImplementedInterfaces();

            return builder;
        }
    }
}
