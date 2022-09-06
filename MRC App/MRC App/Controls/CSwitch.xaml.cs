using Switch;
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
        }
    }
}