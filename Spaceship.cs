using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace u2_spaceship_Couper
{
    class Spaceship
    {
        // how many pixels a spaceship will move when a key is pressede
        private int speed = 15;

        // declaring a rectangle that will be the visual of the ship
        private Rectangle ship;

        // the canvas that the spaceship will be on
        Canvas canvas;
        
        // constructor where the canvas is used and the ship is made with a rectangle and added to the canvas with the location set
        public Spaceship(Point location, System.Windows.Controls.Canvas c, Brush b)
        {
            canvas = c;
            ship = new Rectangle();
            ship.Fill = b;
            ship.Height = 15;
            ship.Width = 15;
            int shipInt = canvas.Children.Add(ship);
 
            Canvas.SetLeft(ship, location.X);
            Canvas.SetTop(ship, location.Y);              
        }

        // using the rectangle so it can be accessed in the MainWindow.xaml.cs 
        public Rectangle rect { get { return ship; } }

        //makes the spaceship turn by changing the direction of orientation depending on the key pressed
        public int turn(System.Windows.Input.Key k)
        {
            int orientation = 0;
            if (k == System.Windows.Input.Key.Left 
                || k == System.Windows.Input.Key.A)
            {
                orientation = 1;
                
            }
            if (k == System.Windows.Input.Key.Up
                || k == System.Windows.Input.Key.W)
            {
                orientation = 2;
            }
            if (k == System.Windows.Input.Key.Right
                || k == System.Windows.Input.Key.D)
            {
                orientation = 3;
            }
            if (k == System.Windows.Input.Key.Down
                || k == System.Windows.Input.Key.S)
            {
                orientation = 4;
            }
            if (k == Key.Q) {
            }
            return orientation;
        }


        // makes the spaceship move in the direction of orientation, it moves at the speed delcared at top
        public Point fly(int orientation, Spaceship spaceship, Point location)
        {
            if (orientation == 1)
            {
                location.X -= speed;
            }
            if (orientation == 2)
            {
                location.Y -= speed;
            }
            if (orientation == 3)
            {
                location.X += speed;
            }
            if (orientation == 4)
            {
                location.Y += speed;
            }
            
            // the following if statements ensure the spaceships don't leave the screen
            if (location.X < 0)
            {
                location.X = 0;
            }
            if (location.X > 570)
            {
                location.X = 570;
            }
            if (location.Y < 42)
            {
                location.Y = 42;
            }
            if (location.Y > 570)
            {
                location.Y = 570;
            }
            Console.WriteLine("Called");
            return location;
        }





        // checks if the spaceship has collided with another
        public void checkCollision(Point location1, Point location2)
        {
            if ((location1.X + 17 >= location2.X 
                && location1.X + 17 <= location2.X + 17 
                && location1.Y + 17 >= location2.Y 
                && location1.Y + 17 <= location2.Y + 17)
                ||( location2.X + 17 >= location1.X 
                && location2.X + 17 <= location1.X + 17 
                && location2.Y + 17 >= location1.Y 
                && location2.Y + 17 <= location1.Y + 17)
                || (location2.Y > location1.Y
                && location2.Y < location1.Y + 17
                && location2.X > location1.X
                && location2.X < location1.X + 17)
                || (location1.X + 17 > location2.X
                && location1.X + 17 < location2.X + 17
                && location1.Y > location2.Y 
                && location1.Y < location2.Y + 17)
                || (location2.X + 17 > location1.X
                && location2.X + 17 < location1.X + 17
                && location2.Y > location1.Y
                && location2.Y < location1.Y + 17)
                )
            {
                // display a message stating that the ships have crashed
                MessageBox.Show("Collision");
            }

        }

    }
}
