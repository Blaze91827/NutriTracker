using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NutriTracker.Models;

namespace NutriTracker.Repositories
{
    interface IFoodRepository
    {
        event EventHandler<Food> OnItemAdded;
        event EventHandler<Food> OnItemUpdated;

        Task<List<Food>> GetItems();
        Task AddItem(Food item);
        Task UpdateItem(Food item);
        Task AddOrUpdate(Food item);
    }
}
