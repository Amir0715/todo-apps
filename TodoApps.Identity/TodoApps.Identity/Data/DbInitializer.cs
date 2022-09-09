namespace TodoApps.Identity;

public class DbInitializer
{
    public static void Initialize(AuthDbContext context)
    {
        context.Database.EnsureCreated();
    }
}