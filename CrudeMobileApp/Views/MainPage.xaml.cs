using CrudeMobileApp.Shared;

namespace CrudeMobileApp
{
    public partial class MainPage : ContentPage
    {
        private readonly DataService _dataService;
        public MainPage(DataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
            LoadOrders();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadOrders(); // Ensure orders are loaded/refreshed whenever the page appears
        }
        private async void LoadOrders()
        {
            OrderListView.ItemsSource = await _dataService.GetOrdersAsync();
        }

        private async void OnAddOrderClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddOrderPage(_dataService));

        }
    }
}
