using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReviewsAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BookReviewsAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //string con = "Server=tcp:10.10.138.12;Database=BooksReviewsAPI;User ID= sa;Password=strctsa;";
            //string con = "Data Source=tcp:booksreviewsapidbserver.database.windows.net,1433;Initial Catalog=BooksReviewsAPI_db;User Id=Azat@booksreviewsapidbserver;Password=Deinferno98";

            services.AddDbContext<ApiContext>(opt =>
                                                    opt.UseSqlServer(Configuration.GetConnectionString("BooksAPIConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
