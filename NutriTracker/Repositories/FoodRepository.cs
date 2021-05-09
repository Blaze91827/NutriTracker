using System;
using System.Collections.Generic;
using System.Text;
using NutriTracker.Models;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace NutriTracker.Repositories
{
    class FoodRepository : IFoodRepository
    {
        private SQLiteAsyncConnection connection;
        public event EventHandler<Food> OnItemAdded;
        public event EventHandler<Food> OnItemUpdated;

        public async Task<List<Food>> GetItems()
        {
            await CreateConnection();
            return await connection.Table<Food>().ToListAsync();
        }

        public async Task AddItem(Food item)
        {
            await CreateConnection();
            await connection.InsertAsync(item);
            OnItemAdded?.Invoke(this, item);
        }

        public async Task UpdateItem(Food item)
        {
            await CreateConnection();
            await connection.UpdateAsync(item);
            OnItemUpdated?.Invoke(this, item);
        }

        public async Task AddOrUpdate(Food item)
        {
            if (item.Id == 0)
            {
                await AddItem(item);
            }
            else
            {
                await UpdateItem(item);
            }
        }
        private async Task CreateConnection()
        {
            if (connection != null) { return; }

            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var databasePath = Path.Combine(documentPath, "Foods.db");

            connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<Food>();

            if (await connection.Table<Food>().CountAsync() == 0)
            {
                await connection.InsertAsync(new Food()
                {
                    name = "water",
                    calories = 0,
                    fats = 0,
                    carbs = 0,
                    proteins = 0
                });
            }
        }
    }
}
