using System;
using System.Collections.Generic;
using System.Text;
using NutriTracker.Models;

namespace NutriTracker.ViewModels
{
    public class FoodViewModel : ViewModel
    {
        public FoodViewModel(Food item) => Item = item;

    }
}
