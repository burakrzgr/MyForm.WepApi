using Burakrzgr.MyForm.Business.FormTemplate;
using Burakrzgr.MyForm.Business.QuestionManager;
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
                .AddScoped<IQuestionTemplate, EfQuestionTemplate>()
                .AddScoped<IFormTemplate, EfFormTemplate>();

            services
                .AddSingleton<FormDbContext>()
                .AddSingleton<QuestionConverter>();
            return services;
        }

    }
}
