namespace ZBP.Data {
    public class StockRecord {
        public DateOnly Date { get; set; }
        public double Growth { get; set; }

        //TODO: Rethink
        public static List<StockRecord> ReadCSV(string filename) {
            var result = new List<StockRecord>();
            if(!File.Exists(filename)) {
                throw new Exception("File not exists!");
            }
            return result;
        }
    }
}
