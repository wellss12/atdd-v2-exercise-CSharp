using Autofac;
using Microsoft.Extensions.Configuration;
using SpecFlow.Autofac;

namespace ATDD.V2.Exercise.CSharp.Specs.Support;

public static class TestDependencies
{
    private static IConfiguration? _config;

    [ScenarioDependencies]
    public static void CreateContainerBuilder(ContainerBuilder builder)
    {
        _config ??= new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        builder.RegisterInstance(_config).As<IConfiguration>();
        builder.RegisterType<MyDbContext>().AsSelf().InstancePerLifetimeScope();

        builder.RegisterTypes(typeof(TestDependencies).Assembly
            .GetTypes()
            .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute)))
            .ToArray()).SingleInstance();
    }
}