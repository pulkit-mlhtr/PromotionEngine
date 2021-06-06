using Microsoft.Extensions.DependencyInjection;
using PromotionEngine.Dao;
using PromotionEngine.Dao.Interface;
using PromotionEngine.Logic;
using PromotionEngine.Logic.Interface;

namespace PromotionEngine
{
    public static class Startup
    {
        public static ServiceCollection collection = new ServiceCollection();

        static Startup()
        {
            collection.AddScoped<IPromotionDao, PromotionDao>();
            collection.AddScoped<IProductDao, ProductDao>();
            collection.AddScoped<IOrderDao, OrderDao>();
            collection.AddScoped<IPromotionLogic, PromotionLogic>();
            collection.AddScoped<IProductLogic, ProductLogic>();
            collection.AddScoped<IOrderLogic, OrderLogic>();
        }
    }
}
