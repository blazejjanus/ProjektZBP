using System.Diagnostics;

namespace ZBP.Data {
    public static class DataHandler {
        public static List<Record> Combine(List<Record> records1, List<Record> records2) {
            if(records1.Count == 0) {
                records1.AddRange(records2);
                return records1;
            } else if(records2.Count == 0) {
                records2.AddRange(records1);
                return records2;
            }
            if (!IsDaily(records1)) {
                NormalizeDates(records1);
            }
            if (!IsDaily(records2)) {
                NormalizeDates(records2);
            }
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

        public static bool IsDaily(List<Record> records, int tolerance = 1) {
            if (records.Count <= 1) {
                return false;
            }
            int totalDifference = 0;
            for (int i = 0; i < records.Count - 1; i++) {
                totalDifference += Math.Abs((records[i + 1].Date.DayNumber - records[i].Date.DayNumber));
            }
            int averageDifference = totalDifference / (records.Count - 1);
            return averageDifference <= tolerance;
        }

        public static List<Record> NormalizeDates(List<Record> records) {
            var result = new List<Record>();
            foreach (var record in records) {
                int numDays = DateTime.DaysInMonth(record.Date.Year, record.Date.Month);
                result.AddRange(NormalizeDate(record, numDays));
            }
            return result;
        }

        public static List<Record> NormalizeDate(Record record, int numDays) {
            var result = new List<Record>();
            var baseDate = record.Date;
            var filledProps = record.GetFilledFactors();
            for (int i = 1; i <= numDays; i++) {
                var tempRecord = new Record(baseDate.AddDays(i));
                foreach(var prop in filledProps) {
                    dynamic? tempValue = prop.GetValue(record);
                    prop.SetValue(tempRecord, tempValue);
                }
                result.Add(tempRecord);
            }
            return result;
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
