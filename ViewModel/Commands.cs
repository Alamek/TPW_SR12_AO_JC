using Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace ViewModel
{
    public class Commands
    {
        public ICommand ClickSpawnButonCommand { get; }
        public MyCommandParameters Parameters { get; set; }

        public Commands()
        {
            Parameters = new MyCommandParameters();
            ClickSpawnButonCommand = new RelayCommand(OnClickSpawnButton, CanSpawn);
            Debug.WriteLine("zinicjalizowano commands");
        }

        private void OnClickSpawnButton(object parameter)
        {
            var parameters = parameter as MyCommandParameters;

            Canvas canvas = parameters.canvas;
            TextBox textBox = parameters.numberOfCirclesTextbox;
            TextBox textBox2 = parameters.radiusTextbox;

            int numberOfCircles = Convert.ToInt32(textBox.Text);
            int radius = Convert.ToInt32(textBox2.Text);
            
            Controller.spawnCircles(numberOfCircles, canvas, radius);
        }

        public bool CanSpawn(object parameter)
        {
            var parameters = parameter as MyCommandParameters;
            if (parameters == null)
            {
                return false;
            }

            var canvas = parameters.canvas;
            TextBox textBox = parameters.numberOfCirclesTextbox;
            TextBox textBox2 = parameters.radiusTextbox;

            int numberOfCircles = Convert.ToInt32(textBox.Text);
            int radius = Convert.ToInt32(textBox2.Text);
            
            Controller.spawnCircles(numberOfCircles, canvas, radius);

            if (parameters == null)
            {
                return false;
            }

            if (numberOfCircles <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        static void Main(string[] args)
        {

        }
    }
}
