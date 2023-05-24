using System.Globalization;

namespace ZBP.Data {
    internal static class ValueParser {
        public static object Parse(string? value, Type? targetType) {
            if(targetType == null) {
                throw new ArgumentNullException(nameof(targetType));
            }
            if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                targetType = Nullable.GetUnderlyingType(targetType);
            }
            if (targetType == typeof(int)) {
                return ParseInt(value);
            } else if (targetType == typeof(double)) {
                return ParseDouble(value);
            } else {
                throw new NotSupportedException("Unsupported type: " + targetType);
            }
        }

        private static int ParseInt(string? value) {
            if (string.IsNullOrEmpty(value)) {
                throw new ArgumentNullException(nameof(value));
            }
            if (int.TryParse(value, out int result)) {
                return result;
            } else {
                throw new FormatException("Invalid integer value: " + value);
            }
        }

        private static double ParseDouble(string? value) {
            if (string.IsNullOrEmpty(value)) {
                throw new ArgumentNullException(nameof(value));
            }
            if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double result)) {
                return result;
            } else {
                throw new FormatException("Invalid double value: " + value);
            }
        }
    }
}
