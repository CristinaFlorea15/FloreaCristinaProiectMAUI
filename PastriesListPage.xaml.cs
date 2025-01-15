using FloreaCristinaProiect.Models;

namespace FloreaCristinaProiect;

public partial class PastriesListPage : ContentPage
{
    public PastriesListPage()
    {
        InitializeComponent();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (PastriesList)BindingContext;
        await App.Database.SavePastriesListAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (PastriesList)BindingContext;
        await App.Database.DeletePastriesListAsync(slist);
        await Navigation.PopAsync();
    }


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
