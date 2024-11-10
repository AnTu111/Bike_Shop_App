using System.IO;
using BikeShopApp.Services;
using BikeShopApp.Views;

namespace BikeShopApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BikeShopApp.db");
            var databaseService = new DatabaseService(dbPath);
            MainPage = new NavigationPage(new MainPage(databaseService));
        }
    }
}
