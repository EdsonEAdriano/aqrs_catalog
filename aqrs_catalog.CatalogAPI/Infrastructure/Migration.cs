using aqrs_catalog.CatalogAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace aqrs_catalog.CatalogAPI.Infrastructure
{
    public static class Migration
    {
        public static WebApplication ApplyPendingMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ContextDbApplication>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError($"An error occurred while migrating the database. ERROR MESSAGE: {ex.Message};");
                }
            }

            return app;
        }
    }
}
