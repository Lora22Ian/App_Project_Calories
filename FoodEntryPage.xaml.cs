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
        listView.ItemsSource = await App.Database.GetFoodAsync();
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
            var selectedFood = e.SelectedItem as Food;

            // Update the label with the selected category
            await Navigation.PushAsync(new FoodPage
            {
                BindingContext = e.SelectedItem as Food
            });
        }
    }

}