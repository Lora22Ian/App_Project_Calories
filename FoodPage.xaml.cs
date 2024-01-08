using App_Project_Calories.Models;

namespace App_Project_Calories;

public partial class FoodPage : ContentPage
{
    public FoodPage()
    {
        InitializeComponent();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Food)BindingContext;
        await App.Database.SaveFoodAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Food)BindingContext; await App.Database.DeleteFoodAsync(slist);
        await Navigation.PopAsync();
    }
    private void OnCaloriesEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
        {
            // Filter out non-numeric characters
            entry.Text = new string(entry.Text.Where(c => char.IsDigit(c)).ToArray());
            ((Food)BindingContext).Calories = int.Parse(entry.Text);
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var categories = await App.Database.GetCategoriesAsync();
        CategoryPicker.ItemsSource = categories;
    }

}