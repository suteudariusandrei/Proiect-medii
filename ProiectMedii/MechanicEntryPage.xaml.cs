using ProiectMedii.Models;

namespace ProiectMedii;

public partial class MechanicEntryPage : ContentPage
{
	public MechanicEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetShopListsAsync();
    }
    async void OnShopListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MechanicListPage
        {
            BindingContext = new MechanicList()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new MechanicListPage
            {
                BindingContext = e.SelectedItem as MechanicList
            });
        }
    }


}