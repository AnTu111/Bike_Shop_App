using BikeShopApp;
using BikeShopApp.Services;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("JosefinSans-Bold.ttf", "JosefinSans-Bold.ttf");
            });

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "bikeshop.db3");
        builder.Services.AddSingleton(s => new DatabaseService(dbPath));

        return builder.Build();
    }
}
