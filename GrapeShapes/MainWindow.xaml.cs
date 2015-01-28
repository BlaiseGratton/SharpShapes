using SharpShapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace GrapeShapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateClassList();

            Square square = new Square(30);
            DrawSquare(1, 50, square);
            Square square2 = new Square(200);
            square2.FillColor = System.Drawing.Color.AliceBlue;
            DrawSquare(50, 5, square2);
        }



        private void PopulateClassList()
        {
            var classList = new List<string>();
            var shapeType = typeof(SharpShapes.Shape);
            foreach (Type type in Assembly.GetAssembly(shapeType).GetTypes())
            {
                if (type.IsSubclassOf(shapeType) && !type.IsAbstract)
                {
                    classList.Add(type.Name);
                }
            }
            ShapeType.ItemsSource = classList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private static System.Windows.Media.Color ToMediaColor(System.Drawing.Color color)
        {
            return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        private void DrawSquare(int x, int y, Square square)
        {
            System.Windows.Shapes.Polygon myPolygon = new Polygon();
            
            var mediaColor = ToMediaColor(square.FillColor);

            var fillBrush = new BrushConverter().ConvertFromString(mediaColor.ToString());
            myPolygon.Fill = fillBrush as System.Windows.Media.SolidColorBrush;

            myPolygon.StrokeThickness = 2;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1 = new System.Windows.Point(x, y);
            System.Windows.Point Point2 = new System.Windows.Point(x + (double)square.Height, y);
            System.Windows.Point Point3 = new System.Windows.Point(x + (double)square.Height, y + (double)square.Width);
            System.Windows.Point Point4 = new System.Windows.Point(x, y + (double)square.Width);
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPointCollection.Add(Point4);
            myPolygon.Points = myPointCollection;
            ShapeCanvas.Children.Add(myPolygon);
        }

        private void DrawRectangle()
        {
            System.Windows.Shapes.Polygon myPolygon = new Polygon();
            myPolygon.Stroke = System.Windows.Media.Brushes.Tomato;
            myPolygon.Fill = System.Windows.Media.Brushes.Bisque;
            myPolygon.StrokeThickness = 2;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            System.Windows.Point Point1 = new System.Windows.Point(0, 100);
            System.Windows.Point Point2 = new System.Windows.Point(0, 200);
            System.Windows.Point Point3 = new System.Windows.Point(100, 300);
            System.Windows.Point Point4 = new System.Windows.Point(200, 300);
            System.Windows.Point Point5 = new System.Windows.Point(300, 200);
            System.Windows.Point Point6 = new System.Windows.Point(300, 100);
            System.Windows.Point Point7 = new System.Windows.Point(200, 0);
            System.Windows.Point Point8 = new System.Windows.Point(100, 0); 
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPointCollection.Add(Point4);
            myPointCollection.Add(Point5);
            myPointCollection.Add(Point6);
            myPointCollection.Add(Point7);
            myPointCollection.Add(Point8); 
            myPolygon.Points = myPointCollection;
            ShapeCanvas.Children.Add(myPolygon);
        }
    }
}
