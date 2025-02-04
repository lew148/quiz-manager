using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using quizManager.Data.Repos;
using quizManager.QuizManager.Services;

namespace quizManager
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
            services.AddControllersWithViews();
            
            services.AddSession(options => {  
                options.IdleTimeout = TimeSpan.FromMinutes(5);  
            });
            services.AddHttpContextAccessor();

            // DI Config
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IQuizService, QuizService>();
            services.AddScoped<IQuizRepo, QuizRepo>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuestionRepo, QuestionRepo>();
            services.AddScoped<IQuestionOrderService, QuestionOrderService>();
            services.AddScoped<IQuestionOrderRepo, QuestionOrderRepo>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IAnswerRepo, AnswerRepo>();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseSession();
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}