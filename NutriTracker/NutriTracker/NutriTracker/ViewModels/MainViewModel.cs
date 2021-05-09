using System;
using System.Collections.Generic;
using System.Text;
using NutriTracker.Repositories;
using System.Threading.Tasks;
using System.Windows.Input;
using NutriTracker.Views;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using NutriTracker.Models;
using NutriTracker.Respositories;

namespace NutriTracker.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly FoodRepository repository;
        public ObservableCollection<FoodViewModel> Items { get; set; }
        public FoodViewModel SelectedItem {
            get { return null; }
            set 
            {
                Device.BeginInvokeOnMainThread(async () => await
                NavigateToItem(value));
                RaisePropertyChanged(nameof(SelectedItem));
            }
        }

        private async Task NavigateToItem(FoodViewModel item) {
            if (item == null) {
                return;
            }
            var itemView = Resolver.Resolve<ItemView>();
            var vm = itemView.BindingContext as ItemViewModel;
            vm.Item = item.Item;
            await Navigation.PushAsync(itemView);
        }

        public MainViewModel(FoodRepository repository)
        {

            repository.OnItemAdded += (sender, item) =>
                  Items.Add(CreateFoodViewModel(item));

            repository.OnItemUpdated += (sender, item) =>
                 Task.Run(async () => await LoadData());

            this.repository = repository;

            Task.Run(async () => await LoadData());
        }

        private async Task LoadData() { }

        public ICommand AddItem => new Command(async () =>
        {
            var itemView = Resolver.Resolve<ItemView>();
            await Navigation.PushAsync(itemView);
        });

        private async Task LoadData()
        {
            var items = await repository.GetItems();
            var itemViewModels = items.Select(i => CreateFoodViewModel(i));
            Items = new ObservableCollection<FoodViewModel>(itemViewModels);
        }

        private FoodViewModel CreateTodoItemViewModel(Food item)
        {
            var itemViewModel = new FoodViewModel(item);
            itemViewModel.ItemStatusChanged += ItemStatusChanged;
            return itemViewModel;
        }

        private void ItemStatusChanged(object sender, EventArgs e)
        {
        }

    }
}
