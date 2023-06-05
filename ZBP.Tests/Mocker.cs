using ZBP.Data;

namespace ZBP.Tests {
    internal static class Mocker {
        internal static Random RNG { get; } = new Random();
        public static List<Record> GetTestRecords(string propertyName, int count = 100, DateOnly? startDay = null) {
            var records = new List<Record>();
            if(startDay == null) {
                startDay = DateOnly.FromDateTime(DateTime.Now);
            }
            for(int i = 0; i < count; i++) {
                records.Add(new Record(startDay.Value.AddDays(i)));
            }
            var prop = Record.GetProperty(propertyName);
            if(prop == null) throw new NullReferenceException(nameof(prop));
            foreach(var record in records) {
                prop.SetValue(record, RNG.NextDouble());
            }
            return records;
        }
    }
}
