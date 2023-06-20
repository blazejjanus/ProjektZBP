using Microsoft.AspNetCore.Mvc;
using ZBP.API.Data;
using ZBP.Data;

namespace ZBP.API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class WigPredictionController : ControllerBase {
        private readonly ILogger<WigPredictionController> _logger;
        private PricePredictor Service { get; set; }

        public WigPredictionController(ILogger<WigPredictionController> logger) {
            _logger = logger;
            Service = new PricePredictor();
        }

        [HttpPost("Wig")]
        public IEnumerable<Result> GetWig(List<Record> input) {
            return Result.FromRecord(Service.PredictWig(input));
        }

        [HttpPost("Wig20")]
        public IEnumerable<Result> GetWig20(List<Record> input) {
            return Result.FromRecord(Service.PredictWig20(input));
        }

        [HttpPost("All")]
        public IEnumerable<Result> GetAll(List<Record> input) {
            return Result.FromRecord(Service.PredictAll(input));
        }

        [HttpPost("WigList")]
        public Result GetWig(Record input) {
            return Result.FromRecord(Service.PredictWig(input));
        }

        [HttpPost("Wig20List")]
        public Result GetWig20(Record input) {
            return Result.FromRecord(Service.PredictWig20(input));
        }

        [HttpPost("AllList")]
        public Result GetAll(Record input) {
            return Result.FromRecord(Service.PredictAll(input));
        }
    }
}