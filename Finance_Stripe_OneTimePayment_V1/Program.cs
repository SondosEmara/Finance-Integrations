using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi;
using Stripe;
using Swashbuckle.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions options) => { });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();
// ─────────────────────────────────────────
// 1. Configuration — read from appsettings
// ─────────────────────────────────────────
var stripeSettings = builder.Configuration.GetSection("Stripe");
var secretKey = stripeSettings["SecretKey"];
var publishableKey = stripeSettings["PublishableKey"];


StripeConfiguration.ApiKey = secretKey;
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger((Swashbuckle.AspNetCore.Swagger.SwaggerOptions options) => { });
    app.UseSwaggerUI((Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIOptions options) => { });

    app.MapOpenApi();
}
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
