﻿using ExaminaFinalVersion.Models;
using ExaminaFinalVersion_Wallahi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminaFinalVersion_Wallahi
{
    public class Startup
    {
        private readonly IConfiguration Configration;
        public Startup(IConfiguration Configration)
        {
            this.Configration = Configration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ContextClass>(option =>
            {
                option.UseSqlServer(Configration.GetConnectionString("MyConnection"));
            });
            services.AddScoped<CourseRepo>();
            services.AddScoped<CourseStudentRelationShipRepo>();
            services.AddScoped<ExamRepo>();
            services.AddScoped<GradsRepo>();
            services.AddScoped<PictureRepo>();
            services.AddScoped<ProfessorRepo>();
            services.AddScoped<ProjectRepo>();
            services.AddScoped<ReadingRepocs>();
            services.AddScoped<RequestRepo>();
            services.AddScoped<SheetRepo>();
            services.AddScoped<StudentRepo>();
            services.AddScoped<VideoRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
