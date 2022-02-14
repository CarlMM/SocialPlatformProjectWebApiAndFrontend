using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SocialPlatformProjectWebApi.Repository;
using SocialPlatformProjectWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi
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
            // Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IReplyService, ReplyService>();
            services.AddTransient<IReplyRepository, ReplyRepository>();
            services.AddTransient<ICategoryThreadService, CategoryThreadService>();
            services.AddTransient<ICategoryThreadRepository, CategoryThreadRepository>();
            services.AddTransient<IThreadUserService, ThreadUserService>();
            services.AddTransient<IThreadUserRepository, ThreadUserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SocialPlatformProjectWebApi", Version = "v1" });
            });
        //    services.AddAuth0WebAppAuthentication(options => {
        //    options.Domain = Configuration["Auth0:Domain"];
        //    options.ClientId = Configuration["Auth0:ClientId"];
        //});


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                //options.Authority = Configuration["Authentication:Domain"];
                //options.Audience = Configuration["Authentication:Audience"];

                options.Authority = "https://dev-dzje4s8y.us.auth0.com/";
                options.Audience = "https://auth0sucks/api";
                
            });


            services.AddAuthorization(options =>
            {

                // CategoryThreadController policies
                options.AddPolicy("GetThreads", policy => policy.RequireClaim("permissions", "read:categoryThreads"));
                options.AddPolicy("GetThreadsAndRepliesAndThreadUsers", policy => policy.RequireClaim("permissions", "get:threadandrepliesandthreadUsers"));
                options.AddPolicy("GetThreadCategoryId", policy => policy.RequireClaim("permissions", "get:threadCategoryId"));
                options.AddPolicy("GetThreadByThreadType", policy => policy.RequireClaim("permissions", "get:threadByType"));
                options.AddPolicy("GetGroupThreadByUserId", policy => policy.RequireClaim("permissions", "get:groupThreadUserId"));
                options.AddPolicy("GetThreadByUserId", policy => policy.RequireClaim("permissions", "get: threadByUserId"));
                options.AddPolicy("GetThreadById", policy => policy.RequireClaim("permissions", "get: threadById"));
                options.AddPolicy("PostThread", policy => policy.RequireClaim("permissions", "post:thread"));
                options.AddPolicy("DeleteThread", policy => policy.RequireClaim("permissions", "delete:thread"));
                options.AddPolicy("PutThreadText", policy => policy.RequireClaim("permissions", "put:threadText"));
                

                // ReplyController policies

                options.AddPolicy("GetReplies", policy => policy.RequireClaim("permissions", "get:replies"));
                options.AddPolicy("ReplyUserId", policy => policy.RequireClaim("permissions", "get:replyUserid"));
                options.AddPolicy("ReplyThreadId", policy => policy.RequireClaim("permissions", "get:replyThreadId"));
                options.AddPolicy("Reply", policy => policy.RequireClaim("permissions", "post:reply"));
                options.AddPolicy("DeleteReplyId", policy => policy.RequireClaim("permissions", "delete:replyId"));
                options.AddPolicy("EditReply", policy => policy.RequireClaim("permissions", "put:reply"));


                

                // ThreadUserController policies

                options.AddPolicy("GetThreadUsers", policy => policy.RequireClaim("permissions", "get:threadUsers"));
                options.AddPolicy("GetThreadUsersByCategoryId", policy => policy.RequireClaim("permissions", "get:threadUsersByCategoryId"));
                options.AddPolicy("AddThreadUser", policy => policy.RequireClaim("permissions", "post:addThreadUser"));
                options.AddPolicy("DeleteThreadUser", policy => policy.RequireClaim("permissions", "delete:threadUser"));


                // UserController policies

                options.AddPolicy("GetUsers", policy => policy.RequireClaim("permissions", "get:user"));
                options.AddPolicy("DeleteUser", policy => policy.RequireClaim("permissions", "delete:user"));
                options.AddPolicy("PostUser", policy => policy.RequireClaim("permissions", "post:user"));


            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable Cors
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialPlatformProjectWebApi v1");
                   

                });
                
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
