namespace Mendes.ControlService.ManagementAPI.Config
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Management API",
                    Version = "v1",
                    Description = "API para gerenciamento de clientes e serviços"
                });

                // Configuração para suportar tipos de referência não anuláveis no Swagger
                options.SchemaGeneratorOptions.SupportNonNullableReferenceTypes = true;
            });
        }
    }
}
