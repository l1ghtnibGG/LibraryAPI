using BusinessLogic.AutoMapperHelper;
using Entities.Data;
using LibraryAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.ConfigureSqlServerContext(config);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddUnitOfWork();
builder.Services.AddServices();

builder.Services.AddAuthenticationJwt(config);
builder.Services.AddAuthorization();

builder.Services.AddFluentValidation();

builder.Services.AddSwaggerWithJwt();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

app.UseExceptionHandlerMiddleware();  

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWTAuthDemo v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

SeedData.EnsureData(app);

app.Run();