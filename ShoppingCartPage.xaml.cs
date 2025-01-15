using FloreaCristinaProiect.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FloreaCristinaProiect;

public partial class ShoppingCart : ContentPage
{
    public ObservableCollection<ShoppingCartItem> CartItems { get; set; }
    public int TotalPrice => CartItems?.Sum(item => item.TotalPrice) ?? 0;
    public string Address { get; set; }

    public Command<ShoppingCartItem> RemoveFromCartCommand { get; }

    public ShoppingCart()
    {
        InitializeComponent();
        RemoveFromCartCommand = new Command<ShoppingCartItem>(async (item) => await RemoveFromCart(item));
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var items = await App.Database.GetCartItemsAsync();
        CartItems = new ObservableCollection<ShoppingCartItem>(items);
        OnPropertyChanged(nameof(CartItems));
        OnPropertyChanged(nameof(TotalPrice));
    }

    async Task RemoveFromCart(ShoppingCartItem item)
    {
        await App.Database.RemoveFromCartAsync(item);
        CartItems.Remove(item);
        OnPropertyChanged(nameof(CartItems));
        OnPropertyChanged(nameof(TotalPrice));
    }

     async void OnCheckoutClicked(object sender, EventArgs e)
    {
        // Validate Address
        if (string.IsNullOrWhiteSpace(Address))
        {
            await DisplayAlert("Error", "Please provide a valid address before checking out.", "OK");
            return;
        }

        // Navigate to the order confirmation page
        await Navigation.PushAsync(new OrderConfirmationPage());
    }

    async void RemoveFromCart(object sender, EventArgs e)
    {
        // Identify which item is being removed
        var button = sender as Button;
        if (button?.BindingContext is ShoppingCartItem item)
        {
            // Remove from database
            await App.Database.RemoveFromCartAsync(item);

            // Remove from ObservableCollection
            CartItems.Remove(item);

            // Update the UI
            OnPropertyChanged(nameof(CartItems));
            OnPropertyChanged(nameof(TotalPrice));
        }

    }
    
}
