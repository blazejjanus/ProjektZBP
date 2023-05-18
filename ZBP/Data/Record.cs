using System.Text.Json;
using ZBP.Enums;

namespace ZBP.Data {
    public class Record {
        public DateOnly Date { get; set; }
        public Predictions Predictions { get; set; }
        public Factors Factors { get; set; }

        public Record() {
            Predictions = new Predictions();
            Factors = new Factors();
        }

        public string ToCSV() {
            string output = string.Empty;
            var props = typeof(StockRecord).GetProperties().ToList();
            props.AddRange(typeof(Predictions).GetProperties().ToList());
            foreach(var prop in props) {
                output += prop.GetValue(this) + ",";
            }
            return output + "\n";
        }

        public static void Save2File(List<Record> data, string filename, DataFormat format = DataFormat.JSON) {
            string output = string.Empty;
            switch (format) {
                case DataFormat.JSON:
                    output = JsonSerializer.Serialize(data, new JsonSerializerOptions() { WriteIndented = true });
                    break;
                case DataFormat.XML:
                    throw new NotSupportedException(); //TODO: Consider removing or adding XML support
                case DataFormat.CSV:
                    foreach(var record in data) {
                        output += record.ToCSV();
                    }
                    break;
            }
            File.WriteAllText(filename, output);
        }
    }
}
