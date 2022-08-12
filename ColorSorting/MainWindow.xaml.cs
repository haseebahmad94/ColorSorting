using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.IO;
using ColorSorting.Domian.Interfaces;

namespace ColorSorting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IColorSorterRepository _colorSorterRepository;
        public MainWindow(IColorSorterRepository colorSorterRepository)
        {
            InitializeComponent();

            _colorSorterRepository = colorSorterRepository;
        }

        private void RandomColorButton_Click(object sender, RoutedEventArgs e)
        {
            int width = (int)ColorBox.Width, height = (int)ColorBox.Height;

            ColorBox.Source = _colorSorterRepository.GenterateRandomColor(width, height);
        }

        private void SortingColorButton_Click(object sender, RoutedEventArgs e)
        {
            ColorBox.Source = _colorSorterRepository.SortByPixels(((BitmapSource)ColorBox.Source));
        }

    }
}
