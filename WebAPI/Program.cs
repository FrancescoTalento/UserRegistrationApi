
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAPI.Authorization;
using WebAPI.Data;
using WebAPI.Data.Models;
using WebAPI.Services;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<TokenService>();
            builder.Services.AddScoped<UserService>();

            builder.Services.AddDbContext<UserDbContext>(options => 
            {
                string connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";
                options.UseMySql(connection, ServerVersion.AutoDetect(connection));
            });


            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("MinimumAge", policy =>
                {
                    policy.AddRequirements(new MinimumAge(18));
                });
            });
            

            //builder.Services
            //    .AddDefaultIdentity<User>(
            //        options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<UserDbContext>();


            builder.Services
                .AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
