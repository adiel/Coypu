using System.IO;
using System.Windows.Media.Imaging;
using NUnit.Framework;

namespace Coypu.Drivers.Tests
{
    internal class When_taking_screenshots : DriverSpecs
    {
        [Test]
        public void Saves_a_jpeg_to_disk()
        {
            var saveAs = "screenshot.jpeg";
            try
            {
                Driver.TakeScreenshot(saveAs,Root, System.Drawing.Imaging.ImageFormat.Jpeg);
                using (Stream imageStreamSource = new FileStream(saveAs, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var decoder = new JpegBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat,
                                                        BitmapCacheOption.Default);
                    BitmapSource bitmapSource = decoder.Frames[0];
                    Assert.That(bitmapSource, Is.Not.Null);
                }
            }
            finally
            {
                File.Delete(saveAs);
            }
        }
    }
}