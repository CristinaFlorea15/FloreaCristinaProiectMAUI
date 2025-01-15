namespace FloreaCristinaProiect;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    async void OnViewMenuListClicked(object sender, EventArgs e)
    {
        // Navigate to Menu List Page
        await Navigation.PushAsync(new PastriesListEntryPage());
    }

    async void OnViewCartClicked(object sender, EventArgs e)
    {
        // Navigate to Shopping Cart Page
        await Navigation.PushAsync(new ShoppingCart());
    }

    async void OnLeaveReviewClicked(object sender, EventArgs e)
    {
        // Navigate to Reviews Page
        await Navigation.PushAsync(new ReviewsPage());
    }
}
