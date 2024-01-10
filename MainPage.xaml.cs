using System;
using System.Collections.Generic;
using System.Linq;
using App_Project_Calories.Models;
using App_Project_Calories.Data;
using Microsoft.Maui.Controls;

namespace App_Project_Calories
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime selectedDate = e.NewDate;
            int totalCalories = await CalculateTotalCalories(selectedDate);
            List<(string MealName, int Calories)> mealCalories = await CalculateMealCalories(selectedDate);

            TotalCaloriesLabel.Text = $"Total Calories: {totalCalories}";

            // Clear previous meal calories
            MealCaloriesLayout.Children.Clear();

            // Display meal calories
            foreach (var mealCalorie in mealCalories)
            {
                var mealLabel = new Label
                {
                    Text = $"{mealCalorie.MealName}: {mealCalorie.Calories} Calories",
                    FontSize = 16
                };
                MealCaloriesLayout.Children.Add(mealLabel);
            }
        }

        private async Task<int> CalculateTotalCalories(DateTime selectedDate)
        {
            List<MealItem> mealItems = await App.Database.GetMealItemAsync();
            var foods = await App.Database.GetFoodAsync();
            var meals = await App.Database.GetMealsAsync();
            foreach (var mealItem in mealItems)
            {
                mealItem.Meal = meals.Find(meal => meal.ID == mealItem.MealID);
                mealItem.Food = foods.Find(food => food.ID == mealItem.FoodID);
            }
            int totalCalories = mealItems
                .Where(item => item.Date.Date == selectedDate.Date)
                .Sum(item => item.Quantity * (item.Food?.Calories ?? 0));

            return totalCalories;
        }

        private async Task<List<(string MealName, int Calories)>> CalculateMealCalories(DateTime selectedDate)
        {
            List<MealItem> mealItems = await App.Database.GetMealItemAsync();
            var foods = await App.Database.GetFoodAsync();
            var meals = await App.Database.GetMealsAsync();
            foreach (var mealItem in mealItems)
            {
                mealItem.Meal = meals.Find(meal => meal.ID == mealItem.MealID);
                mealItem.Food = foods.Find(food => food.ID == mealItem.FoodID);
            }
            var mealCalories = mealItems
                .Where(item => item.Date.Date == selectedDate.Date)
                .GroupBy(item => item.Meal?.Name ?? "Missing")
                .Select(group => (MealName: group.Key, Calories: group.Sum(item => item.Quantity * (item.Food?.Calories ?? 0))))
                .ToList();

            return mealCalories;
        }
    }
}
