
using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        ;      //é©çÏ

    // Add services to the container.


}


var app = builder.Build();
{
    //// Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    //{
    //    app.UseSwagger();
    //    app.UseSwaggerUI();
    //}

    //app.UseMiddleware<ErrorHandlingMiddleware>();

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();

    //app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
