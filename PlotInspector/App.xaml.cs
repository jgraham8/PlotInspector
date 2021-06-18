using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PlotInspector.Views;

[assembly: ExportFont("Montserrat-Bold.ttf",Alias="Montserrat-Bold")]
     [assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat-Medium")]
     [assembly: ExportFont("Montserrat-Regular.ttf", Alias = "Montserrat-Regular")]
     [assembly: ExportFont("Montserrat-SemiBold.ttf", Alias = "Montserrat-SemiBold")]
     [assembly: ExportFont("UIFontIcons.ttf", Alias = "FontIcons")]
namespace PlotInspector
{
    public partial class App : Application
    {
        public static string ImageServerPath { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        private static readonly NavigationPage mainPage = new NavigationPage(new MainPage());
        private static readonly NavigationPage wcPage = new NavigationPage(new WeedControlPage());
        private static readonly NavigationPage compostPage = new NavigationPage(new Composting());
        private static readonly NavigationPage boundPage = new NavigationPage(new Boundaries());
        private static readonly NavigationPage pathPage = new NavigationPage(new Paths());
        private static readonly NavigationPage otherPage = new NavigationPage(new OtherPage());
        private static readonly NavigationPage summaryPage = new NavigationPage(new SummaryPage());

        public App()
        {
            InitializeComponent();

            MainPage = mainPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public void SwitchScreen(string page)
        {
            switch (page)
            {
                case "main":
                    MainPage = mainPage;
                    break;
                case "weed":
                    MainPage = wcPage;
                    break;
                case "compost":
                    MainPage = compostPage;
                    break;
                case "bound":
                    MainPage = boundPage;
                    break;
                case "paths":
                    MainPage = pathPage;
                    break;
                case "other":
                    MainPage = otherPage;
                    break;
                case "summary":
                    MainPage = summaryPage;
                    break;
            }
        }
    }
}
