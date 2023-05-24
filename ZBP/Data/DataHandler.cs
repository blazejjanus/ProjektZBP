using System.Diagnostics;

namespace ZBP.Data {
    public static class DataHandler {
        public static List<Record> Combine(List<Record> records1, List<Record> records2) {
            var len = Math.Max(records1.Count, records2.Count);
            var result = new List<Record>();
            records1 = records1.OrderBy(x => x.Date).ToList();
            foreach (var record1 in records1) {
                var resultRecord = record1;
                var record2items = records2.Where(x => x.Date == record1.Date).ToList();
                foreach(var item in record2items) { 
                    FillRecord(ref resultRecord, item);
                }
                result.Add(resultRecord);
            }
            return result;
        }

        private static void FillRecord(ref Record target, Record source) {
            var filledSourceProperties = source.GetFilledFactors();
            foreach(var prop in filledSourceProperties) {
                if (!target.IsFilled(prop.Name)) {
                    prop.SetValue(target, prop.GetValue(source));
                } else {
                    Debug.WriteLine($"Property {prop.Name} already filled!");
                }
            }
        }

        public static List<Record> ReadFactor(string propertyName, string filename, int dateColumn = 0, int valueColumn = 1, bool hasTitle = false) {
            var prop = Record.GetProperty(propertyName);
            if (prop == null) { throw new Exception("Invalid property name: " + propertyName); }
            var lines = File.ReadAllLines(filename).ToList();
            List<Record> result = new List<Record>();
            foreach (var line in lines) {
                if (hasTitle) {
                    hasTitle = false; continue; //Ommit title
                }
                var date = line.Split(",").ElementAt(dateColumn).Trim();
                var value = line.Split(",").ElementAt(valueColumn).Trim();
                var current = new Record();
                current.Date = DateOnly.Parse(date);
                if(current.Date < new DateOnly(1991, 5, 1)) { continue; } //Too old data
                prop.SetValue(current, ValueParser.Parse(value, prop.PropertyType));
                result.Add(current);
            }
            return result;
        }
    }
}
