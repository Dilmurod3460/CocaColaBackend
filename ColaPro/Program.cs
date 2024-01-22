using ColaPro.DataAccess.DataContext;
using ColaPro.Service.Interface;
using ColaPro.Service.Service;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddScoped<ILoginRepository, LoginService >();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<IRequestRepository, RequestService >();
builder.Services.AddScoped<RequestService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseCors();

app.Run();

