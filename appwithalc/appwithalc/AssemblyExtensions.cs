using System.Reflection;

public static class AssemblyExtensions
{
    public static T CreateInstance<T>(this Assembly assembly, string typeName)
    {
        var instance = assembly.CreateInstance(typeName);
        T castedInstance = (T)instance;
        return castedInstance;
    }
}