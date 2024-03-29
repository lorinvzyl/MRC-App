﻿using Android.Content;
using Android.Graphics;
using Android.Views;
using System;
using Xamarin.Forms;
using MRC_App.Controls;

namespace MRC_App.Controls
{
    public class NativeQROverlay : Android.Views.View
    {
        Bitmap windowFrame;
        float overlayOpacity = 0.4f;
        bool showOverlay = false;

        public bool ShowOverlay
        {
            get { return showOverlay; }
            set
            {
                bool repaint = !showOverlay;
                showOverlay = value;
                if (repaint)
                {
                    Redraw();
                }
            }
        }

        public float Opacity
        {
            get { return overlayOpacity; }
            set
            {
                overlayOpacity = value;
                Redraw();
            }
        }

        Android.Graphics.Color overlayColor = Android.Graphics.Color.ParseColor("#3d3d3d");
        public Android.Graphics.Color OverlayBackgroundColor
        {
            get { return overlayColor; }
            set
            {
                overlayColor = value;
                Redraw();
            }
        }

        BaseQROverlay.OverlayShape overlayShape = BaseQROverlay.OverlayShape.Rectangle;

        public BaseQROverlay.OverlayShape Shape
        {
            get { return overlayShape; }
            set
            {
                overlayShape = value;
                Redraw();

            }
        }


        public NativeQROverlay(Context context, bool showOverlay = false) : base(context)
        {
            ShowOverlay = showOverlay;
            SetWillNotDraw(false);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            if (ShowOverlay)
            {
                if (windowFrame == null)
                {
                    CreateWindowFrame();
                }
                canvas.DrawBitmap(windowFrame, 0, 0, null);
            }
        }

        void Redraw()
        {
            if (ShowOverlay)
            {
                windowFrame?.Recycle();
                windowFrame = null;
                Invalidate();
            }
        }

        void CreateWindowFrame()
        {
            float width = this.Width;
            float height = this.Height;

            windowFrame = Bitmap.CreateBitmap((int)width, (int)height, Bitmap.Config.Argb8888);
            Canvas osCanvas = new Canvas(windowFrame);
            Paint paint = new Paint(PaintFlags.AntiAlias)
            {
                Color = OverlayBackgroundColor,
                Alpha = (int)(255 * Opacity)
            };

            RectF outerRectangle = new RectF(0, 0, width, height);

            osCanvas.DrawRect(outerRectangle, paint);

            Android.Graphics.Rect rect1 = new Android.Graphics.Rect((int)((width / 5) - 10), (int)((height / 3.4)-10), (int)((width / 5 + width / 5 * 3)+10), (int)((height / 3.4 + width / 5 * 3)+10));
            RectF rectF1 = new RectF(rect1);

            paint.SetARGB(255, 63, 139, 167);

            osCanvas.DrawRoundRect(rectF1, 15, 15, paint);

            paint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.Clear));

            Android.Graphics.Rect rect = new Android.Graphics.Rect((int)(width / 5), (int)(height / 3.4), (int)(width / 5 + width / 5 * 3), (int)(height / 3.4 + width / 5 * 3));
            RectF rectF = new RectF(rect);

            osCanvas.DrawRoundRect(rectF,15,15,paint);

            
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            windowFrame?.Recycle();
            windowFrame = null;
        }
    }
}
