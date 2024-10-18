using CrudeMobileApp.Model;
using CrudeMobileApp.Services;
using System.Windows.Input;

namespace CrudeMobileApp
{
    public partial class MainPage : ContentPage
    {
        private readonly ProductService _productService;
        private readonly CustomerService _customerService;
        private readonly OrderService _orderService;
        public ICommand DeleteOrderCommand { get; }
        public MainPage(OrderService orderService, CustomerService customerService, ProductService productService)
        {
            InitializeComponent();
            BindingContext = this;
            _orderService = orderService;
            _productService = productService;
            _customerService = customerService;
            DeleteOrderCommand = new Command<Order>(async (order) => await DeleteOrder(order));
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
        private async Task DeleteOrder(Order order)
        {
            await _orderService.DeleteOrderAsync(order);
            LoadOrders(); // Reload orders after deletion
        }
        private async void OnAddOrderClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddOrderPage(_customerService, _productService, _orderService));
        }
    }
}
