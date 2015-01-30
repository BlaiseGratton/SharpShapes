﻿using SharpShapes;
using System;
using System.Collections.Generic;
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
            Type classType = Assembly.GetAssembly(typeof(Shape)).GetTypes().Where(shapeType => shapeType.Name == className).First();
            ConstructorInfo classConstructor = classType.GetConstructors().First();
            return classConstructor.GetParameters().Length;
        }

        public static Shape InstantiateWithArguments(string className, object[] args)
        {
            Type classType = Type.GetType(className);
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
            if (ArgumentCountFor(className) == 1)
            {
                Argument2.IsReadOnly = true;
                Argument2.Text = "";
                Argument2.Opacity = .2;
                Argument3.IsReadOnly = true;
                Argument3.Text = "";
                Argument3.Opacity = .2;
            }
            if (ArgumentCountFor(className) == 2)
            {
                Argument2.IsReadOnly = false;
                Argument2.Opacity = 1;
                Argument3.IsReadOnly = true;
                Argument3.Text = "";
                Argument3.Opacity = .2;
            }
            if (ArgumentCountFor(className) == 3)
            {
                Argument2.IsReadOnly = false;
                Argument2.Opacity = 1;
                Argument3.IsReadOnly = false;
                Argument3.Opacity = 1;
            }
        }
    }
}