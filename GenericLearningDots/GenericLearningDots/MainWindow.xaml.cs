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
using LearningDots;

namespace GenericLearningDots
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            winStartEnd = new WindowStartEnd(grid1);

            Setting setting = new Setting(winStartEnd.endpoint, winStartEnd.endpoint, 100, false, 500, true, new List<Hindernis>(), 5, new Dictionary<Setting.AbbruchBedingung, int>());

            
        }

        private WindowStartEnd winStartEnd;
        private Training training;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
