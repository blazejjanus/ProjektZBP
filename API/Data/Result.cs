using ZBP.Data;

namespace API.Data {
    public class Result {
        public DateOnly Date { get; set; }
        public double? Wig { get; set; }
        public double? Wig20 { get; set; }

        public static List<Result> FromRecord(List<Record> records) {
            var result = new List<Result>();
            foreach (var record in records) {
                result.Add(FromRecord(record));
            }
            return result;
        }

        public static Result FromRecord(Record record) {
            return new Result {
                Date = record.Date,
                Wig = record.Wig,
                Wig20 = record.Wig20
            };
        }
    }
}
