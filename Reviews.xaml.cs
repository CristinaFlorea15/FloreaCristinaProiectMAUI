using FloreaCristinaProiect.Models;
using System.Collections.ObjectModel;

namespace FloreaCristinaProiect
{
    public partial class ReviewsPage : ContentPage
    {
        public ObservableCollection<Review> Reviews { get; set; }

        public ReviewsPage()
        {
            InitializeComponent();
            Reviews = new ObservableCollection<Review>();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Clear the existing list and reload data from the database
            Reviews.Clear();
            var reviewsFromDb = await App.Database.GetReviewsAsync();
            foreach (var review in reviewsFromDb)
            {
                Reviews.Add(review);
            }
        }

        async void OnAddReviewClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReviewAddPage
            {
                BindingContext = new Review()
            });
        }

        async void OnDeleteReviewClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var reviewToDelete = button?.CommandParameter as Review;

            if (reviewToDelete != null)
            {
                // Confirm deletion
                var confirm = await DisplayAlert("Delete Review", "Are you sure you want to delete this review?", "Yes", "No");
                if (confirm)
                {
                    // Remove from the database
                    await App.Database.DeleteReviewAsync(reviewToDelete);

                    // Remove from the local collection
                    Reviews.Remove(reviewToDelete);
                }
            }
        }
    }
}
