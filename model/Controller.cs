using System;
using Logika;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Model
{
    public class Controller
    {
        public static void spawnCircles(int value, Canvas canvas, int radius)
        {
            Logic.spawnCircles(value, canvas, radius);
        }

        static void Main(string[] args)
        {

        }
    }
   
}
