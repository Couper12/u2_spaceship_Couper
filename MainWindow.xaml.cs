/*
 * Couper Ebbs-Picken
 * March 26th 2018
 * Make spaceships that will fly around and crash
 */

using System;
using System.Collections.Generic;
using System.Linq;
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

namespace u2_spaceship_Couper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        //delcaring a point variable
        Point location1;
        Point location2;

        Spaceship spaceship1;
        Spaceship spaceship2;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btn2Players_Click(object sender, RoutedEventArgs e)
        {
            location1 = new Point(50, 342);
            location2 = new Point(550, 349);
            spaceship1 = new Spaceship(location1, canvas, Brushes.Red);
            spaceship2 = new Spaceship(location2, canvas, Brushes.Blue);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            int orientation1 = spaceship1.turn(e.Key);
            if (e.Key == Key.Left
                || e.Key == Key.Up
                || e.Key == Key.Down
                || e.Key == Key.Right)
            {
                location1 = spaceship1.fly(orientation1, spaceship1, location1);
            }
            if (e.Key == Key.A
                || e.Key == Key.W
                || e.Key == Key.S
                || e.Key == Key.D)
            {
                location2 = spaceship2.fly(orientation1, spaceship2, location2);
            }

            Canvas.SetLeft(spaceship1.rect, location1.X);
            Canvas.SetTop(spaceship1.rect, location1.Y);
            Canvas.SetLeft(spaceship2.rect, location2.X);
            Canvas.SetTop(spaceship2.rect, location2.Y);
            spaceship1.checkCollision(location1, location2);
        }
    }
}
