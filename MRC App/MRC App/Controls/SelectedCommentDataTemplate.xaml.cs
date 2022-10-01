using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MRC_App.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedCommentDataTemplate : DataTemplate
    {
        public SelectedCommentDataTemplate()
        {
            InitializeComponent();
        }
    }
}