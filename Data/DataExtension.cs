using Microsoft.EntityFrameworkCore;

namespace BBC.Api.Data;

public static class DataExtension
{
    public static void MigrateDb(this WebApplication app){
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BBCContext>();
        dbContext.Database.Migrate();
    }
}
