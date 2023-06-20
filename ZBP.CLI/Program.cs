using System.Text;
using System.Text.Json;
using ZBP.Data;

namespace ZBP {
    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine("ZBP Data Manager.\n" + GetOptions());
            List<Record> records = new List<Record>();
            while (true) {
                var command = Console.ReadLine();
                switch(command?.Trim()) {
                    case "r":
                    case "read":
                        string? filePath = string.Empty;
                        try {
                            filePath = GetString("FilePath:", true)?.Trim('\"');
                            if (!File.Exists(filePath)) {
                                Console.WriteLine("File not exists!");
                            } else {
                                FileInfo fileInfo = new FileInfo(filePath ?? "");
                                if (fileInfo.Extension == ".json") {
                                    var fileContent = File.ReadAllText(filePath ?? "");
                                    records = JsonSerializer.Deserialize<List<Record>>(fileContent) ?? throw new Exception("Deserialized JSON was null!");
                                    Console.WriteLine($"Deserialized {records.Count} records.");
                                }
                                if (fileInfo.Extension == ".csv") {
                                    records = Record.DeserializeCSV(filePath ?? "");
                                    Console.WriteLine($"Deserialized {records.Count} records.");
                                }
                            }
                        } catch(Exception exc) {
                            Console.WriteLine($"Error: {exc}");
                        }
                        break;
                    case "readfactor":
                    case "rf":
                        string? propertyName = GetString("PropertyName:", true);
                        filePath = GetString("FilePath:", true);
                        int? dateColumn = GetInt("DateColumn:", false);
                        int? valueColumn = GetInt("ValueColumn:", false);
                        bool? hasTitle = GetBool("HasTitle:", false);
                        var temp = DataHandler.ReadFactor(propertyName ?? "", filePath?.Trim('\"') ?? "", dateColumn ?? 0, valueColumn ?? 0, hasTitle ?? false);
                        Console.WriteLine($"Read {temp.Count} lines.");
                        if(temp.Count > 0) {
                            records = DataHandler.Combine(records, temp);
                        }
                        break;
                    case "show":
                    case "s":
                        foreach(var record in records) {
                            Console.WriteLine(record.ToString(true));
                        }
                        break;
                    case "write":
                    case "w":
                        filePath = GetString("Output path: ", true);
                        Console.WriteLine("Choose file foramt:\n\t1. CSV\n\t2. JSON");
                        int? format = GetInt("", true);
                        switch (format) {
                            case 1: 
                                Record.Save2File(records, filePath ?? "", Enums.DataFormat.CSV);
                                Console.WriteLine("File saved.");
                                break;
                            case 2:
                                Record.Save2File(records, filePath ?? "", Enums.DataFormat.JSON);
                                Console.WriteLine("File saved.");
                                break;
                            default:
                                Console.WriteLine("Invalid file format!");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Enter valid command!"); break;
                }
            }
        }

        private static string? GetString(string message, bool required = true) {
            Console.WriteLine(message);
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
            while (true) {
                var input = GetString(message, required);
                switch(input?.Trim()) {
                    case "true":
                    case "t":
                    case "y":
                        return true;
                    case "n":
                    case "false":
                    case "f":
                        return false;
                    default:
                        Console.WriteLine("Provide valid bool!"); break;
                }
            }
        }

        public static string GetOptions() {
            var sb = new StringBuilder();
            sb.AppendLine("Commands:");
            sb.AppendLine("\tread (r) - reads previously saved data (JSON or CSV)");
            sb.AppendLine("\treadfactor (rf) propertyName, fileName, <dateColumn> <valueColumn> <hasTitle> - reads bare data");
            sb.AppendLine("\twrite (w) filepath - writes to file");
            sb.AppendLine("\tshow (s) - shows all");
            return sb.ToString();
        }
    }
}