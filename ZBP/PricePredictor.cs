using Microsoft.ML;

namespace ZBP {
    public class PricePredictor {
        private MLContext Context { get; set; }

        public PricePredictor() {
            Context = new MLContext();
        }
    }
}
