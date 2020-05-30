using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreManager.Interface;
using BookstoreManager.Manager;
using BookstoreRepository.Context;
using BookstoreRepository.Interface;
using BookstoreRepository.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using BookstoreModel.Model;
using Swashbuckle.AspNetCore.Swagger;

namespace BookstoreApi
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
            services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            services.AddSingleton<IConfiguration>(Configuration);
 
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccount,AccountManager>();

            services.AddTransient<IBook, BookManger>();
            services.AddTransient<IBookRepository, BookRepository>();

            services.AddTransient<ICart, CartManager>();
            services.AddTransient<ICartRepository, CartRepository>();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        


        //swagger
        services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "FUNDOO NOTE API",
                    Description = "ASP.NET Core Web API",
                });
                var security = new Dictionary<string, IEnumerable<string>>
               {
                   {"Bearer",new string[0]}
               };
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWt Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                //c.AddSecurityRequirement(security);
                
            });

            // configure strongly typed settings objects
            //var appSettingsSection = Configuration.GetSection("ApplicatonSetting");
            //services.Configure<ApplicationSettings>(appSettingsSection);

            // configure jwt authentication
            //var appSettings = appSettingsSection.Get<ApplicationSettings>();

            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicatonSettings"));

            var Key = Encoding.UTF8.GetBytes(Configuration["ApplicatonSettings:JWT_Secret"].ToString());
        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Key),
            ValidateIssuer = false,
            ValidateAudience = false
        };

    });

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

            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseCors("MyPolicy");

          

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PRITAM");
            });

        }
    }
}
