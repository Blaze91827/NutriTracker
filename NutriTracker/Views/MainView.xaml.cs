using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NutriTracker.ViewModels;

namespace NutriTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public int totalCalories { get; set; }
        public int totalFats{ get; set; }
        public int totalCarbs { get; set; }
        public int totalProteins { get; set; }
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;

            ItemsListView.ItemSelected += (s, e) =>
            ItemsListView.SelectedItem = null;
            
        }
    }
}