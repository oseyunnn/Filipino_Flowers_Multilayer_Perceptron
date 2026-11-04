
using System;
using System.Collections.Generic;
using System.IO;

namespace Filipino_Flowers_Multilayer_Perceptron
{
    internal class FlowerDatasetLoader
    {
        // Five flower categories
        public static readonly string[] FlowerClasses =
        {
            "banana_blossom",
            "gumamela",
            "katuray",
            "squash_flower",
            "sunflower"
        };

        public const int InputCount = 3072;
        public const int OutputCount = 5;


        public static double[][] LoadImages(string datasetPath)
        {
            List<double[]> dataset = new List<double[]>();

            for (int classIndex = 0;
                 classIndex < FlowerClasses.Length;
                 classIndex++)
            {
                string folder = Path.Combine(
                    datasetPath, FlowerClasses[classIndex]);

                if (!Directory.Exists(folder))
                    throw new DirectoryNotFoundException(folder);

                string[] files = Directory.GetFiles(folder);
                Array.Sort(files, StringComparer.OrdinalIgnoreCase);

                foreach (string file in files)
                {
                    string extension =
                        Path.GetExtension(file).ToLowerInvariant();

                    if (extension != ".jpg" &&
                        extension != ".jpeg" &&
                        extension != ".png")
                        continue;

                    // Convert the image into 3072 inputs
                    double[] pixels =
                        ImagePreprocessor.ProcessImage(file);

                    // 3072 input values + 5 target outputs
                    double[] row =
                        new double[InputCount + OutputCount];

                    Array.Copy(pixels, row, InputCount);

                    // One-hot encoding
                    row[InputCount + classIndex] = 1.0;

                    dataset.Add(row);
                }
            }

            return dataset.ToArray();
        }

        public static void SplitData(
            double[][] dataset,
            out double[][] training,
            out double[][] validation,
            out double[][] testing)
        {
            List<double[]> train = new List<double[]>();
            List<double[]> valid = new List<double[]>();
            List<double[]> test = new List<double[]>();

            Random random = new Random(42);

            // Split each flower category separately
            for (int category = 0; category < OutputCount; category++)
            {
                List<double[]> images = new List<double[]>();

                foreach (double[] row in dataset)
                {
                    if (row[InputCount + category] == 1.0)
                        images.Add(row);
                }

                // Shuffle images
                for (int i = images.Count - 1; i > 0; i--)
                {
                    int j = random.Next(i + 1);

                    double[] temp = images[i];
                    images[i] = images[j];
                    images[j] = temp;
                }

                int trainCount = (int)(images.Count * 0.70);
                int validCount = (int)(images.Count * 0.15);

                for (int i = 0; i < images.Count; i++)
                {
                    if (i < trainCount)
                        train.Add(images[i]);
                    else if (i < trainCount + validCount)
                        valid.Add(images[i]);
                    else
                        test.Add(images[i]);
                }
            }

            training = train.ToArray();
            validation = valid.ToArray();
            testing = test.ToArray();
        }


    }
}
