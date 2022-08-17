using AspNetCoreRateLimit;
using DAL;
using FinalPorject.Extensions;
using Microsoft.EntityFrameworkCore;
using Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.Enrich.FromLogContext()
        .Enrich.WithMachineName()
        .WriteTo.Console()
        .WriteTo.Seq(context.Configuration["Serilog:SeqUrl"])
        .Enrich.WithProperty("Environment", Environment.MachineName)
        .ReadFrom.Configuration(context.Configuration);
});


builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerService();
builder.Services.AddTools();
builder.Services.AddJWTAuthentication(builder.Configuration);
builder.Services.AddDbContext<TwitterDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("TwitterDbConnectionString")));
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIpRateLimiting();
//app.UseGlobalExceptionHandler();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();



app.Run();
