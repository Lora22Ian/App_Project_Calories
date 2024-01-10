using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Project_Calories.Models;

namespace App_Project_Calories.Data
{
    public class FoodDatabase
    {
        readonly SQLiteAsyncConnection _database; 
        public FoodDatabase(string dbPath) 
        { 
            _database = new SQLiteAsyncConnection(dbPath); 
            _database.CreateTableAsync<Food>().Wait();
            _database.CreateTableAsync<Categorie>().Wait();
            _database.CreateTableAsync<Meal>().Wait();
            _database.CreateTableAsync<MealItem>().Wait();
        }
        public Task<List<Food>> GetFoodAsync() 
        { 
            return _database.Table<Food>().ToListAsync(); 
        }
        public Task<Food> GetFoodAsync(int id) 
        { 
            return _database.Table<Food>().Where(i => i.ID == id).FirstOrDefaultAsync(); 
        }
        public Task<int> SaveFoodAsync(Food slist) 
        { 
            if (slist.ID != 0) 
            { 
                return _database.UpdateAsync(slist); 
            } 
            else 
            { 
                return _database.InsertAsync(slist); 
            } 

        }
        public Task<int> DeleteFoodAsync(Food slist) 
        { 
            return _database.DeleteAsync(slist); 
        }

        public Task<List<Categorie>> GetCategoriesAsync() 
        { 
            return _database.Table<Categorie>().ToListAsync(); 
        }
        public Task<int> SaveCategorieAsync(Categorie categorie) 
        { 
            if (categorie.ID != 0) 
            { 
                return _database.UpdateAsync(categorie); 
            } 
            else 
            { 
                return _database.InsertAsync(categorie); 
            } 
        }


        public Task<List<Meal>> GetMealsAsync() 
        { 
            return _database.Table<Meal>().ToListAsync(); 
        }
        public Task<int> SaveMealAsync(Meal meal) 
        { 
            if (meal.ID != 0) 
            { 
                return _database.UpdateAsync(meal); 
            } 
            else 
            { 
                return _database.InsertAsync(meal); 
            } 
        }

        //MealItem
        public Task<List<MealItem>> GetMealItemAsync()
        {
            return _database.Table<MealItem>().ToListAsync();
        }
        public Task<MealItem> GetMealItemAsync(int id)
        {
            return _database.Table<MealItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveMealItemAsync(MealItem mealItem)
        {
            if (mealItem.ID != 0)
            {
                return _database.UpdateAsync(mealItem);
            }
            else
            {
                return _database.InsertAsync(mealItem);
            }
        }

        public Task<int> DeleteMealItemAsync(MealItem mealItem)
        {
            return _database.DeleteAsync(mealItem);
        }


        public Task<List<Food>> GetFoodIdAsync()
        {
            return _database.Table<Food>().ToListAsync();
        }
        public Task<int> SaveFoodIdAsync(Food food)
        {
            if (food.ID != 0)
            {
                return _database.UpdateAsync(food);
            }
            else
            {
                return _database.InsertAsync(food);
            }
        }

        public Task<string> GetFoodNameAsync(int foodId)
        {
            return _database.Table<Food>().Where(f => f.ID == foodId).FirstOrDefaultAsync().ContinueWith(task => task.Result?.Name);
        }


    }
}
