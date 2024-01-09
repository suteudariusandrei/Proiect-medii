using ProiectMedii.Models;

namespace ProiectMedii;

public partial class MechanicListPage : ContentPage
{
	public MechanicListPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (MechanicList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (MechanicList)BindingContext;
        await App.Database.DeleteShopListAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ToolPage((MechanicList) this.BindingContext)
        {
            BindingContext = new Tool()
        });

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (MechanicList)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }


}