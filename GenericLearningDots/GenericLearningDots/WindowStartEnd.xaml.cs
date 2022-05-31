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
using System.Windows.Shapes;

namespace GenericLearningDots
{
    /// <summary>
    /// Interaktionslogik für WindowStartEnd.xaml
    /// </summary>
    public partial class WindowStartEnd : Window
    {
        public Point startpoint { get; }
        public Point endpoint { get; }
        private Grid grid;

        public WindowStartEnd(Grid grid)
        {
            InitializeComponent();
            startpoint = new Point(50, 50);
            endpoint = new Point(200, 50);
            this.grid = grid;
        }

    }


}
