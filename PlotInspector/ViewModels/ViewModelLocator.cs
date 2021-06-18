using System;
using System.Collections.Generic;
using System.Text;

namespace PlotInspector.ViewModels
{
    public static class ViewModelLocator
    {
        private static MainPageModel _mainView = new MainPageModel();
        public static MainPageModel MainView
        {
            get
            {
                return _mainView;
            }
        }
    }
}
