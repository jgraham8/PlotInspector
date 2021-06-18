using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlotInspector.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlotInspector.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Boundaries : ContentPage
    {
        public Boundaries()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = ViewModelLocator.MainView;
        }
    }
}
