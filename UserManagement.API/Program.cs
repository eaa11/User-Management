using FastEndpoints;
using Microsoft.AspNetCore.Diagnostics;
using UserManagement.API.Commom;
using UserManagement.API.Commom.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddFastEndpoints();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddUserModuleServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.ContentType = "application/json";
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception is ValidationException validationEx)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            var errorResponse = new { Message = validationEx.Message, Code = validationEx.ErrorCode };
            await context.Response.WriteAsJsonAsync(errorResponse);
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var innerExceptionMessage = exception?.InnerException != null ? exception.InnerException.Message : "No inner exception";
            var errorResponse = new
            {
                Message = exception?.Message,
                InnerException = innerExceptionMessage,
            };
            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    });
});

app.UseFastEndpoints();
app.UseHttpsRedirection();

app.Run();