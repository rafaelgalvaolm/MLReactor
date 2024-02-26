using Microsoft.ML;
using MLNetReactor.MachineLearning.Models;
using static MLNetReactor.MLModel;

namespace MLNetReactor.MachineLearning.Services
{
    public class PredictionService
    {

        private readonly ITransformer _model;
        private readonly MLContext _mlContext = new MLContext();

        public PredictionService(string modelPath)
        {
            // Load the trained model
            DataViewSchema modelSchema;
            _model = _mlContext.Model.Load(modelPath, out modelSchema);
        }

        public SalaryPrediction Predict(SalaryData inputData)
        {
            var predEngine = _mlContext.Model.CreatePredictionEngine<SalaryData, SalaryPrediction>(_model);
            return predEngine.Predict(inputData);
        }
    }
}
