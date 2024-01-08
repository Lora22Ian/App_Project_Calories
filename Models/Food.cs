using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Project_Calories.Models;
using SQLiteNetExtensions.Attributes;

namespace App_Project_Calories.Models
{
    public class Food
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public int Calories { get; set; }

        [ForeignKey(typeof(Categorie))] 
        public int CategorieID { get; set; }

    }
}
