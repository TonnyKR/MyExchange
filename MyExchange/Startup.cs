using Microsoft.EntityFrameworkCore;
using MyExchange.BusinessLogic;
using MyExchange.BusinessLogic.Interfaces;
using MyExchange.BusinessLogic.Services;
using MyExchange.Data;
using MyExchange.Data.Interfaces;
using MyExchange.Data.Repository;

namespace MyExchange.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Use this method to add services to the container.

        public void AddServices(IServiceCollection services)
        {
            services.AddDbContext<MyExchangeContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddControllers();

            services.AddScoped<IRepository, EFCoreRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IWalletPositionService, WalletPositionService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IPromoCode, PromoCodeService>();
            services.AddScoped<IBankCardService, BankCardService>();
            services.AddScoped<IBankService, BankService>();


            services.AddEndpointsApiExplorer();
            services.AddAutoMapper(typeof(BuisnessLogicAssemblyMarker));
            services.AddSwaggerGen();
        }

        //Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
