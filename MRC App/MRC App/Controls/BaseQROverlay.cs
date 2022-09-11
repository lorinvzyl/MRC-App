
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MRC_App.Controls
{
    public class BaseQROverlay : View
    {
        public static readonly BindableProperty ShowOverlayProperty = BindableProperty.Create(
        propertyName: nameof(ShowOverlay),
        returnType: typeof(bool),
        declaringType: typeof(BaseQROverlay),
        defaultValue: true,
        defaultBindingMode: BindingMode.TwoWay);

        public bool ShowOverlay
        {
            get { return (bool)GetValue(ShowOverlayProperty); }
            set { SetValue(ShowOverlayProperty, value); }
        }

        public static readonly BindableProperty OverlayOpacityProperty = BindableProperty.Create(
        propertyName: nameof(OverlayOpacity),
        returnType: typeof(float),
        declaringType: typeof(BaseQROverlay),
        defaultValue: 1.0f,
        defaultBindingMode: BindingMode.TwoWay);

        public float OverlayOpacity
        {
            get { return (float)GetValue(OverlayOpacityProperty); }
            set { SetValue(OverlayOpacityProperty, value); }
        }

        public static readonly BindableProperty OverlayBackgroundColorProperty = BindableProperty.Create(
            propertyName: nameof(OverlayBackgroundColor),
            returnType: typeof(Color),
            declaringType: typeof(BaseQROverlay),
            defaultValue: Color.Gray,
            defaultBindingMode: BindingMode.TwoWay);

        public Color OverlayBackgroundColor
        {
            get { return (Color)GetValue(OverlayBackgroundColorProperty); }
            set { SetValue(OverlayBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty ShapeProperty = BindableProperty.Create(
           propertyName: nameof(Shape),
           returnType: typeof(OverlayShape),
           declaringType: typeof(BaseQROverlay),
           defaultValue: OverlayShape.Rectangle,
           defaultBindingMode: BindingMode.TwoWay);

        public OverlayShape Shape
        {
            get { return (OverlayShape)GetValue(ShapeProperty); }
            set { SetValue(ShapeProperty, value); }
        }

        public enum OverlayShape
        {
            Rectangle
        }
    }
}
