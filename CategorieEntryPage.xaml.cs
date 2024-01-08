using App_Project_Calories.Models;
using App_Project_Calories.Data;
namespace App_Project_Calories;

public partial class CategorieEntryPage : ContentPage
{
	public CategorieEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing() 
	{ 
		base.OnAppearing(); 
		listView.ItemsSource = await App.Database.GetCategoriesAsync(); 
	}
    async void OnCategorieAddedClicked(object sender, EventArgs e) 
	{ 
		await Navigation.PushAsync(new CategoriePage { BindingContext = new Categorie() }); }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e) 
	{ 
		if (e.SelectedItem != null) 
		{ 
			await Navigation.PushAsync(new CategoriePage 
			{ 
				BindingContext = e.SelectedItem as Categorie 
			}); 
		} 
	}
}