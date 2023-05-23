using System.Text;
using ZBP.Data;

namespace ZBP {
    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine("ZBP Data Manager.\n" + GetOptions());
            List<Record> records = null;
            while (true) {
                var command = Console.ReadLine();
                switch(command?.Trim()) {
                    case "read":
                    case "r":
                        string? propertyName = GetString("PropertyName:", true);
                        string? filePath = GetString("FilePath:", true);
                        int? dateColumn = GetInt("DateColumn:", false);
                        int? valueColumn = GetInt("ValueColumn:", false);
                        bool? hasTitle = GetBool("HasTitle:", false);
                        filePath = Path.Combine(Directory.GetCurrentDirectory(), filePath ?? "");
                        var temp = DataHandler.ReadFactor(propertyName ?? "", filePath, dateColumn ?? 0, valueColumn ?? 0, hasTitle ?? false);
                        break;
                    //case "combine":
                    //case "c":
                        //break;
                    case "show":
                    case "s":
                        break;
                    case "write":
                    case "w":
                        break;
                }
            }
        }

        private static string? GetString(string message, bool required = true) {
            Console.Write(message);
            string? input = Console.ReadLine();
            if (required && string.IsNullOrWhiteSpace(input)) {
                Console.WriteLine("Input is required.");
                return GetString(message, required);
            }
            return input;
        }

        private static int? GetInt(string message, bool required = true) {
            var input = GetString(message, required);
            int result;
            var status = Int32.TryParse(input, out result);
            if (!status) {
                if (required) {
                    Console.WriteLine("Input is required.");
                    return GetInt(message, required);
                }
            }
            return result;
        }

        private static bool? GetBool(string message, bool required = true) {
            var input = GetString(message, required);
            bool result;
            var status = bool.TryParse(input, out result);
            if (!status) {
                if (required) {
                    Console.WriteLine("Input is required.");
                    return GetBool(message, required);
                }
            }
            return result;
        }

        public static string GetOptions() {
            var sb = new StringBuilder();
            sb.AppendLine("Commands:");
            sb.AppendLine("read (r) propertyName, fileName, <dateColumn> <valueColumn> <hasTitle> - reads bare data");
            //sb.AppendLine("combine propertyName, propertyName - combines multiple records");
            sb.AppendLine("write filepath - writes to file");
            sb.AppendLine("show - shows all");
            return sb.ToString();
        }
    }
}