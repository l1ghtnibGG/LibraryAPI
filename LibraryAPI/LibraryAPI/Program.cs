using LibraryAPI.AutoMapperHelper;
using LibraryAPI.Models.Data;
using LibraryAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.ConfigureSqlServerContext(config);

builder.Services.AddControllersWithValidation();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerWithJwt();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddAuthenticationJwt(config);
builder.Services.AddAuthorization();

builder.Services.AddServices();

var app = builder.Build();

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