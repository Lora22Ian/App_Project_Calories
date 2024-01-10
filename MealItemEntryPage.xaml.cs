using App_Project_Calories.Data;
using App_Project_Calories.Models;
using App_Project_Calories.ViewModels;

namespace App_Project_Calories;

public partial class MealItemEntryPage : ContentPage
{
	public MealItemEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var foods = await App.Database.GetFoodAsync();
        var meals = await App.Database.GetMealsAsync();
        var mealItems =  await App.Database.GetMealItemAsync();
        foreach(var mealItem in mealItems)
        {
            mealItem.MealName = meals.Find(meal => meal.ID == mealItem.MealID)?.Name ?? "Missing";
            mealItem.FoodName = foods.Find(food => food.ID == mealItem.FoodID)?.Name ?? "Missing";
        }
        listView.ItemsSource = mealItems;
    }

    async void OnMealItemAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MealItemPage
        {
            BindingContext = new MealItem()
        });
    }

    async void OnMealItemViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            MealItem selectedMealItem = e.SelectedItem as MealItem;

            // Set the selected food name and date in the binding context
            BindingContext = new MealItemEntryViewModel
            {
                SelectedFoodName = await App.Database.GetFoodNameAsync(selectedMealItem.FoodID),
                SelectedDate = selectedMealItem.Date.ToString("yyyy-MM-dd"),
            };

            // Update the label with the selected category
            await Navigation.PushAsync(new MealItemPage
            {
                BindingContext = selectedMealItem
            });
        }
    }



}