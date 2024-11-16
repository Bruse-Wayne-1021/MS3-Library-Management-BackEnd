
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using MS3_LMS.IRepository;
using MS3_LMS.IService;
using MS3_LMS.LMSDbcontext;
using MS3_LMS.Repository;
using MS3_LMS.Service;

namespace MS3_LMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<LMSContext>(opt => opt
            .UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));


            builder.Services.AddCors(opt =>
            opt.AddPolicy(
                name: "CorsOpenPolicy",
                builder =>
                {
                    builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                }
                ));

            builder.Services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                  options.JsonSerializerOptions.MaxDepth = 64; 
                 });


            var builders = WebApplication.CreateBuilder(args);
             builders.Logging.ClearProviders();
            builders.Logging.AddConsole();
            builders.Logging.AddDebug();

            //var app= builder.Build();

            builder.Services.AddScoped<IBookRepository,BookRepo>();
            builder.Services.AddScoped<IBookService,BookService>();
            builder.Services.AddScoped<IMemberRepository, MemberRepository>();
            builder.Services.AddScoped<IMemberService, MemberService>();
            
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();

            


            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CorsOpenPolicy");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}