using Model;
using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViewModel
{
    public class Commands
    {
        public ICommand ClickSpawnButonCommand { get; }
        public MyCommandParameters Parameters { get; set; }

        public Commands()
        {
            Parameters = new MyCommandParameters();
            ClickSpawnButonCommand = new RelayCommand(OnClickSpawnButton, CanCreate);
            Debug.WriteLine("zinicjalizowano commands");
        }

        private void OnClickSpawnButton(object parameter)
        {
            var parameters = parameter as MyCommandParameters;

            Canvas canvas = parameters.Canvas;
            TextBox textBox = parameters.NumberOfCirclesTextbox;
            TextBox textBox2 = parameters.RadiusTextbox;

            int numberOfCircles = Convert.ToInt32(textBox.Text);
            int radius = Convert.ToInt32(textBox2.Text);
            
            Controller.CreateCircles(canvas, numberOfCircles, radius);
        }

        public bool CanCreate(object parameter)
        {
            if (!(parameter is MyCommandParameters parameters))
            {
                return false;
            }

            var canvas = parameters.Canvas;
            TextBox textBox = parameters.NumberOfCirclesTextbox;
            TextBox textBox2 = parameters.RadiusTextbox;

            int numberOfCircles = Convert.ToInt32(textBox.Text);
            int radius = Convert.ToInt32(textBox2.Text);
            
            Controller.CreateCircles(canvas, numberOfCircles, radius);

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

        static void Main()
        {

        }
    }
}
