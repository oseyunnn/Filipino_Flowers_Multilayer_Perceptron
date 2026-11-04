# Filipino Flowers Multilayer Perceptron

A C# WinForms simulation that classifies five flower categories using a custom three-layer multilayer perceptron (3,072 RGB inputs, 64 hidden neurons, and 5 output neurons).

## Flower classes and data

The project uses the supplied image dataset:

- `banana_blossom`
- `gumamela`
- `katuray`
- `squash_flower`
- `sunflower`

Images are resized to 32 x 32 RGB pixels and normalized to `[0, 1]`. The repository already contains separate `Data/train`, `Data/valid`, and `Data/test` folders. Loading is deterministic within each class because filenames are sorted before processing.

## Running the simulation

1. Open `Filipino_Flowers_Multilayer_Perceptron.slnx` in Visual Studio.
2. Build and run the .NET Framework 4.7.2 WinForms project.
3. Click **Load Dataset**.
4. Click **Train Neural Network**. The training log records epoch progress, loss, accuracy, validation accuracy, and the final test report.
5. Use **Upload Flower Image** and **Predict Flower** to classify a new image.
6. Use **Save Training Log** to export the evidence required for submission.

The model is saved at `Models/flower_model.txt`. When training is run again, the existing model is loaded and training continues from those weights. The best validation checkpoint is saved, preventing a later epoch from replacing a better model.

## Training configuration

- Architecture: 3,072 input neurons, 64 hidden neurons, 5 output neurons
- Hidden and output activation: sigmoid
- Input-to-hidden learning rate: `0.03`
- Hidden-to-output learning rate: `0.08`
- Default training budget: `75` epochs
- Samples are shuffled each epoch with a reproducible seed
- Best validation accuracy is used for checkpoint selection

The learning-rate and epoch values are intentionally recorded in the UI log. For a tuning experiment, change one configuration value at a time, save each exported log, and compare training loss, validation accuracy, test accuracy, precision, recall, and the confusion matrix.

## Evaluation evidence

The final log contains:

- Training loss (mean squared error)
- Training, validation, and test accuracy
- Per-class precision and recall on the test set
- A five-class confusion matrix

These metrics support classification evaluation instead of relying only on a final prediction.

## Rubric mapping

| Professor criterion | Evidence in this project |
| --- | --- |
| Functional correctness and backpropagation | `BackNeural.cs` performs forward propagation, output error calculation, hidden error propagation, weight updates, and bias updates. |
| Data preprocessing and pipeline | `ImagePreprocessor.cs` resizes images and normalizes RGB values; `FlowerDatasetLoader.cs` loads class labels and maintains train/validation/test folders. |
| Hyperparameter tuning and experimentation | The architecture, learning rates, epoch count, and checkpoint behavior are written to the training log; exported logs can be compared between runs. |
| Evaluation and performance analysis | Accuracy, loss, per-class precision/recall, and the confusion matrix are printed for the unseen test set. |
| Code quality, design, and documentation | Responsibilities are separated across loader, preprocessing, neural-network, form, and documentation files. The UI provides organized controls and a Filipino-flower visual theme. |

## Professor-library changes

The existing public APIs and model text format were preserved. Minimal changes were made to the professor-provided neural-network implementation because the original initialization range was too large for a 3,072-input sigmoid network and could saturate activations:

- `BackNeural.cs`: stable sigmoid bounds and more conservative learning rates.
- `InputN.cs`: smaller input-layer startup weights.
- `HiddenN.cs`: smaller hidden-layer startup weights.

No external machine-learning library was added.
