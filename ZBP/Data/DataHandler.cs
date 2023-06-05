using System.Diagnostics;

namespace ZBP.Data {
    public static class DataHandler {
        public static List<Record> Combine(List<Record> records1, List<Record> records2) {
            var result = new List<Record>();
            foreach (var record in records1) {
                var additions = records2.Where(x => x.Date == record.Date).ToList();
                foreach (var addition in additions) {
                    var filledProps = addition.GetFilledFactors();
                    foreach (var filledProp in filledProps) {
                        if (record.IsFilled(filledProp.Name)) {
                            throw new InvalidOperationException("Cannot join factors that both have the same properties filled!");
                        }
                        var targetProp = Record.GetProperty(filledProp.Name);
                        targetProp?.SetValue(record, filledProp.GetValue(addition));
                    }
                }
                result.Add(record);
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
