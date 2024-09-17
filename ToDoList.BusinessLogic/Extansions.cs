using Microsoft.Extensions.DependencyInjection;
using ToDoList.BusinessLogic.Interfaces;
using ToDoList.BusinessLogic.Services;

namespace ToDoList.BusinessLogic
{
    public static class Extansions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<INoteService, NoteService>();

            return services;
        }
    }
}
