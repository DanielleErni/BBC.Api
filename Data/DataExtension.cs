using Microsoft.EntityFrameworkCore;

namespace BBC.Api.Data;

public static class DataExtension
{
    public static async Task MigrateDb(this WebApplication app){
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BBCContext>();
        await dbContext.Database.MigrateAsync();
    }
}
