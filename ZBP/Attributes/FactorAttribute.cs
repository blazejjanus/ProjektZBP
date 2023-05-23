using System.Reflection;
using System.Text;
using ZBP.Enums;

namespace ZBP.Attributes {
    public class FactorAttribute: Attribute {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public Frequency Period { get; set; }
        public Quantity Type { get; set; }

        public string Description {
            get {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Symbol: " + Symbol);
                sb.AppendLine("Name:   " + Name);
                sb.AppendLine("Period: " + Period.ToString());
                return sb.ToString();
            }
        }

        public FactorAttribute() {
            Symbol = string.Empty;
            Name = string.Empty;
            Period = Frequency.Month;
            Type = Quantity.Value;
        }

        public FactorAttribute(string symbol) {
            Symbol = symbol;
            Name = symbol;
            Period = Frequency.Month;
            Type = Quantity.Value;
        }

        public FactorAttribute(string symbol, string name) {
            Symbol = symbol;
            Name = name;
            Period = Frequency.Month;
            Type = Quantity.Value;
        }

        public FactorAttribute(string symbol, string name, Frequency period) {
            Symbol = symbol;
            Name = name;
            Period = period;
            Type = Quantity.Value;
        }

        public FactorAttribute(string symbol, string name, Frequency period, Quantity type) {
            Symbol = symbol;
            Name = name;
            Period = period;
            Type = type;
        }

        public FactorAttribute(string symbol, Frequency period, Quantity type) {
            Symbol = symbol;
            Name = symbol;
            Period = period;
            Type = type;
        }

        public FactorAttribute(string symbol, Frequency period) {
            Symbol = symbol;
            Name = symbol;
            Period = period;
            Type = Quantity.Value;
        }

        public FactorAttribute(string symbol, Quantity type) {
            Symbol = symbol;
            Name = symbol;
            Period = Frequency.Month;
            Type = type;
        }

        public FactorAttribute(string symbol, string name, Quantity type) {
            Symbol = symbol;
            Name = name;
            Period = Frequency.Month;
            Type = type;
        }

        public static FactorAttribute? GetFactorAttribute(PropertyInfo propertyInfo) {
            return propertyInfo.GetCustomAttribute<FactorAttribute>();
        }
    }
}
