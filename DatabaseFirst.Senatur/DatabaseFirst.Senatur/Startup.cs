using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace DatabaseFirst.Senatur
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options => { options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore; options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            services.AddAuthentication(options => { options.DefaultAuthenticateScheme = "JwtBearer"; options.DefaultChallengeScheme = "JwtBearer"; }).AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senatur-chave-autenticacao")),
                    ClockSkew = TimeSpan.FromHours(2),
                    ValidIssuer = "DatabaseFirst.Senatur",
                    ValidAudience = "DatabaseFirst.Senatur"
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Api DatabaseFirst.Senatur",
                    Description = "Documentação da API do projeto DatabaseFirst.Senatur"
                });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition(
                    "Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Copie 'Bearer {token}",
                        Name = "Authorization",
                        Type = "apiKey"
                    });

                c.AddSecurityRequirement(security);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DatabaseFirst.Senatur API");
                c.DocumentTitle = "API DatabaseFirst.Senatur";
            });

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
