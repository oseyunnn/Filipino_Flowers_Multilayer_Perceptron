using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Filipino_Flowers_Multilayer_Perceptron
{
    internal class ImagePreprocessor
    {
        public static double[] ProcessImage(string imagePath)
        {
            using (Bitmap original = new Bitmap(imagePath))
            using (Bitmap resized = new Bitmap(32, 32, PixelFormat.Format24bppRgb))
            {
                double[] inputs = new double[3072];

                using (Graphics graphics = Graphics.FromImage(resized))
                {
                    graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    graphics.DrawImage(original, new Rectangle(0, 0, 32, 32));
                }

                Rectangle bounds = new Rectangle(0, 0, resized.Width, resized.Height);
                BitmapData bitmapData = resized.LockBits(
                    bounds,
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format24bppRgb);

                try
                {
                    int rowBytes = Math.Abs(bitmapData.Stride);
                    byte[] pixels = new byte[rowBytes * 32];
                    Marshal.Copy(bitmapData.Scan0, pixels, 0, pixels.Length);

                    int index = 0;
                    for (int y = 0; y < 32; y++)
                    {
                        int row = bitmapData.Stride > 0
                            ? y * bitmapData.Stride
                            : (31 - y) * rowBytes;

                        for (int x = 0; x < 32; x++)
                        {
                            int pixel = row + (x * 3);
                            inputs[index++] = pixels[pixel + 2] / 255.0;
                            inputs[index++] = pixels[pixel + 1] / 255.0;
                            inputs[index++] = pixels[pixel] / 255.0;
                        }
                    }
                }
                finally
                {
                    resized.UnlockBits(bitmapData);
                }

                return inputs;
            }
        }
    }
}
