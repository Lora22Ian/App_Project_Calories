using System;
using App_Project_Calories.Data;
using System.IO;

namespace App_Project_Calories
{
    public partial class App : Application
    {
        static FoodDatabase database; 
        public static FoodDatabase Database 
        { 
            get 
            { 
                if (database == null) 
                { 
                    database = new FoodDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Food.db3")); 
                } 
                return database; 
            } 
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
