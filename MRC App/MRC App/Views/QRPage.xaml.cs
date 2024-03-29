﻿using MRC_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp.Views.Forms;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;

namespace MRC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRPage : ContentPage
    {
        public QRPage()
        {
            InitializeComponent();
        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            QRViewModel qrViewModel = new QRViewModel();
            qrViewModel.AttendEvent(result.Text);
        }
    }
}