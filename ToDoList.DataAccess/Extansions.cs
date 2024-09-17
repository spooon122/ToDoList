using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.DataAccess.Interfaces;
using ToDoList.DataAccess.Repositories;

namespace ToDoList.DataAccess
{
    public static class Extansions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services) 
        {
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddDbContext<AppDbContext>(opt => 
            {
                opt.UseNpgsql("YOUR_CONNECTION_STRING");
            });

            return services;
        }
    }
}
