namespace API.Services
{
    using DataAccess.Entities;
    using Microsoft.EntityFrameworkCore.Query;
    using System.Data.Entity.Infrastructure;

    internal static class ServiceExtensions
    {
        internal static async Task<bool> SafeSaveChangesAsync(this Context context, ILogger logger)
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex) when (ex is DbUpdateException || ex is DbUpdateConcurrencyException)
            {
                logger.LogError(ex, message: ex.Message);
                return false;
            }

            return true;
        }
    }
}
