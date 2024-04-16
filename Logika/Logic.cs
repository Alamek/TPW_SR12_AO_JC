using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Dane;


namespace Logika
{
    public class Logic 
    {

        public static CircleList circleList = new CircleList();

        public static void CreateCircles(Canvas canvas,int value, int radius) 
        {
            if (radius == 0)
            {
                radius = 1;
            }
            else
            {
                if (radius < 0)
                {
                    radius -= radius * 2;
                }
                if (radius > 60)
                {
                    radius = 60;
                }
            }

            for (int i = 0; i < value; i++) 
            {
                CreateCircle(canvas, radius, radius);
            }
        }

        public static void CreateCircle(Canvas canvas, int size, int radius)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());

            int x = r.Next(80, (int)canvas.Width - 20);
            int y = r.Next(80, (int)canvas.Height - 20);
            double speed = 0;


            while (speed == 0)
            {
                Random random = new Random();
                speed = random.Next(-1, 1);
            }

            Circle circleObject = new Circle(x, y, size, radius, speed, 1);
            Random randomc = new Random();
            Color color = Color.FromRgb((byte)randomc.Next(256), (byte)randomc.Next(256), (byte)randomc.Next(256));
            Ellipse circle = new Ellipse
            {
                Width = radius,
                Height = radius,
                Fill = new SolidColorBrush(color)
            };

            Canvas.SetLeft(circle, x - radius);
            Canvas.SetTop(circle, y - radius);

            canvas.Children.Add(circle);

            circleList.AddCircle(circleObject);
            Task task = new Task( () => 
            {
                while (true) {
                    var dispatcher = Application.Current.Dispatcher;
                    dispatcher.Invoke(() =>
                    {

                        double left = Canvas.GetLeft(circle);
                        double top = Canvas.GetTop(circle);

                        if (left + circle.Width >= canvas.ActualWidth) {
                            circleObject.DirectionX = -circleObject.DirectionX;
                        }
                        else if (left <= 0) {
                            circleObject.DirectionX = -circleObject.DirectionX;
                        }

                        if (top + circle.Height >= canvas.ActualHeight) {
                            circleObject.DirectionY = -circleObject.DirectionY;
                        }
                        else if (top <= 0) {
                            circleObject.DirectionY = -circleObject.DirectionY;
                        }

                        circleObject.X += circleObject.DirectionX;
                        circleObject.Y += circleObject.DirectionY;

                        Canvas.SetLeft(circle, circleObject.X - circleObject.Radius);
                        Canvas.SetTop(circle, circleObject.Y - circleObject.Radius);
                    });
                    Thread.Sleep(1);
                }
            });
            task.Start();

        }
        static void Main()
        {

        }
    }
}
