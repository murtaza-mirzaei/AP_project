using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace P1
{
    public enum ClockView
    {
        AnalogClock1,
        AnalogClock2,
        AnalogClock3,
        AnalogClock4
    }

    public class Clock
    {
        public ClockView ClockView;
        public Point Center;
        public Grid ClockGrid;
        public int GridSide;

        public Clock(ClockView clockView, Point center, Grid MainGrid)
        {
            this.ClockView = clockView;
            this.Center = center;
            this.ClockGrid = CreateGrid(center, 150);
            MainGrid.Children.Add(ClockGrid);
        }

        public Grid CreateGrid(Point CenterLocation, int side)
        {
            GridSide = side;
            Grid DynamicGrid = new Grid();
            DynamicGrid.Width = side;
            DynamicGrid.Height = side;
            DynamicGrid.Margin = new Thickness(CenterLocation.X, CenterLocation.Y, 0, 0);
            return DynamicGrid;
        }

        #region handClock 
        public Line DrawSecondsHand(int length)
        {
            return DrawLine(FindEndPointOfSecondsHand(length), Brushes.Red, 1);
        }

        private Point FindEndPointOfSecondsHand(int length)
        {
            double theta = DateTime.Now.Second * (Math.PI / 30);
            return new Point(length * (Math.Sin(theta)), -length * (Math.Cos(theta)));
        }

        public Line DrawMinutesHand(int length)
        {
            return DrawLine(FindEndPointOfMinutesHand(length), Brushes.Black, 2);
        }

        private Point FindEndPointOfMinutesHand(int length)
        {
            double theta = DateTime.Now.Minute * (Math.PI / 30) + (DateTime.Now.Second * (Math.PI / 30)) / 60;
            return new Point(length * (Math.Sin(theta)), -length * (Math.Cos(theta)));
        }

        public Line DrawHoursHand(int length)
        {
            return DrawLine(FindEndPointOfHoursHand(length), Brushes.Black, 4);
        }

        private Point FindEndPointOfHoursHand(int length)
        {
            double theta = DateTime.Now.Hour * (Math.PI / 6) + ((DateTime.Now.Minute * (Math.PI / 30)) / 12) + (DateTime.Now.Second * (Math.PI / 30)) / (60 * 12);
            return new Point(length * (Math.Sin(theta)), -length * (Math.Cos(theta)));
        }
        #endregion

        public void DrawBackground(String imagePath)
        {
            Image dynamicImage = new Image();
            dynamicImage.Width = 150;
            dynamicImage.Height = 150;

            // Create a BitmapSource  
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath);
            bitmap.EndInit();

            // Set Image.Source  
            dynamicImage.Source = bitmap;

            // Add Image to Window  
            ClockGrid.Children.Add(dynamicImage);
        }

        public void UpdateClock()
        {
            ClockGrid.Children.Clear();
            if (this.ClockView == ClockView.AnalogClock1)
                this.DrawBackground($"{System.IO.Path.GetFullPath("./")}../../pictures/AnalogClock1.png");

            else if (this.ClockView == ClockView.AnalogClock2)
                this.DrawBackground($"{System.IO.Path.GetFullPath("./ ")}../../pictures/AnalogClock2.png");

            else if (this.ClockView == ClockView.AnalogClock3)
                this.DrawBackground($"{System.IO.Path.GetFullPath("./ ")}../../pictures/AnalogClock3.png");

            else if (this.ClockView == ClockView.AnalogClock4)
                this.DrawBackground($"{System.IO.Path.GetFullPath("./ ")}../../pictures/AnalogClock4.png");

            ClockGrid.Children.Add(DrawSecondsHand(50));
            ClockGrid.Children.Add(DrawMinutesHand(60));
            ClockGrid.Children.Add(DrawHoursHand(40));

        }

        public Line DrawLine(Point EndPoint, SolidColorBrush Color, int Thickness)
        {
            Line myline = new Line();
            myline.Stroke = Color;
            myline.StrokeThickness = Thickness;
            myline.X1 = GridSide / 2;
            myline.Y1 = GridSide / 2;
            myline.X2 = (GridSide / 2) + EndPoint.X;
            myline.Y2 = (GridSide / 2) + EndPoint.Y;

            return myline;
        }

    }
}