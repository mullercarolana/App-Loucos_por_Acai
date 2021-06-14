using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_Loucos_por_Acai.Context;
using App_Loucos_por_Acai.Models;
using App_Loucos_por_Acai.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App_Loucos_por_Acai
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "server=localhost;user=root;password='';database=ef";

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));

            services.AddDbContext<AppDbContext>(
                dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());
            services.AddControllersWithViews();

            services.AddIdentity<IdentityUser, IdentityRole>()
                  .AddEntityFrameworkStores<AppDbContext>()
                  .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Home/AccessDenied");

            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<ILancheRepository, LancheRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //AddScoped = VAI CRIAR UM NOVO OBJETO PARA CADA REQUISIÇÃO, EVITANDO CARRINHO DE COMPRAS DUPLICADO
            services.AddScoped(cp => CarrinhoCompra.GetCarrinho(cp));
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
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

            app.UseStaticFiles();
            app.UseSession();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute", "{area:exists}/{Controller=Admin}/{Action=Index}/{id?}");

                routes.MapRoute(
                    name: "filtrarPorCategoria",
                    template: "Lanche/{action}/{categoria}",
                    defaults: new { Controller = "Lanche", action = "List" }
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
