using System;
using System.ComponentModel;


namespace Dane
{
   public class Circle : INotifyPropertyChanged {
        public double X { get; set; }
        public double Y { get; set; }
        public int Size { get; set; }
        public int Radius { get; set; }
        public double DirectionX { get; set; }
        public double DirectionY { get; set; }

        public double Speed { get; set; }

        public double Mass { get; set; }

        public Circle(int x, int y, int size, int radius, double speed, double mass) {
            X = x;
            Y = y;
            Size = size;
            Radius = radius;
            Speed = speed;
            Mass = mass;

            DirectionX = 0;
            DirectionY = 0;


            while (DirectionX == 0 && DirectionY == 0) {
                Random random = new Random();
                DirectionX = random.NextDouble();
                DirectionY = random.NextDouble();
            }

            DirectionX *= speed/mass; 
            DirectionY *= speed/mass;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        static void Main() {

        }
    }


}
