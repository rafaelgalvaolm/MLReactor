using Microsoft.AspNetCore.Mvc;
using MLNetReactor.MachineLearning.Models;
using MLNetReactor.MachineLearning.Services;
using MLNetReactor.Models;
using System.Diagnostics;

namespace MLNetReactor.Controllers
{

    public class HomeController : Controller
    {
        private readonly PredictionService _predictionService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _predictionService = new PredictionService(".\\MachineLearning\\MLModel.mlnet");
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            // Sample data
            var sampleData = new MLModel.ModelInput
            {
                Age = 50F,
                Workclass = @"Self-emp-not-inc",
                Column3 = 83311F,
                Education = @"Bachelors",
                Education_num = 13F,
                Marital_status = @"Married-civ-spouse",
                Occupation = @"Exec-managerial",
                Relationship = @"Husband",
                Race = @"White",
                Sex = @"Male",
                Capital_loss = 0F,
                Hours_per_week = 13F,
                Native_country = @"United-States",
                Income = @"<=50K",
            };

            // Predict
            var result = MLModel.Predict(sampleData);

            // Assuming your result has a property you want to display; adjust based on actual result structure
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
