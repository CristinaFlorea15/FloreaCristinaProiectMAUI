using System;
using FloreaCristinaProiect.Models;
using System.IO;
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
}
