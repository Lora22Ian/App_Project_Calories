using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Project_Calories.Models
{
    public class Meal
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public string Name { get; set; }

        [OneToMany]
        public List<MealItem> MealItem { get; set; }
    }

}
