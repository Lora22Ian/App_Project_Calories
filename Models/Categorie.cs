using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace App_Project_Calories.Models
{
    public class Categorie
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        
        [OneToMany] 
        public List<Food> Food { get; set; }
    }
}
