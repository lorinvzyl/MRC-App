﻿using Switch;
using Switch.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MRC_App.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CSwitch : CustomSwitch
    {
        public CSwitch()
        {
            InitializeComponent();
            SwitchPanUpdate += (sender, e) =>
            {
                Color fromBackgroundColor = IsToggled ? Color.FromHex("#3f8ba7") : Color.FromHex("#0a0b0b");
                Color toBackgroundColor = IsToggled ? Color.FromHex("#0a0b0b") : Color.FromHex("#3f8ba7");

                double t = e.Percentage * 0.01;

                Flex.TranslationX = -(e.TranslateX + e.XRef);
                BackgroundColor = ColorAnimationUtil.ColorAnimation(fromBackgroundColor, toBackgroundColor, t);
            };
        }
    }
}