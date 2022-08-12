using ColorSorting.Domian.Interfaces;
using ColorSorting.Domian.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ColorSorting.Infrastructure.Repositories
{
    public class ColorSorterRepository : IColorSorterRepository
    {
        public BitmapSource GenterateRandomColor(int width, int height)
        {
            try
            {
                if (width > 0 && height > 0)
                {
                    // create an array and fill it with random bytes
                    var randomPixels = new byte[4 * width * height];
                    new Random().NextBytes(randomPixels);
                    // create and return a 32-bit color BitmapSource
                    return BitmapSource.Create(width, height, 96d, 96d, PixelFormats.Bgra32, null, randomPixels, width * 4);
                }

            }
            catch (Exception)
            {
            }
            return null;
        }

        public BitmapSource SortByPixels(BitmapSource bitmapSource)
        {
            try
            {
                if (bitmapSource != null)
                {
                    Bitmap bitmap = Utility.BitmapFromSource(bitmapSource);

                    List<Pixel> pixel = new List<Pixel>();

                    for (int i = 0; i < bitmap.Width; i++)
                    {
                        for (int j = 0; j < bitmap.Height; j++)
                        {
                            pixel.Add(new Pixel()
                            {
                                color = bitmap.GetPixel(i, j),
                                hueval = bitmap.GetPixel(i, j).GetHue()
                            });
                        }
                    }
                    pixel = pixel.OrderBy(x => x.hueval).ToList();

                    int index = 0;
                    for (int i = 0; i < bitmap.Width; i++)
                    {
                        for (int j = 0; j < bitmap.Height; j++)
                        {
                            System.Drawing.Color color = pixel[index].color;
                            bitmap.SetPixel(i, j, color);
                            index++;
                        }
                    }

                    return Utility.ConvertBitmap(bitmap);
                }

            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
