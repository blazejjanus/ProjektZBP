using ZBP.Attributes;
using ZBP.Enums;

namespace ZBP.Data {
    public class Predictions {
        [Factor("WIG", Quantity.Percent)]
        public double Wig { get; set; }
        [Factor("WIG-20", Quantity.Percent)]
        public double Wig20 { get; set; }
        [Factor("WIG-30", Quantity.Percent)]
        public double Wig30 { get; set; }
    }
}
