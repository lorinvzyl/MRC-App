using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile;

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
            /*
             * Scan qr code.
             * List:
             * 1. Needs to ensure it is actually of type QR code. (do not want random stuff to be scanned)
             * 2. Need to customise how this looks.
             * 
            Device.BeginInvokeOnMainThread(() =>
            {
                
            });
            */
        }
    }
}