using FloreaCristinaProiect.Models;

namespace FloreaCristinaProiect;

public partial class ReviewAddPage : ContentPage
{
    public ReviewAddPage()
    {
        InitializeComponent();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var review = (Review)BindingContext;

        // Validation
        if (string.IsNullOrWhiteSpace(review.FirstName) || string.IsNullOrWhiteSpace(review.LastName) ||
            review.Stars < 1 || review.Stars > 5 || string.IsNullOrWhiteSpace(review.Comment))
        {
            await DisplayAlert("Invalid Input", "Please fill out all fields with valid data.", "OK");
            return;
        }

        // Insert or update the review in the database
        await App.Database.SaveReviewAsync(review);

        // Return to the previous page
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var review = (Review)BindingContext;
        await App.Database.DeleteReviewAsync(review);
        await Navigation.PopAsync();
    }
}
