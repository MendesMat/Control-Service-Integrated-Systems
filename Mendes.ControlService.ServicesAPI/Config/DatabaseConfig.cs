using Mendes.ControlService.ManagementAPI.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Mendes.ControlService.ManagementAPI.Config
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Configura o contexto do banco de dados com a string de conexão
            services.AddDbContext<ManagementContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
