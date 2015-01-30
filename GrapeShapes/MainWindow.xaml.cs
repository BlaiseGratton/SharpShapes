﻿using SharpShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
        }

        public static int ArgumentCountFor(string className)
        {
            Type classType = GetShapeTypeOf(className);
            ConstructorInfo classConstructor = classType.GetConstructors().First();
            return classConstructor.GetParameters().Length;
        }

        private static Type GetShapeTypeOf(string className)
        {
            return Assembly.GetAssembly(typeof(Shape)).GetTypes().Where(shapeType => shapeType.Name == className).First();
        }

        public static Shape InstantiateWithArguments(string className, object[] args)
        {
            Type classType = GetShapeTypeOf(className);
            ConstructorInfo classConstructor = classType.GetConstructors().First();
            return (Shape)classConstructor.Invoke(args);
        }

        private void PopulateClassList()
        {
            var classList = new List<string>();
            var shapeType = typeof(Shape);
            foreach (Type type in Assembly.GetAssembly(shapeType).GetTypes())
            {
                if (type.IsSubclassOf(shapeType) && !type.IsAbstract)
                {
                    classList.Add(type.Name);
                }
            }
            ShapeType.ItemsSource = classList;
        }
        
        private void ShapeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Enable/Disable Inputs based on the number of required arguments.
            string className = (String)ShapeType.SelectedValue;
            // Argument1.Text = ArgumentCountFor(className).ToString();
            int argCount = ArgumentCountFor(className);
            Argument1.IsEnabled = true;
            Argument2.IsEnabled = (argCount > 1);
            Argument3.IsEnabled = (argCount > 2);
            Argument1.Text = "0";
            Argument2.Text = "0";
            Argument3.Text = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string className = (String)ShapeType.SelectedValue;
            int argCount = ArgumentCountFor(className);
            object[] potentialArgs = new object[] { Int32.Parse(Argument1.Text), Int32.Parse(Argument2.Text), Int32.Parse(Argument3.Text) };
            Shape shape = InstantiateWithArguments(className, potentialArgs.Take(argCount).ToArray());
            shape.DrawOnto(ShapeCanvas, 50, 50);
        }

        private void DrawSquare(int x, int y, Rectangle rectangle)
        {
            System.Windows.Shapes.Polygon myPolygon = new System.Windows.Shapes.Polygon();
            //SolidColorBrush border = new SolidColorBrush();
            //border.Color = Color.FromArgb(square.BorderColor.A, square.BorderColor.R, square.BorderColor.G, square.BorderColor.B);
            //SolidColorBrush fill = new SolidColorBrush();
            //fill.Color = Color.FromArgb(square.FillColor.A, square.FillColor.R, square.FillColor.G, square.FillColor.B);
            // myPolygon.Stroke = border;
            // myPolygon.Fill = fill;
            myPolygon.StrokeThickness = 2;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            Point point1 = new Point(x, y);
            Point point2 = new Point(x, y + (double)rectangle.Width);
            Point point3 = new Point(x + (double)rectangle.Width, y + (double)rectangle.Width);
            Point point4 = new Point(x + (double)rectangle.Width, y);

            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(point1);
            myPointCollection.Add(point2);
            myPointCollection.Add(point3);
            myPointCollection.Add(point4);

            myPolygon.Points = myPointCollection;
            ShapeCanvas.Children.Add(myPolygon);
        }

        private void DrawRectangle()
        {
            System.Windows.Shapes.Polygon myPolygon = new System.Windows.Shapes.Polygon();
            myPolygon.Stroke = System.Windows.Media.Brushes.Tomato;
            myPolygon.Fill = System.Windows.Media.Brushes.Bisque;
            myPolygon.StrokeThickness = 2;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            Point point1 = new Point(10, 50);
            Point point2 = new Point(10, 80);
            Point point3 = new Point(50, 80);
            Point point4 = new Point(50, 50);

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