using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyPortfolioApp.Shared.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AutoBind(this IServiceCollection source, params Assembly[] assemblies)
        {
            source.Scan(scan => scan.FromAssemblies(assemblies)
            .AddClasses(classes => classes.WithAttribute<AutoBindAttribute>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        }
    }
}
