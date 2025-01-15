namespace FloreaCristinaProiect
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private async void OnCheckOutClicked(object sender, EventArgs e)
        {
            // Navigate to the Order Confirmation Page
            await Navigation.PushAsync(new OrderConfirmationPage());
        }
    }

}
