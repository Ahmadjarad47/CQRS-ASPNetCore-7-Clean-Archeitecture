using Ecommerce.Application.Persistance.Email;
using Ecommerce.Application.Shared;
using Ecommerce.Infrastructure.Email;
using Ecommerce.Infrastructure.Shared;
using Ecommerce.Persistence.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureApplicationService();
builder.Services.ConfigurePersistenceService(builder.Configuration);
builder.Services.ConfigureInfrastructureService(builder.Configuration);
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
//Configure Cors
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", p =>
    {
        p.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();
