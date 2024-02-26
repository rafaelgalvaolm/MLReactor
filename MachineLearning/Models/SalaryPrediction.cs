using Microsoft.ML.Data;

namespace MLNetReactor.MachineLearning.Models
{
    public class SalaryPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }
        public float Probability { get; set; }
        public float Score { get; set; }
    }
}
