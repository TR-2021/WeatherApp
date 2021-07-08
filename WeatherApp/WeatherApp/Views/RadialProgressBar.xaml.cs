using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Extensions = SkiaSharp.Views.Forms.Extensions;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RadialProgressBar : ContentView
    {
        public static readonly BindableProperty StrokeColorProperty = BindableProperty.Create("StrokeColor", typeof(Color), typeof(RadialProgressBar), Color.Red);
        public float Value
        {
            get { return _angle; }
            set { _angle = value; updateSurface(); }
        } 


        public Color StrokeColor
        {
            get { return (Color)GetValue(StrokeColorProperty); }
            set { SetValue(StrokeColorProperty, value); }
        }
        public float BarStrokeLength { get; set; } = 10f;
        private float _angle = 0;

        public RadialProgressBar()
        {
            InitializeComponent();
            Value = 0;
        }

        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = StrokeColor.ToSKColor(),
                StrokeWidth = this.BarStrokeLength
            };
            int radius = Math.Min(info.Width, info.Height);
            int max = Math.Max(info.Width, info.Height) - radius;

            SKRect rect = new SKRect(0 + BarStrokeLength / 2, (max / 2) + BarStrokeLength / 2, radius - (BarStrokeLength / 2), radius + (max / 2) - BarStrokeLength / 2);
            SKPath arcPath = new SKPath();
            arcPath.AddArc(rect, 0, Value);
            canvas.DrawPath(arcPath, paint);
        }
        private void updateSurface()
        {
            if (canvasView != null)
                canvasView.InvalidateSurface();
        }

    }
}