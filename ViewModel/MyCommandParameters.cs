using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ViewModel
{
    public class MyCommandParameters
    {
        public TextBox numberOfCirclesTextbox { get; set; }
        public TextBox radiusTextbox { get; set; }
        public Canvas canvas { get; set; }
    }
}
