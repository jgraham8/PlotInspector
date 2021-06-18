using Xamarin.Forms;
using PropertyChanged;
using System.Text;
using System;

namespace PlotInspector.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageModel
    {
        public string TxtTotalPlot { get; set; }
        public string TxtUsedPlot { get; set; }
        public int PlotPercent { get; set; } = 0;

        public string TxtError { get; set; } = "";

        public int CultivationScore { get; set; }
        public int WeedSelection { get; set; }
        public int CompSelection { get; set; }
        public int BoundSelection { get; set; }
        public int PathSelection { get; set; }
        public int CustomSelection { get; set; }

        public string CustomMessage { get; set; }

        public int TotalScore { get; set; }
        public string Grade { get; set; }
        public Color GradeColour { get; set; }

        public bool MPSwitchToggled { get; set; } = false;

        public bool MPArea { get; set; } = true;

        public bool MPCalc { get; set; } = false;

        #region RadioGroups
        public bool CURadioGroup { get; set; } = true;
        public bool WCRadioGroup { get; set; } = true;
        public bool CORadioGroup { get; set; } = true;
        public bool BORadioGroup { get; set; } = true;
        public bool PARadioGroup { get; set; } = true;
        public bool OPRadioGroup { get; set; } = true;
        #endregion


        public Command MPSwitchPropChanged => new Command(() =>
        {
            MPArea = !MPArea;
            MPCalc = !MPCalc;
            MPSwitchToggled = !MPSwitchToggled;
            TxtError = "";
        });

        private void RestartInfo()
        {
            CURadioGroup = true;
            WCRadioGroup = true;
            CORadioGroup = true;
            BORadioGroup = true;
            PARadioGroup = true;
            OPRadioGroup = true;
            TotalScore = 0;
            MPSwitchToggled = false;
            MPArea = true;
            MPCalc = false;
            PlotPercent = 0;
            TxtTotalPlot = "";
            TxtUsedPlot = "";
            TxtError = "";
            Grade = "";
            CustomMessage = "";
        }

        private bool CheckCultivatedInput()
        {
            if (!MPSwitchToggled)
            {
                if (double.TryParse(TxtTotalPlot, out double dTotalPlot))
                {
                    if (double.TryParse(TxtUsedPlot, out double dUsedPlot))
                    {
                        if (dUsedPlot < 0 || dTotalPlot < 0)
                        {
                            TxtError = "Neither number can be less than 0";
                            return false;
                        }
                        if (dUsedPlot > dTotalPlot)
                        {
                            TxtError = "Used Area is greater than Total Area";
                            return false;
                        }
                        PlotPercent = (int)Math.Round(dUsedPlot / dTotalPlot * 100);
                        return true;
                    }
                }
                TxtError = "Both inputs must be a number";
                return false;
            }
            return true;
        }

        private void CalculateCult()
        {
            if (PlotPercent >= 90)
            {
                PlotPercent = 100;
            }
            CultivationScore = PlotPercent / 10;
        }

        private void CalculateAll()
        {
            TotalScore += CultivationScore;
            TotalScore += WeedSelection;
            TotalScore += CompSelection;
            TotalScore += BoundSelection;
            TotalScore += PathSelection;
            TotalScore += CustomSelection;

            switch (TotalScore)
            {
                case int n when (n >= 6):
                    Grade = "No action required by plotter.";
                    GradeColour = Color.FromHex("#47CF73");//Green
                    break;
                case int n when (n >= 1 && n <= 5):
                    Grade = "Plotter has 4 weeks until reinspection with eviction if score is not improved to 6 or above.";
                    GradeColour = Color.FromHex("#FDFD96");//Yellow
                    break;
                default:
                    Grade = "Automatic Eviction";
                    GradeColour = Color.FromHex("#FF1A1A");//Red
                    break;
            }
        }

        #region PageNav

        private int currentpage = 0;
        private string[] allpages = { "main","weed","compost","bound","paths","other","summary" };

        public Command NextPage => new Command(() =>
        {
            if (currentpage == 0)
            {
                if (CheckCultivatedInput())
                {
                    currentpage++;                   
                    CalculateCult();
                }
            } 
            else if (currentpage == 5)
            {
                CalculateAll();
                currentpage++;
            }
            else if (currentpage == 6)
            {
                RestartInfo();
                currentpage = 0;
            }
            else
            {
                currentpage++;
            }
            ((App)App.Current).SwitchScreen(allpages[currentpage]);
        });
        #endregion
    }
}
