using System;
using System.Drawing;

namespace Filipino_Flowers_Multilayer_Perceptron
{
    internal class ImagePreprocessor
    {
        public static double[] ProcessImage(string imagePath)
        {
            using (Bitmap original = new Bitmap(imagePath))
            using (Bitmap resized = new Bitmap(original, 32, 32)) // might be slow, consider using a more efficient size if needed
            {
                double[] inputs = new double[3072];
                int index = 0;

                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        Color pixel = resized.GetPixel(x, y);

                        inputs[index++] = pixel.R / 255.0;
                        inputs[index++] = pixel.G / 255.0;
                        inputs[index++] = pixel.B / 255.0;
                    }
                }

                return inputs;
            }
        }
    }
}
