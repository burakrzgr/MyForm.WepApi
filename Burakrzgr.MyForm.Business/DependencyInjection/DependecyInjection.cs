using Burakrzgr.MyForm.Business.FilledForm;
using Burakrzgr.MyForm.Business.FormTemplate;
using Burakrzgr.MyForm.Business.QuestionManager;
using Burakrzgr.MyForm.Data.EntityFramework;
using Burakrzgr.MyForm.Data.Interfaces;
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
                .AddScoped<IQuestionTemplate, EfQuestionTemplate>()
                .AddScoped<IFormTemplate, EfFormTemplate>()
                .AddScoped<IOptionsTemplate, EfOptionsTemplate>()
                .AddScoped<IFilledFormService, FilledFormManager>()
                .AddScoped<ISubmittedForm, EfSubmittedForm>()
                .AddScoped<ISubmittedQuestion, EfSubmittedQuestion>();

            services
                .AddSingleton<FormDbContext>()
                .AddSingleton<QuestionTemplateConverter>()
                .AddSingleton<SubmittedQuestionConverter>();
            return services;
        }

    }
}
