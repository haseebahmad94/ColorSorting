using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media.Imaging;

namespace ColorSorting.Domian.Interfaces
{
    public interface IColorSorterRepository
    {
        BitmapSource GenterateRandomColor(int width, int height);

        BitmapSource SortByPixels(BitmapSource bitmap);

    }
}
