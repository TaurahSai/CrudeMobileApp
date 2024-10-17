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
    private async void LoadCustomersAndProducts()
    {
        var customers = await _customerService.GetCustomersAsync();
        var products = await _productService.GetProductsAsync();

        foreach (var customer in customers)
        {
            CustomerPicker.Items.Add(customer.CompanyName);
        }

        foreach (var product in products)
        {
            ProductPicker.Items.Add(product.ProductName);

        }
    }

    private async void OnSaveOrderClicked(object sender, EventArgs e)
    {
        var selectedCustomerName = CustomerPicker.SelectedItem.ToString();
        var selectedProductName = ProductPicker.SelectedItem.ToString();
        var quantity = int.Parse(QuantityEntry.Text);

        var selectedCustomer = await _customerService.GetCustomersAsync();
        var selectedProduct = await _productService.GetProductsAsync();

        var customer = selectedCustomer.FirstOrDefault(c => c.CompanyName == selectedCustomerName);
        var product = selectedProduct.FirstOrDefault(p => p.ProductName == selectedProductName);

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