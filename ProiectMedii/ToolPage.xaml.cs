using ProiectMedii.Models;
using ProiectMedii.Data;

namespace ProiectMedii;

public partial class ToolPage : ContentPage
{
    MechanicList s1;
    public ToolPage(MechanicList newlist)
    {
        InitializeComponent();
        s1 = newlist;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var product = (Tool)BindingContext;
        await App.Database.SaveProductAsync(product);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var product = (Tool)BindingContext;
        await App.Database.DeleteProductAsync(product);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }


    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Tool t;
        if (listView.SelectedItem != null)
        {
            t = listView.SelectedItem as Tool;
            var lp = new ListTool()
            {
                ShopListID = s1.ID,
                ProductID = t.ID
            };
            await App.Database.SaveListProductAsync(lp);
            t.ListProducts = new List<ListTool> { lp };
            await Navigation.PopAsync();
        }


    }

}