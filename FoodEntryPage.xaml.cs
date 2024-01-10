using App_Project_Calories.Data;
using App_Project_Calories.ViewModels;
using App_Project_Calories.Models;

namespace App_Project_Calories;

public partial class FoodEntryPage : ContentPage
{
	public FoodEntryPage()
	{
        InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var categories = await App.Database.GetCategoriesAsync();
        var foods = await App.Database.GetFoodAsync();
        foreach (var food in foods)
        { 
            food.CategorieName = categories.Find(categorie => categorie.ID == food.CategorieID)?.Name ?? "Missing";
        }
        listView.ItemsSource = foods;
    }

    async void OnFoodAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FoodPage
        {
            BindingContext = new Food()
        });
    }

    async void OnFoodViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            // Update the label with the selected category
            await Navigation.PushAsync(new FoodPage
            {
                BindingContext = e.SelectedItem as Food
            });
        }
    }

}