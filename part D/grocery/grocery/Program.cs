// See https://aka.ms/new-console-template for more information
using BLLgrocery.BLmanager;
using DALgrocery;
using DALgrocery.DALIrepository;
using DALgrocery.DALrepository;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");



    /*static void Main(string[] args)
    {
        using (var db = new AppDbContext())
        {
            db.Database.EnsureCreated();
            Console.WriteLine("המסד נוצר בהצלחה");
        }
    }*/
     void ConfigureServices(IServiceCollection services)
    {
        // רישום ה־DbContext אם זה Entity Framework
        services.AddDbContext<DbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // רישום ה־Repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();

        // רישום המנג'רים
        services.AddScoped<ProductManager>();
        services.AddScoped<OrderItemManager>();
        services.AddScoped<SupplierManager>();
    }

