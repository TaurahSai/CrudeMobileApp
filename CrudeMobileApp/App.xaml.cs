using CrudeMobileApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace CrudeMobileApp
{
    public partial class App : Application
    {

        public App(DataService dataService, AppDbContext dbContext)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(dataService));

            // Ensure the database is created without disposing the context manually
            using (var db = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite($"Filename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "app.db")}")
                .Options))
            {
                db.Database.EnsureCreated();
            }
        }
    }
}