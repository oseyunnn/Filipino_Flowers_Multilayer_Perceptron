using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backprop;
using System.IO;

namespace Filipino_Flowers_Multilayer_Perceptron
{
    public partial class Form1 : Form
    {

        private NeuralNet neuralNetwork = new NeuralNet(3072, 64, 5);
        private string selectedImagePath = null;
        private bool modelReady = false;

        //three stores datasets from different folders
        private double[][] trainingData;
        private double[][] validationData;
        private double[][] testingData;
        public Form1()
        {
            InitializeComponent();

            string datasetPath = Path.GetFullPath(
                Path.Combine(Application.StartupPath, @"..\..\Data")
            );

            if (Directory.Exists(datasetPath))
            {
                MessageBox.Show("Dataset folder found!");
            }
            else
            {
                MessageBox.Show("Dataset folder NOT found:\n" + datasetPath);
            }


            string savedModelPath = Path.GetFullPath(
                Path.Combine(
                    Application.StartupPath,
                    @"..\..\Models\flower_model.txt"
                )
            );

            if (File.Exists(savedModelPath))
            {
                try
                {
                    neuralNetwork = new NeuralNet(3072, 64, 5);
                    neuralNetwork.loadWeights(savedModelPath);

                    modelReady = true;
                    lblPrediction.Text = "Prediction: Model ready";
                }
                catch (Exception ex)
                {
                    modelReady = false;
                    MessageBox.Show("Could not load saved model: " + ex.Message);
                }
            }
        }


        private void LoadImageIntoNetwork(string imagePath)
        {
            // Convert image into 3,072 numerical values
            double[] imageInputs =
                ImagePreprocessor.ProcessImage(imagePath);

            // Send each value to the input neurons
            for (int i = 0; i < imageInputs.Length; i++)
            {
                neuralNetwork.setInputs(i, imageInputs[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select a Flower Image";
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = dialog.FileName;

                    // Display the selected flower image
                    using (Image image = Image.FromFile(imagePath))
                    {
                        Image oldImage = pictureBoxFlower.Image;
                        pictureBoxFlower.Image = new Bitmap(image);
                        if (oldImage != null)
                            oldImage.Dispose();
                    }

                    // Convert the image into neural network inputs
                    LoadImageIntoNetwork(imagePath);
                    selectedImagePath = imagePath;
                    lblPrediction.Text = "Prediction: Not yet classified";
                }
            }

        }

        private void btnLoadDataset_Click(object sender, EventArgs e)
        {
            string datasetPath = Path.GetFullPath(
                Path.Combine(Application.StartupPath, @"..\..\Data")
            );

            try
            {
                Cursor = Cursors.WaitCursor;

                // Load training images
                trainingData = FlowerDatasetLoader.LoadImages(
                    Path.Combine(datasetPath, "train")
                );

                // Load validation images
                validationData = FlowerDatasetLoader.LoadImages(
                    Path.Combine(datasetPath, "valid")
                );

                // Load testing images
                testingData = FlowerDatasetLoader.LoadImages(
                    Path.Combine(datasetPath, "test")
                );

                MessageBox.Show(
                    "Dataset Loaded Successfully!\n\n" +
                    "Training Images: " + trainingData.Length + "\n" +
                    "Validation Images: " + validationData.Length + "\n" +
                    "Testing Images: " + testingData.Length
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dataset: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }


        }

        private async void btnTrainModel_Click(object sender, EventArgs e)
        {
            if (trainingData == null || trainingData.Length == 0)
            {
                MessageBox.Show("Please load the dataset first!");
                return;
            }

            int totalEpochs = 20;

            btnTrainModel.Enabled = false;
            btnLoadDataset.Enabled = false;
            btnUploadImage.Enabled = false;

            try
            {
                modelReady = false;
                // Start with a fresh neural network
                neuralNetwork = new NeuralNet(3072, 64, 5);

                double bestValidationAccuracy = -1;
                int bestEpoch = 0;

                // Location for saving the best model
                string modelFolder = Path.GetFullPath(
                    Path.Combine(Application.StartupPath, @"..\..\Models")
                );

                Directory.CreateDirectory(modelFolder);

                string modelPath = Path.Combine(
                    modelFolder, "flower_model.txt"
                );


                // Update progress on the interface

                txtTrainingLog.Clear();

                txtTrainingLog.AppendText(
                    "Starting Neural Network Training..." +
                    Environment.NewLine +
                    "Total Epochs: " + totalEpochs +
                    Environment.NewLine +
                    "--------------------------------" +
                    Environment.NewLine
                );

                IProgress<int> progress = new Progress<int>(epoch =>
                {
                    // Update the training button
                    btnTrainModel.Text =
                        $"Training... Epoch {epoch}/{totalEpochs}";

                    // Display the completed epoch in the TextBox
                    txtTrainingLog.AppendText(
                        $"Epoch {epoch}/{totalEpochs} completed!" +
                        Environment.NewLine
                    );

                    // Automatically scroll to the latest entry
                    txtTrainingLog.SelectionStart =
                        txtTrainingLog.Text.Length;

                    txtTrainingLog.ScrollToCaret();
                });


                IProgress<string> metricsProgress = new Progress<string>(message =>
                {
                    txtTrainingLog.AppendText(
                        message + Environment.NewLine
                    );
                });


                await Task.Run(() =>
                {
                    Random random = new Random(42);

                    // Repeat training for 20 epochs
                    for (int epoch = 0; epoch < totalEpochs; epoch++)
                    {
                        // Shuffle images every epoch
                        double[][] images = (double[][])trainingData.Clone();

                        for (int i = images.Length - 1; i > 0; i--)
                        {
                            int j = random.Next(i + 1);

                            double[] temp = images[i];
                            images[i] = images[j];
                            images[j] = temp;
                        }

                        // Train on every image
                        foreach (double[] sample in images)
                        {
                            for (int i = 0; i < 3072; i++)
                            {
                                neuralNetwork.setInputs(i, sample[i]);
                            }

                            for (int i = 0; i < 5; i++)
                            {
                                neuralNetwork.setDesiredOutput(
                                    i, sample[3072 + i]);
                            }

                            neuralNetwork.learn();
                        }

                        // Report the completed epoch

                        // Evaluate performance after this epoch
                        double trainLoss = CalculateLoss(trainingData);

                        double trainAccuracy = CalculateAccuracy(trainingData);

                        double validAccuracy = CalculateAccuracy(validationData);   

                        // Save the model only when validation accuracy improves
                        if (validAccuracy > bestValidationAccuracy)
                        {
                            bestValidationAccuracy = validAccuracy;
                            bestEpoch = epoch + 1;

                            neuralNetwork.saveWeights(modelPath);
                        }


                        // Update training progress
                        progress.Report(epoch + 1);

                        // Display actual results

                        metricsProgress.Report(
                            $"Training Loss: {trainLoss:F4}" +
                            Environment.NewLine +
                            $"Training Accuracy: {trainAccuracy:F2}%" +
                            Environment.NewLine +
                            $"Validation Accuracy: {validAccuracy:F2}%" +
                            Environment.NewLine +
                            "--------------------------------"
                        );


                    }
                });

                // Restore the best-performing epoch
                neuralNetwork = new NeuralNet(3072, 64, 5);
                neuralNetwork.loadWeights(modelPath);

                modelReady = true;

                if (validationData == null || validationData.Length == 0)
                {
                    MessageBox.Show("No validation images loaded.");
                    return;
                }

                // Calculate accuracy using unseen validation images

                double trainingAccuracy = await Task.Run(() =>
                    CalculateAccuracy(trainingData)
                );

                double validationAccuracy = await Task.Run(() =>
                    CalculateAccuracy(validationData)
                );



                MessageBox.Show(
                    "Training completed!\n\n" +
                    "Epochs: " + totalEpochs + "\n" +
                    "Training Accuracy: " +
                    trainingAccuracy.ToString("F2") + "%\n" +
                    "Validation Accuracy: " +
                    validationAccuracy.ToString("F2") + "%"
                );


            }
            catch (Exception ex)
            {
                MessageBox.Show("Training error: " + ex.Message);
            }
            finally
            {
                btnTrainModel.Enabled = true;
                btnLoadDataset.Enabled = true;
                btnUploadImage.Enabled = true;
                btnTrainModel.Text = "Train Neural Network";
            }
        }


        private double CalculateAccuracy(double[][] dataset)
        {
            int correctPredictions = 0;

            foreach (double[] sample in dataset)
            {
                // Send image pixels to the input layer
                for (int i = 0; i < 3072; i++)
                {
                    neuralNetwork.setInputs(i, sample[i]);
                }

                // Run the neural network without training
                neuralNetwork.run();

                // Find the predicted flower category
                int predictedClass = 0;
                double highestOutput = neuralNetwork.getOuputData(0);

                for (int i = 1; i < 5; i++)
                {
                    double output = neuralNetwork.getOuputData(i);

                    if (output > highestOutput)
                    {
                        highestOutput = output;
                        predictedClass = i;
                    }
                }

                // Find the actual flower category
                int actualClass = 0;

                for (int i = 0; i < 5; i++)
                {
                    if (sample[3072 + i] == 1.0)
                    {
                        actualClass = i;
                        break;
                    }
                }

                if (predictedClass == actualClass)
                {
                    correctPredictions++;
                }
            }

            return (double)correctPredictions / dataset.Length * 100.0;
        }

        private double CalculateLoss(double[][] dataset)
        {
            double totalLoss = 0;

            foreach (double[] sample in dataset)
            {
                // Set the image inputs
                for (int i = 0; i < 3072; i++)
                {
                    neuralNetwork.setInputs(i, sample[i]);
                }

                // Perform forward propagation only
                neuralNetwork.run();

                // Calculate squared error for each output
                for (int i = 0; i < 5; i++)
                {
                    double predicted = neuralNetwork.getOuputData(i);
                    double expected = sample[3072 + i];

                    double error = expected - predicted;

                    totalLoss += error * error;
                }
            }

            // Return the mean squared error
            return totalLoss / (dataset.Length * 5);
        }


        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            string modelPath = Path.GetFullPath(
                Path.Combine(
                    Application.StartupPath,
                    @"..\..\Models\flower_model.txt"
                )
            );

            if (!File.Exists(modelPath))
            {
                MessageBox.Show(
                    "No trained model found!\n" +
                    "Please train the neural network first."
                );
                return;
            }

            try
            {
                // Create the same network architecture
                neuralNetwork = new NeuralNet(3072, 64, 5);

                // Load previously trained weights
                neuralNetwork.loadWeights(modelPath);
                modelReady = true;

                if (validationData != null && validationData.Length > 0)
                {
                    double savedAccuracy = CalculateAccuracy(validationData);

                    MessageBox.Show(
                        "Saved Model Validation Accuracy: " +
                        savedAccuracy.ToString("F2") + "%"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading model: " + ex.Message
                );
            }
        }


        private void btnPredictFlower_Click(object sender, EventArgs e)
        {
            if (!modelReady)
            {
                MessageBox.Show("Please load a trained model first!");
                return;
            }

            if (string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Please upload a flower image first!");
                return;
            }

            try
            {
                // Convert uploaded image into neural network inputs
                LoadImageIntoNetwork(selectedImagePath);

                // Perform forward propagation
                neuralNetwork.run();

                // Find the output neuron with the highest score
                int predictedClass = 0;
                double highestOutput = neuralNetwork.getOuputData(0);

                for (int i = 1; i < 5; i++)
                {
                    double output = neuralNetwork.getOuputData(i);

                    if (output > highestOutput)
                    {
                        highestOutput = output;
                        predictedClass = i;
                    }
                }

                // Get the predicted flower name
                string flowerName =
                    FlowerDatasetLoader.FlowerClasses[predictedClass];

                flowerName = flowerName.Replace("_", " ");

                // Display prediction
                lblPrediction.Text = "Prediction: " + flowerName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Prediction error: " + ex.Message);
            }
        }


        private void btnSaveTrainingLog_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTrainingLog.Text))
            {
                MessageBox.Show("No training log available to save!");
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Save Training Log";
                dialog.Filter = "Text Files (*.txt)|*.txt";
                dialog.FileName = "flower_training_log.txt";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(
                            dialog.FileName,
                            txtTrainingLog.Text
                        );

                        MessageBox.Show(
                            "Training log saved successfully!"
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Error saving log: " + ex.Message
                        );
                    }
                }
            }
        }

    }
}
