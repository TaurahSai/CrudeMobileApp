using CrudeMobileApp.Model;
using CrudeMobileApp.Services;

namespace CrudeMobileApp;

public partial class AddOrderPage : ContentPage
{
    private readonly ProductService _productService;
    private readonly CustomerService _customerService;
    private readonly OrderService _orderService;
    public AddOrderPage(CustomerService customerService, ProductService productService, OrderService orderService)
    {
        InitializeComponent();
        _customerService = customerService;
        _productService = productService;
        _orderService = orderService;
        LoadCustomersAndProducts();
    }

    private readonly Dictionary<int, string> _customerIds = [];
    private readonly Dictionary<int, string> _productIds = [];

    private async void LoadCustomersAndProducts()
    {
        var customers = await _customerService.GetAllAsync();
        var products = await _productService.GetAllAsync();

        CustomerPicker.Items.Clear();
        ProductPicker.Items.Clear();

        for (int i = 0; i < customers.Count; i++)
        {
            CustomerPicker.Items.Add(customers[i].CompanyName);
            _customerIds[i] = customers[i].CustomerId; // Map index to CustomerId
        }

        for (int i = 0; i < products.Count; i++)
        {
            ProductPicker.Items.Add(products[i].ProductName);
            _productIds[i] = products[i].ProductId; // Map index to ProductId
        }
    }


    private async void OnSaveOrderClicked(object sender, EventArgs e)
    {
        if (CustomerPicker.SelectedIndex == -1 || ProductPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Please select a customer and a product.", "OK");
            return;
        }

        var selectedCustomerId = _customerIds[CustomerPicker.SelectedIndex];
        var selectedProductId = _productIds[ProductPicker.SelectedIndex];
        var quantity = int.Parse(QuantityEntry.Text);

        var customer = await _customerService.GetByIdAsync(selectedCustomerId);
        var product = await _productService.GetByIdAsync(selectedProductId);

        var order = new Order
        {
            CustomerId = customer.CustomerId,
            OrderDate = DateTime.Now,
            ShippingDate = DateTime.Now.AddDays(3),
            ShippingName = customer.ContactName,
            ShippingAddress = "Some Address",
            ShippingCity = "Some City",
            ShippingRegion = "Some Region",
            ShippingPostalCode = "12345",
            ShippingCountry = "Some Country",
            ShippingPhone = "123-456-7890"
        };

        var orderDetails = new List<DetailOrder>
        {
            new() {
                OrderId = order.OrderId,
                ProductId = product.ProductId,
                Quantity = quantity
            }
        };

        await _orderService.AddOrderAsync(order, orderDetails);
        await Navigation.PopAsync();
    }
}