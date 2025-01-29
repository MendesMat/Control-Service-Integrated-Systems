using Mendes.ControlService.ManagementAPI.Profiles;

namespace Mendes.ControlService.ManagementAPI.Config
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            // Adiciona o AutoMapper com o perfil de mapeamento
            services.AddAutoMapper(typeof(CustomerProfile));
        }
    }
}
