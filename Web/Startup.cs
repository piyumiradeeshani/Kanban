using Entities;
using Infrastructures.Core;
using Infrastructures.Repositories;
using Infrastructures.Repositories.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Services.Mappers;
using Services.Models;
using Services.Services;
using Services.Services.Contracts;
using Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Task = Entities.Task;
using Web.Mappers;
using Web.ViewModels;

namespace Web
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
            
            services.AddDbContext<KanbanContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("KanbanDatabase")));

            services.AddControllers();
            //Repositories
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserRepoitory, UserRepoitory>();
            //Services
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITokenService, TokenService>();
            //Mappers
            services.AddScoped<IMapper<Board, BoardModel>,BoardToBoardModel>();
            services.AddScoped<IMapper<UserViewModel, User>, UserViewModelToUser>();
            services.AddScoped<IMapper<List<Board>, List<BoardTask>>, BoardToBoardTask>();
            services.AddScoped<IMapper<List<Board>, List<BoardModel>>,BoardToBoardModelListMapper> ();
            services.AddScoped<IMapper<TaskViewModel, Task>, TaskViewModelToTask> ();
            services.AddScoped<IMapper<Task, TaskViewModel>, TaskToTaskViewModel> ();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
