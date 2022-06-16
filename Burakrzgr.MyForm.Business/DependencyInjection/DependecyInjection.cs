using Burakrzgr.MyForm.Business.Authentication;
using Burakrzgr.MyForm.Business.Completed;
using Burakrzgr.MyForm.Business.FilledForm;
using Burakrzgr.MyForm.Business.FormTemplate;
using Burakrzgr.MyForm.Business.History;
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
                .AddScoped<IFilledFormService, FilledFormManager>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ICompletedFormService, CompletedFormManager>()
                .AddScoped<IHistoryService, HistoryManager>()

                .AddScoped<IOptionsTemplateDal, EfOptionsTemplateDal>()
                .AddScoped<IFormTemplateDal, EfFormTemplateDal>()
                .AddScoped<ISubmittedQuestion, EfSubmittedQuestion>()
                .AddScoped<ISubmittedForm, EfSubmittedForm>()
                .AddScoped<IQuestionTemplate, EfQuestionTemplate>()
                .AddScoped<IOperationDal, EfOperationDal>();

            services
                .AddSingleton<FormDbContext>()
                .AddSingleton<QuestionTemplateConverter>()
                .AddSingleton<SubmittedQuestionConverter>()
                .AddHttpContextAccessor();
            return services;
        }

    }
}
