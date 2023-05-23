namespace ZBP.Data {
    public static class DataHandler {
        public static List<Record> Combine(List<Record> records) {
            throw new NotImplementedException();
        }

        public static List<Record> Combine(Record record1, Record record2) {
            throw new NotImplementedException();
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
                prop.SetValue(current, Convert.ChangeType(value, prop.PropertyType));
                result.Add(current);
            }
            return result;
        }
    }
}
