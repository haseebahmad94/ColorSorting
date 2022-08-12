using NUnit.Framework;
using ColorSorting.Infrastructure.Repositories;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ColorSorting.UnitTest
{
    public class Tests
    {
        ColorSorterRepository colorSorterRepository = new ColorSorterRepository();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsNotNull_GenerateImageTest()
        { 

            Assert.IsNotNull(colorSorterRepository.GenterateRandomColor(636, 274));
        }


        [Test]
        public void IsNull_GenerateImageTest()
        {
            Assert.IsNull(colorSorterRepository.GenterateRandomColor(0, 274));
            Assert.IsNull(colorSorterRepository.GenterateRandomColor(636, 0));
            Assert.IsNotNull(colorSorterRepository.GenterateRandomColor(636, 274));


        }


        [Test]
        public void IsNotNull_SortImageByPixelsTest()
        {
            BitmapSource bitmapSource = colorSorterRepository.GenterateRandomColor(636, 274);

            Assert.IsNotNull(colorSorterRepository.SortByPixels(bitmapSource));

        }

        [Test]
        public void IsNull_SortImageByPixelsTest()
        {

            Assert.IsNull(colorSorterRepository.SortByPixels(null));

        }
    }
}