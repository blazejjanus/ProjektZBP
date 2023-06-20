using Microsoft.ML;
using ZBP.Data;

namespace ZBP {
    public class PricePredictor {
        private MLContext Context { get; set; }

        public PricePredictor() {
            Context = new MLContext();
        }

        public Record PredictWig(Record input) {
            WigInput data = DataMapping.WigMapping(input);
            var output = WigPrediction.Predict(data);
            return DataMapping.WigMapping(output);
        }

        public Record PredictWig20(Record input) {
            Wig20Input data = DataMapping.Wig20Mapping(input);
            var output = Wig20Prediction.Predict(data);
            return DataMapping.Wig20Mapping(output);
        }

        public Record PredictAll(Record input) {
            var wig = PredictWig(input);
            var wig20 = PredictWig20(input);
            return MergeResults(wig, wig20);
        }

        public List<Record> PredictWig(List<Record> input) {
            var result = new List<Record>();
            foreach (var record in input) {
                result.Add(PredictWig(record));
            }
            return result;
        }

        public List<Record> PredictWig20(List<Record> input) {
            var result = new List<Record>();
            foreach (var record in input) {
                result.Add(PredictWig20(record));
            }
            return result;
        }

        public List<Record> PredictAll(List<Record> input) {
            var result = new List<Record>();
            foreach (var record in input) {
                result.Add(PredictAll(record));
            }
            return result;
        }

        private Record MergeResults(Record wig, Record wig20) {
            wig.Wig20 = wig20.Wig20; return wig;
        }

        private List<Record> ClearPredictedProps(List<Record> input) {
            var result = new List<Record>();
            foreach(var record in input) {
                result.Add(ClearPredictedProps(record));
            }
            return result;
        }

        private Record ClearPredictedProps(Record input) {
            input.Wig = null; input.Wig20 = null;
            return input;
        }
    }
}
