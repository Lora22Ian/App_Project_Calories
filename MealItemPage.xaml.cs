using App_Project_Calories.Models;
using App_Project_Calories.Data;
namespace App_Project_Calories;

public partial class MealItemPage : ContentPage
{
    private List<Food> food; // Add a field to store categories

    private Food selectedFood;

    private List<Meal> meals;
    private Meal selectedMeal;

    public MealItemPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Fetch categories from the database
        food = await App.Database.GetFoodIdAsync();
        FoodIdPicker.ItemsSource = food;
        FoodIdPicker.SelectedIndex = food.FindIndex(0, e => ((MealItem)BindingContext).FoodID == e.ID);

        meals = await App.Database.GetMealsAsync();
        MealPicker.ItemsSource = meals;
        MealPicker.SelectedIndex = meals.FindIndex(m => m.ID == ((MealItem)BindingContext).MealID);
    }

    private void OnFoodIdSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
        
            ((MealItem)BindingContext).FoodID = ((Food)picker.SelectedItem).ID;
        }
    }


    async void OnSaveMealItemButtonClicked(object sender, EventArgs e)
    {
        var mealItem = (MealItem)BindingContext;

        await App.Database.SaveMealItemAsync(mealItem);
        await Navigation.PopAsync();
    }

    async void OnDeleteMealItemButtonClicked(object sender, EventArgs e)
    {
        var slist = (MealItem)BindingContext; 
        await App.Database.DeleteMealItemAsync(slist);
        await Navigation.PopAsync();
    }

    public string SelectedFoodName
    {
        get { return (string)GetValue(SelectedFoodNameProperty); }
        set { SetValue(SelectedFoodNameProperty, value); }
    }

    public static readonly BindableProperty SelectedFoodNameProperty =
        BindableProperty.Create(nameof(SelectedFoodName), typeof(string), typeof(MealItemPage), string.Empty);

    public string SelectedDate
    {
        get { return (string)GetValue(SelectedDateProperty); }
        set { SetValue(SelectedDateProperty, value); }
    }

    public static readonly BindableProperty SelectedDateProperty =
        BindableProperty.Create(nameof(SelectedDate), typeof(string), typeof(MealItemPage), string.Empty);

    private void OnMealSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            selectedMeal = (Meal)picker.SelectedItem;
            ((MealItem)BindingContext).MealID = selectedMeal.ID;
        }
    }
}