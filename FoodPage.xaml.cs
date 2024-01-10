using App_Project_Calories.Models;
using System.ComponentModel;

namespace App_Project_Calories;

public partial class FoodPage : ContentPage
{
    private List<Categorie> categories; // Add a field to store categories

    public FoodPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Fetch categories from the database
        categories = await App.Database.GetCategoriesAsync();
        CategoryPicker.ItemsSource = categories;
        CategoryPicker.SelectedIndex = categories.FindIndex(0, e=>((Food)BindingContext).CategorieID == e.ID);
    }

    private void OnCategorySelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            ((Food)BindingContext).CategorieID = ((Categorie)picker.SelectedItem).ID;
        }
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var food = (Food)BindingContext;

        await App.Database.SaveFoodAsync(food);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Food)BindingContext; await App.Database.DeleteFoodAsync(slist);
        await Navigation.PopAsync();
    }
}