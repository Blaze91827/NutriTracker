using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using NutriTracker.Models;
using NutriTracker.Repositories;

namespace NutriTracker.ViewModels
{
    public class ItemViewModel : ViewModel
    {
        private FoodRepository repository;

        public Food Item { get; set; }

        public ItemViewModel(TodoItemRepository repository)
        {
            this.repository = repository;
            Item = new Food() { };
        }

        public ICommand Save => new Command(async () =>
        {
            await repository.AddOrUpdate(Item);
            await Navigation.PopAsync();
        });
    }
}
