using System.Reflection;
using TodoApp.Application;
using TodoApp.Application.Common.Mappings;
using TodoApp.Application.Interfaces;
using TodoApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(ITodosDbContext).Assembly));
});

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policyBuilder =>
    {
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowAnyOrigin();
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<TodosDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;  
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();