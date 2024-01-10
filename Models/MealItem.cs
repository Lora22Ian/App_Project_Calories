using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Project_Calories.Models
{
    public class MealItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(Meal))]
        public int MealID { get; set; }

        [ForeignKey(typeof(Food))]
        public int FoodID { get; set; }
        
        [Ignore] // Ignore this property for the database
        public string FoodName { get; set; }

        [Ignore] // Ignore this property for the database
        public string MealName { get; set; }

        [Ignore]
        public Meal Meal { get; set; }


        [Ignore]
        public Food Food { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }

    }
}
