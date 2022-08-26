using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MRC_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRPage : ContentPage
    {
        public QRPage()
        {
            InitializeComponent();
            ScanAsync();
        }

        public async void ScanAsync()
        {
            try
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                var result = await scanner.Scan();
                if(result != null)
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            
        }
    }
}