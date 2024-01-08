using App_Project_Calories.Models;

namespace App_Project_Calories;

public partial class MealEntryPage : ContentPage
{
	public MealEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing() 
	{ 
		base.OnAppearing(); 
		listView.ItemsSource = await App.Database.GetMealsAsync(); 
	}
    async void OnMealAddedClicked(object sender, EventArgs e) 
	{ 
		await Navigation.PushAsync(new MealPage 
		{ 
			BindingContext = new Meal() 
		}); 
	}
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e) 
	{ 
		if (e.SelectedItem != null) 
		{ 
			await Navigation.PushAsync(new MealPage 
			{ 
				BindingContext = e.SelectedItem as Meal 
			}); 
		} 
	}
}