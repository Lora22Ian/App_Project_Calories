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
            _database.CreateTableAsync<Food>().Wait(); }
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
    }
}
