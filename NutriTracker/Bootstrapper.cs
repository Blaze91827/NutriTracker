using Autofac;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using NutriTracker.Views;
using NutriTracker.Repositories;
using NutriTracker.ViewModels;

namespace NutriTracker
{
    public abstract class Bootstrapper
    {
        protected ContainerBuilder ContainerBuilder { get; private set; }

        public Bootstrapper()
        {
            Initialize();
            FinishInitialization();
        }

        protected virtual void Initialize()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder = new ContainerBuilder();

            foreach (var type in currentAssembly.DefinedTypes
                      .Where(e => e.IsSubclassOf(typeof(Page)) || e.IsSubclassOf(typeof(ViewModel))))
            {
                ContainerBuilder.RegisterType(type.AsType());
            }
            ContainerBuilder.RegisterType<TodoItemRepository>().SingleInstance();
        }

        private void FinishInitialization()
        {
            var container = ContainerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}