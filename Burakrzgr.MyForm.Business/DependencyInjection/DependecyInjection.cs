using Burakrzgr.MyForm.Business.Authentication;
using Burakrzgr.MyForm.Business.Completed;
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
                .AddScoped<IFormTemplateService, FormTemplateManager>()
                .AddScoped<IQuestionTemplate, EfQuestionTemplate>()
                .AddScoped<IFormTemplate, EfFormTemplate>()
                .AddScoped<IOptionsTemplate, EfOptionsTemplate>()
                .AddScoped<IFilledFormService, FilledFormManager>()
                .AddScoped<ISubmittedForm, EfSubmittedForm>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ISubmittedQuestion, EfSubmittedQuestion>().
                .AddScoped<ICompletedFormService, CompletedFormManager>();

            services
                .AddSingleton<FormDbContext>()
                .AddSingleton<QuestionTemplateConverter>()
                .AddSingleton<SubmittedQuestionConverter>()
                .AddHttpContextAccessor();
            return services;
        }

    }
}
