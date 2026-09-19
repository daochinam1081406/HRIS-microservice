var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// config swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Đăng ký service
builder.Services.AddScoped<Hris.Recruitment.Api.Services.ICandidateService, 
Hris.Recruitment.Api.Services.CandidateService>();

var app = builder.Build();

//run swagger
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI(); // 
//}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
