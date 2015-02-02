using System;
using System.Windows;
using System.Windows.Media;

namespace SharpShapes
{
    public class Trapezoid : Quadrilateral
    {
        public decimal LongBase { get; private set; }
        public decimal ShortBase { get; private set; }
        public decimal Height { get; private set; }
        public decimal AcuteAngle { get; private set; }
        public decimal ObtuseAngle { get; private set; }

        public Trapezoid(int longBase, int shortBase, int height)
        {
            if (height <= 0 || longBase <= 0 || shortBase <= 0 || longBase <= shortBase)
            {
                throw new ArgumentException();
            }
            this.LongBase = longBase;
            this.ShortBase = shortBase;
            this.Height = height;

            decimal wingLength = WingLength();
            this.AcuteAngle = Decimal.Round((decimal)(Math.Atan((double)(Height/wingLength)) * (180 / Math.PI)), 2);
            this.ObtuseAngle = 180 - AcuteAngle;
        }

        private decimal WingLength()
        {
            return (decimal)((LongBase - ShortBase) / 2);
        }

       

        public override void Scale(int percent)
        {
            if (percent <= 0)
            {
                throw new ArgumentException();
            }
            this.LongBase = LongBase * percent / 100;
            this.ShortBase = ShortBase * percent / 100;
            this.Height = Height * percent / 100;
        }

        public override decimal Area()
        {
            return ((LongBase + ShortBase ) / 2) * Height;
        }

        public override decimal Perimeter()
        {
            double squares = (double)((WingLength() * WingLength()) + (Height * Height));
            decimal legLength = Decimal.Round((decimal)Math.Sqrt(squares));
            return LongBase + ShortBase + 2 * legLength;
        }

        public override void DrawOnto(System.Windows.Controls.Canvas ShapeCanvas, int x, int y)
        {
            System.Windows.Shapes.Polygon myPolygon = new System.Windows.Shapes.Polygon();
            myPolygon.Stroke = this.BorderColor;
            myPolygon.Fill = this.FillColor;
            myPolygon.StrokeThickness = 2;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            Point point1 = new Point(x + (double)((this.LongBase-this.ShortBase)/2), y);
            Point point2 = new Point(x, y + (double)this.Height);
            Point point3 = new Point(x + (double)(this.LongBase), y + (double)this.Height);
            Point point4 = new Point(x + (double)(this.LongBase-((this.LongBase-this.ShortBase)/2)), y);

            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(point1);
            myPointCollection.Add(point2);
            myPointCollection.Add(point3);
            myPointCollection.Add(point4);

            myPolygon.Points = myPointCollection;
            ShapeCanvas.Children.Add(myPolygon);
        }
    }
}
