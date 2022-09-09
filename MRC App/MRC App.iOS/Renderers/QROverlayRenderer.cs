using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using System.ComponentModel;
using CoreGraphics;
using MRC_App.Controls;
using MRC_App.iOS.Renderers;
using MRC_App.iOS.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BaseQROverlay), typeof(QROverlayRenderer))]
namespace MRC_App.iOS.Renderers
{
    public class QROverlayRenderer : ViewRenderer<BaseQROverlay, NativeQROverlay>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BaseQROverlay> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new NativeQROverlay()
                {
                    ContentMode = UIViewContentMode.ScaleToFill
                });
            }

            if (e.NewElement != null)
            {
                Control.Opacity = (float)Element.OverlayOpacity;
                Control.ShowOverlay = Element.ShowOverlay;
                Control.OverlayBackgroundColor = Element.OverlayBackgroundColor.ToUIColor();
                Control.OverlayShape = Element.Shape;
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == BaseQROverlay.OverlayOpacityProperty.PropertyName)
            {
                Control.Opacity = (float)Element.OverlayOpacity;
                Control.UpdateOpacity();
            }
            else if (e.PropertyName == BaseQROverlay.OverlayBackgroundColorProperty.PropertyName)
            {
                Control.OverlayBackgroundColor = Element.OverlayBackgroundColor.ToUIColor();
                Control.UpdateFillColor();
            }
            else if (e.PropertyName == BaseQROverlay.ShapeProperty.PropertyName)
            {
                Control.OverlayShape = Element.Shape;
                Control.UpdatePath();
            }
            else if (e.PropertyName == BaseQROverlay.ShowOverlayProperty.PropertyName)
            {
                Control.ShowOverlay = Element.ShowOverlay;
            }
        }

        bool rendered = false;
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            if (!rendered && Control.ShowOverlay)
            {
                Control.AddOverlayLayer();
                rendered = true;
            }
        }
    }
}