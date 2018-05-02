using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using SoftDC.Data;
using System;
using System.IO;

namespace SofeDC
{
    public class Startup
    {
        private readonly ILogger _logger;//日志记录
        private IHostingEnvironment env;//环境变量
        public IConfiguration Configuration { get; }//配置

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            this.env = env;
            _logger = loggerFactory.CreateLogger<Startup>();
            //Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        // 注册服务
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();

            // Adds a default in-memory implementation of IDistributedCache.
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(120);
            });

            //Configure Connection
#if DEBUG
            services.AddDbContext<RjyfzxDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("MySqlConnection"),
                    providerOptions => providerOptions.CommandTimeout(60))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            );
#else
            services.AddDbContext<RjyfzxDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
#endif
            // 添加实体服务
            services.AddEntityFrameworkSqlite().AddDbContext<RjyfzxDbContext>();

            ////
            //services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 name: "areas",
                 template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
               );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // NOTE: this must go at the end of Configure
            //初始化数据库，完成后将其注释
//            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
//            using (var serviceScope = serviceScopeFactory.CreateScope())
//            {
//                var dbContext = serviceScope.ServiceProvider.GetService<RjyfzxDbContext>();
//#if DEBUG
//                dbContext.Database.EnsureDeleted();
//#endif
//                dbContext.Database.EnsureCreatedAsync();
//            }
        }
    }
}
