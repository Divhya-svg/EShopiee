// <copyright file="Startup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.WebApi
{
    using System.Text;
    using Kanini.ECommerce.EShopiee.BL.Payment;
    using Kanini.ECommerce.EShopiee.BL.Product;
    using Kanini.ECommerce.EShopiee.BL.ProductSearch;
    using Kanini.ECommerce.EShopiee.BL.User;
    using Kanini.ECommerce.EShopiee.BL.UserLogin;
    using Kanini.ECommerce.EShopiee.BL.UserRole;
    using Kanini.ECommerce.EShopiee.BL.WishList;
    using Kanini.ECommerce.EShopiee.DAL.Payment;
    using Kanini.ECommerce.EShopiee.DAL.Product;
    using Kanini.ECommerce.EShopiee.DAL.ProductSearch;
    using Kanini.ECommerce.EShopiee.DAL.Repository;
    using Kanini.ECommerce.EShopiee.DAL.User;
    using Kanini.ECommerce.EShopiee.DAL.UserLogin;
    using Kanini.ECommerce.EShopiee.DAL.UserRole;
    using Kanini.ECommerce.EShopiee.DAL.WishList;
    using Kanini.ECommerce.EShopiee.Services;
    using Kanini.ECommerce.EShopiee.WebApi.Helpers;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// Class StartUp.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// string myAllowSpecificOrigins.
        /// </summary>
        private readonly string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// Constructor injection.
        /// </summary>
        /// <param name="configuration">configuration parameter.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets Configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">services param.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    this.myAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                    });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // configure strongly typed settings objects
            var appSettingSection = this.Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSection);

            // configure jwt authentication
            var appSettings = appSettingSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            // Configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IUserLoginRepository, UserLoginRepository>();
            services.AddTransient<IUserLoginRepo, UserLoginRepo>();
            services.AddTransient<IBaseRepo, BaseRepo>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductRepo, ProductRepo>();
            services.AddTransient<IRoleRepo, RoleRepo>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IWishListRepository, WishListRepository>();
            services.AddTransient<IWishListRepo, WishListRepo>();
            services.AddTransient<ISearchProductRepository, SearchProductRepository>();
            services.AddTransient<ISearchProduct, SearchProductBl>();
            services.AddTransient<IPaymentRepo, PaymentRepo>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
        }

        /// <summary>
        /// Configure DI for application services.
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline..
        /// </summary>
        /// <param name="app">app param.</param>
        /// <param name="env">env param.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseAuthentication();
        }
    }
}
