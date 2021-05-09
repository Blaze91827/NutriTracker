using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NutriTracker.Models
{
    class Food
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string name { get; set; }
        public int calories { get; set; }
        public int fats { get; set; }
        public int carbs { get; set;  }
        public int proteins { get; set; }
    }
}
