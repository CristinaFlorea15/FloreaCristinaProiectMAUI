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
    }
}
