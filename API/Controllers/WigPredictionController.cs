using API.Data;
using Microsoft.AspNetCore.Mvc;
using ZBP;
using ZBP.Data;

namespace API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class WigPredictionController : ControllerBase {
        private readonly ILogger<WigPredictionController> _logger;
        private PricePredictor Service { get; set; }

        public WigPredictionController(ILogger<WigPredictionController> logger) {
            _logger = logger;
            Service = new PricePredictor();
        }

        [HttpGet(Name = "GetWig")]
        public IEnumerable<Result> GetWig(List<Record> input) {
            return Result.FromRecord(Service.PredictWig(input));
        }

        [HttpGet(Name = "GetWig20")]
        public IEnumerable<Result> GetWig20(List<Record> input) {
            return Result.FromRecord(Service.PredictWig20(input));
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<Result> GetAll(List<Record> input) {
            return Result.FromRecord(Service.PredictAll(input));
        }

        [HttpGet(Name = "GetWigList")]
        public Result GetWig(Record input) {
            return Result.FromRecord(Service.PredictWig(input));
        }

        [HttpGet(Name = "GetWig20List")]
        public Result GetWig20(Record input) {
            return Result.FromRecord(Service.PredictWig20(input));
        }

        [HttpGet(Name = "GetAllList")]
        public Result GetAll(Record input) {
            return Result.FromRecord(Service.PredictAll(input));
        }
    }
}