using CrudeMobileApp.Model;
using CrudeMobileApp.Shared;

namespace CrudeMobileApp;

public partial class AddOrderPage : ContentPage
{
    private readonly DataService _dataService;
    public AddOrderPage(DataService dataService)
    {
        InitializeComponent();
        _dataService = dataService;
        LoadCustomersAndProducts();
    }
    private async void LoadCustomersAndProducts()
    {
        var customers = await _dataService.GetCustomersAsync();
        var products = await _dataService.GetProductsAsync();

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

        var selectedCustomer = await _dataService.GetCustomersAsync();
        var selectedProduct = await _dataService.GetProductsAsync();

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
            new DetailOrder
            {
                OrderId = order.OrderId,
                ProductId = product.ProductId,
                Quantity = quantity
            }
        };

        await _dataService.AddOrderAsync(order, orderDetails);
        await Navigation.PopAsync();
    }
}