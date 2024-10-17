using CrudeMobileApp.Services;
using Microsoft.EntityFrameworkCore;

namespace CrudeMobileApp
{
    public partial class App : Application
    {

        public App(CustomerService customerService, OrderService orderService,ProductService productService, AppDbContext dbContext)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(orderService, customerService, productService));

            // Ensure the database is created without disposing the context manually
            using (var db = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite($"Filename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "app1.db")}")
                .Options))
            {
                db.Database.EnsureCreated();
            }
        }
    }
}