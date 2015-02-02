using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace SharpShapes
{
    public class Rectangle : Quadrilateral
    {
        private decimal width;
        public decimal Width 
        {
            get { return this.width; } 
        }

        private decimal height;
        public decimal Height 
        {
            get { return this.height; } 
        }

        public Rectangle(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException();
            }
            this.width = width;
            this.height = height;
        }

        public override decimal Perimeter()
        {
            return 2 * Height + 2 * Width;
        }

        public override decimal Area()
        {
            return Height * Width;
        }

        public override void Scale(int percent)
        {
            if (percent <= 0)
            {
                throw new ArgumentException();
            }

            this.width = width * percent / 100;
            this.height = height * percent / 100;
        }

        public override void DrawOnto(System.Windows.Controls.Canvas ShapeCanvas, int x, int y)
        {

            System.Windows.Shapes.Polygon myPolygon = new System.Windows.Shapes.Polygon();
            myPolygon.Stroke = this.BorderColor;
            myPolygon.Fill = this.FillColor;
            myPolygon.StrokeThickness = 2;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            Point point1 = new Point(x, y);
            Point point2 = new Point(x, y + (double)this.Height);
            Point point3 = new Point(x + (double)this.Width, y + (double)this.Height);
            Point point4 = new Point(x + (double)this.Width, y);

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
