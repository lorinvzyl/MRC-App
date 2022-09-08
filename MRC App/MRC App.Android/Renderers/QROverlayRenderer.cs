using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MRC_App.Controls;
using MRC_App.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BaseQROverlay), typeof(QROverlayRenderer))]
namespace MRC_App.Droid.Renderers
{
    public class QROverlayRenderer : ViewRenderer<BaseQROverlay, NativeQROverlay>
    {
        public QROverlayRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<BaseQROverlay> e)
        {
            base.OnElementChanged(e);

            if(Control == null)
            {
                SetNativeControl(new NativeQROverlay(Context));
            }
            if (e.NewElement != null)
            {
                Control.Opacity = (float)Element.OverlayOpacity;
                Control.ShowOverlay = Element.ShowOverlay;
                Control.OverlayBackgroundColor = Element.OverlayBackgroundColor.ToAndroid();
                Control.Shape = Element.Shape;
            }

            if (e.OldElement != null)
            {

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == BaseQROverlay.OverlayOpacityProperty.PropertyName)
            {
                Control.Opacity = (float)Element.OverlayOpacity;
            }
            else if (e.PropertyName == BaseQROverlay.OverlayBackgroundColorProperty.PropertyName)
            {
                Control.OverlayBackgroundColor = Element.OverlayBackgroundColor.ToAndroid();
            }
            else if (e.PropertyName == BaseQROverlay.ShapeProperty.PropertyName)
            {
                Control.Shape = Element.Shape;
            }
            else if (e.PropertyName == BaseQROverlay.ShowOverlayProperty.PropertyName)
            {
                Control.ShowOverlay = Element.ShowOverlay;
            }
        }
    }
}