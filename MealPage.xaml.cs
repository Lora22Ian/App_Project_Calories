using App_Project_Calories.Models;

namespace App_Project_Calories;

public partial class MealPage : ContentPage
{
	public MealPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e) 
	{ 
		var shop = (Meal)BindingContext; 
		await App.Database.SaveMealAsync(shop); 
		await Navigation.PopAsync(); 
	}
}
