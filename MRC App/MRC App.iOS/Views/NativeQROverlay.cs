using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using MRC_App.Controls;
using CoreGraphics;
using CoreAnimation;
using static MRC_App.Controls.BaseQROverlay;

namespace MRC_App.iOS.Views
{
    public class NativeQROverlay : UIView
    {
        bool showOverlay = true;
        public bool ShowOverlay
        {
            get { return showOverlay; }
            set
            {
                showOverlay = value;

                if (showOverlay)
                    AddOverlayLayer();
                else
                    RemoveOverlayLayer();
            }
        }

        CAShapeLayer overlayLayer = null;

        public float Opacity { get; set; } = 0.5f;
        public UIColor OverlayBackgroundColor { get; set; } = UIColor.FromRGB(61,61,61);
        public OverlayShape OverlayShape { get; set; } = OverlayShape.Rectangle;


        public void AddOverlayLayer()
        {
            UIBezierPath path = UIBezierPath.FromRoundedRect(new CGRect(Frame.X, Frame.Y, this.Frame.Width, this.Frame.Height), 0);

            path.AppendPath(UIBezierPath.FromRoundedRect(new CGRect(this.Frame.Width/5, this.Frame.Height/3.4, (this.Frame.Width/5 + this.Frame.Width/5*3), (this.Frame.Height/3.4 + this.Frame.Width/5*3)), 15));

            path.UsesEvenOddFillRule = true;

            CAShapeLayer fillLayer = new CAShapeLayer();
            fillLayer.Path = path.CGPath;
            fillLayer.FillRule = CAShapeLayer.FillRuleEvenOdd;
            fillLayer.FillColor = OverlayBackgroundColor.CGColor;
            fillLayer.Opacity = Opacity;
            overlayLayer = fillLayer;
            Layer.AddSublayer(fillLayer);

        }

        public void UpdatePath()
        {
            UIBezierPath path = UIBezierPath.FromRoundedRect(new CGRect(Frame.X, Frame.Y, this.Frame.Width, this.Frame.Height), 0);
            overlayLayer.Path = path.CGPath;
        }

        public void UpdateOpacity()
        {
            if (overlayLayer != null)
                overlayLayer.Opacity = Opacity;
        }

        public void UpdateFillColor()
        {
            if (overlayLayer != null)
                overlayLayer.FillColor = OverlayBackgroundColor.CGColor;
        }

        public void RemoveOverlayLayer()
        {
            //if(Layer.Sublayers!=null)
            //foreach (var l in Layer.Sublayers)
            //{
            //    l.RemoveFromSuperLayer();
            //}

            overlayLayer?.RemoveFromSuperLayer();
        }
    }
}