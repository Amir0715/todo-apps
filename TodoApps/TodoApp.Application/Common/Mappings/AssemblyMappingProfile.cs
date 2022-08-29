using System.Reflection;
using AutoMapper;

namespace TodoApp.Application.Common.Mappings;

public class AssemblyMappingProfile: Profile
{
    public AssemblyMappingProfile(Assembly assembly)
    {
        
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(type => type.GetInterfaces()
                .Any(inteface => inteface.IsGenericType && 
                                 inteface.GetGenericTypeDefinition() == typeof(IMapWith<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}