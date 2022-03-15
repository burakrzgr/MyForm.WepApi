using Burakrzgr.MyForm.Business.Form;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Data.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Burakrzgr.MyForm.Business.DependencyInjection
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IFormService, FormManager>()
                .AddScoped<IFormData, MemFormData>();

            return services;
        }

    }
}
