using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ZBP.Attributes;
using ZBP.Enums;

namespace ZBP.Data {
    public class Record {
        [JsonIgnore]
        public static DateOnly START_DATE = new DateOnly(2000, 01, 01);
        [JsonIgnore]
        public static DateOnly END_DATE = new DateOnly(2023, 05, 01);
        public DateOnly Date { get; set; }
        public double? Wig { get; set; }
        public double? Wig20 { get; set; }
        public double? PlnChfRate { get; set; }
        public double? PlnEurRate { get; set; }
        public double? PlnGbpRate { get; set; }
        public double? PlnUsdRate { get; set; }
        public double? CpiChf { get; set; }
        public double? CpiGbp { get; set; }
        public double? CpiPln { get; set; }
        public double? CpiUsd { get; set; }
        public double? CpiEur { get; set; }
        public double? InterestRatePln { get; set; }
        public double? PublicDebtPL { get; set; }
        public double? POL_DebtPerGDP { get; set; }
        public double? POL_PopulationGrowth { get; set; }
        public double? POL_Unemployment { get; set; }
        public double? POL_GDP_Growth { get; set; }
        public double? POL_GDP { get; set; }
        public double? POL_GDP_PC { get; set; }
        public double? POL_GDP_PPP { get; set; }
        public double? POL_GDP_PPP_PC { get; set; }
        public double? EU_GDP_Growth { get; set; }
        public double? EU_GDP { get; set; }
        public double? EU_GDP_PC { get; set; }
        public double? EU_GDP_PPP { get; set; }
        public double? EU_GDP_PPP_PC { get; set; }
        public double? Lse { get; set; }
        public double? Nasdaq { get; set; }
        public double? Nyse { get; set; }

        public Record(DateOnly date) {
            Date = date;
        }

        public Record() { }

        public static PropertyInfo? GetProperty(string name) {
            return typeof(Record).GetProperty(name);
        }

        public List<PropertyInfo> GetFilledFactors() {
            var props = GetType().GetProperties().Where(x => x.Name != "Date"); //Not a date
            var result = new List<PropertyInfo>();
            foreach ( var prop in props) {
                if(prop.GetValue(this) != null) {
                    result.Add(prop);
                }
            }
            return result;
        }

        public bool IsFilled(string name) {
            foreach (var prop in GetFilledFactors()) {
                if (prop.Name == name) return true;
            }
            return false;
        }

        public string ToString(bool hideEmpty = false) {
            var sb = new StringBuilder();
            var props = GetType().GetProperties();
            foreach ( var prop in props ) {
                if(hideEmpty && prop.GetValue(this) == null) {
                    continue;
                }
                sb.Append(prop.Name + ": " + prop.GetValue(this)?.ToString()?.Replace(',', '.') + " ");
            }
            return sb.ToString();
        }

        private static string GetCSVTitle() {
            string output = string.Empty;
            var props = typeof(Record).GetProperties().ToList();
            foreach (var prop in props) {
                output += prop.Name + ",";
            }
            return output + "\n";
        }

        public string ToCSV() {
            string output = string.Empty;
            var props = typeof(Record).GetProperties().ToList();
            foreach(var prop in props) {
                output += prop.GetValue(this)?.ToString()?.Replace(',', '.') + ",";
            }
            return output + "\n";
        }

        public static void Save2File(List<Record> data, string filename, DataFormat format = DataFormat.JSON) {
            filename = filename.Trim('\"');
            string output = string.Empty;
            switch (format) {
                case DataFormat.JSON:
                    output = JsonSerializer.Serialize(data, new JsonSerializerOptions() { WriteIndented = true });
                    break;
                case DataFormat.CSV:
                    output += GetCSVTitle();
                    foreach(var record in data) {
                        output += record.ToCSV();
                    }
                    break;
            }
            File.WriteAllText(filename, output);
        }

        public static List<Record> DeserializeCSV(string path) {
            var output = new List<Record>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
                NewLine = Environment.NewLine,
            };
            using(var reader = new StreamReader(path)) {
                using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) {
                    output = csv.GetRecords<Record>().ToList();
                }
            }
            return output;
        }
    }
}
