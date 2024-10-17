using CrudeMobileApp.Services;

namespace CrudeMobileApp
{
    public partial class MainPage : ContentPage
    {
        private readonly ProductService _productService;
        private readonly CustomerService _customerService;
        private readonly OrderService _orderService;
        public MainPage(OrderService orderService, CustomerService customerService, ProductService productService)
        {
            InitializeComponent();
            _orderService = orderService;
            _productService = productService;
            _customerService = customerService;
            LoadOrders();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadOrders(); // Ensure orders are loaded/refreshed whenever the page appears
        }
        private async void LoadOrders()
        {
            OrderListView.ItemsSource = await _orderService.GetOrdersWithCustomerAsync();
        }

        private async void OnAddOrderClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddOrderPage(_customerService, _productService, _orderService));
        }
    }
}
