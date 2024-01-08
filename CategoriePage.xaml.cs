using App_Project_Calories.Models;
using App_Project_Calories.Data;
namespace App_Project_Calories;

public partial class CategoriePage : ContentPage
{
	public CategoriePage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e) 
	{ 
		var categorie = (Categorie)BindingContext; 
		await App.Database.SaveCategorieAsync(categorie); 
		await Navigation.PopAsync(); 
	}
}