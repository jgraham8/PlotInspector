using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlotInspector.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlotInspector.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Schemes : ResourceDictionary
    {
        public Schemes()
        {
            InitializeComponent();
        }
    }
}