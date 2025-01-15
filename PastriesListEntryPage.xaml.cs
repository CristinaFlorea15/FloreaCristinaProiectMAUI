using FloreaCristinaProiect.Models;

namespace FloreaCristinaProiect;

public partial class PastriesListEntryPage : ContentPage
{
    public PastriesListEntryPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetPastriesListsAsync();
    }

    async void OnPastriesListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PastriesListPage
        {
            BindingContext = new PastriesList()
        });
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new PastriesListPage
            {
                BindingContext = e.SelectedItem as PastriesList
            });
        }
    }

    // Ensure this method is here in the correct code-behind
    async void OnInsertImageButtonClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select an image",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                var pastriesList = BindingContext as PastriesList;
                if (pastriesList != null)
                {
                    pastriesList.PastriesImage = result.FullPath;
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Unable to select image: {ex.Message}", "OK");
        }
    }

    // Add to Cart Method
    async void OnAddToCartClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button?.Parent is StackLayout parent)
        {
            // Find the QuantityEntry in the same parent layout
            var quantityEntry = parent.FindByName<Entry>("QuantityEntry");

            if (quantityEntry != null && int.TryParse(quantityEntry.Text, out int quantity) && quantity > 0)
            {
                // Get the associated pastry object
                var pastry = button.BindingContext as PastriesList;

                if (pastry != null)
                {
                    // Convert PastriesList to ShoppingCartItem
                    var cartItem = pastry.ToCartItem(quantity);

                    // Check if the item already exists in the cart
                    var existingCartItems = await App.Database.GetCartItemsAsync();
                    var existingItem = existingCartItems.FirstOrDefault(item => item.PastryID == cartItem.PastryID);

                    if (existingItem != null)
                    {
                        // Update the quantity if the item exists
                        existingItem.Quantity += cartItem.Quantity;
                        await App.Database.UpdateCartItemAsync(existingItem);
                    }
                    else
                    {
                        // Add new item to the cart
                        await App.Database.AddToCartAsync(cartItem);
                    }

                    await DisplayAlert("Added to Cart", $"{quantity} x {pastry.Name} has been added to your cart.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Invalid Quantity", "Please enter a valid quantity greater than zero.", "OK");
            }
        }
    }

}
