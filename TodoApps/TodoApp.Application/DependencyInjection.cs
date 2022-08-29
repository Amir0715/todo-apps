using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Application.Common.Behavior;

namespace TodoApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
        serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return serviceCollection;
    }
}