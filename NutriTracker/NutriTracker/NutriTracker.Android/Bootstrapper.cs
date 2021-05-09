using Autofac;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using NutriTracker.Views;
using NutriTracker.Repositories;
using NutriTracker.ViewModels;

namespace NutriTracker.Android
{
    public class Bootstrapper : NutriTracker.Bootstrapper
    {
        public static void Init()
        {
            var instance = new Bootstrapper();
        }
    }
}