using Burakrzgr.MyForm.Business.FormTemplate;
using Burakrzgr.MyForm.Data.EntityFramework;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Data.Memory;
using Burakrzgr.MyForm.Entity.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Burakrzgr.MyForm.Business.DependencyInjection
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services
                .AddScoped<IFormService, FormManager>()
                .AddScoped<IFormData, MemFormData>()
                .AddScoped<IQuestionData, MemQuestionData>()
                .AddScoped<IFormTemplate, EfFormTemplate>();

            services.AddSingleton<FormDbContext>();
            return services;
        }

    }
}
