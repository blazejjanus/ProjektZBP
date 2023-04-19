using ZBP.Attributes;
using ZBP.Enums;

namespace ZBP.Data {
    public class FinancialRecord {
        #region Prediction
        [Factor("WIG", Quantity.Percent)]
        public double Wig { get; set; }
        [Factor("WIG-20", Quantity.Percent)]
        public double Wig20 { get; set; }
        [Factor("WIG-30", Quantity.Percent)]
        public double Wig30 { get; set; }
        #endregion
        #region Factors
        #region CPI
        [Factor("CPI PLN", Quantity.Percent)]
        public double CpiPln { get; set; }
        [Factor("CPI EUR", Quantity.Percent)]
        public double CpiEur { get; set; }
        [Factor("CPI USD", Quantity.Percent)]
        public double CpiUsd { get; set; }
        [Factor("CPI CHF", Quantity.Percent)]
        public double CpiChf { get; set; }
        #endregion
        #region Currency Rates
        [Factor("USD", "USD Price", Quantity.PLN)]
        public double PlnUsdRate { get; set; }
        [Factor("EUR", "EUR Price", Quantity.PLN)]
        public double PlnEurRate { get; set; }
        [Factor("GBP", "GBP Price", Quantity.PLN)]
        public double PlnGbpRate { get; set; }
        [Factor("CHF", "CHF Price", Quantity.PLN)]
        public double PlnChfRate { get; set; }
        #endregion
        #region Interests
        [Factor("Interest PLN", "PLN Interest Rate", Quantity.Percent)]
        public double InterestRatePln { get; set; }
        [Factor("Interest EUR", "EUR Interest Rate", Quantity.Percent)]
        public double InterestRateEur { get; set; }
        [Factor("Interest USD", "USD Interest Rate", Quantity.Percent)]
        public double InterestRateUsd { get; set; }
        [Factor("Interest CHF", "CHF Interest Rate", Quantity.Percent)]
        public double InterestRateChf { get; set; }
        #endregion
        #region StockExchanges
        [Factor("LSE", "London Stock Exchange", Quantity.Percent)]
        public double Lse { get; set; }
        [Factor("Nasdaq", Quantity.Percent)]
        public double Nasdaq { get; set; }
        [Factor("NYSE", "New York Stock Exchange", Quantity.Percent)]
        public double Nyse { get; set; }
        [Factor("SSE", "Shanghai Stock Exchange", Quantity.Percent)]
        public double Sse { get; set; }
        [Factor("SZSE", "ShenZen Stock Exchange", Quantity.Percent)]
        public double Szse { get; set; }
        [Factor("JPX", "Japan Stock Exchange", Quantity.Percent)]
        public double Jpx { get; set; }
        #endregion
        #region EU Economy
        [Factor("GDP Growth EU", Frequency.Year, Quantity.Percent)]
        public double GdpGrowthEu { get; set; }
        [Factor("GDP Total EU", Frequency.Year, Quantity.USD)]
        public double GdpTotalEu { get; set; }
        [Factor("GDP(PPP) Total EU", Frequency.Year, Quantity.USD)]
        public double GdpPppTotalEu { get; set; }
        [Factor("GDP PerCapita EU", Frequency.Year, Quantity.USD)]
        public double GdpPcEu { get; set; }
        #endregion
        #region PL Economy
        [Factor("Unemployment", Frequency.Month, Quantity.Percent)]
        public double Unemployment { get; set; }
        [Factor("GDP Growth PL", Frequency.Year, Quantity.Percent)]
        public double GdpGrowthPl { get; set; }
        [Factor("GDP Total PL", Frequency.Year, Quantity.USD)]
        public double GdpTotalPl { get; set; }
        [Factor("GDP(PPP) Total PL", Frequency.Year, Quantity.USD)]
        public double GdpPppTotalPl { get; set; }
        [Factor("GDP PerCapita PL", Frequency.Year, Quantity.USD)]
        public double GdpPcPl { get; set; }
        [Factor("RNI", "Rate of natural increase", Frequency.Year, Quantity.Percent)]
        public double RniPl { get; set; }
        [Factor("HDI", "Human Development Index", Frequency.Year, Quantity.Value)]
        public double HDI { get; set; }
        [Factor("RSI", "Retail Sales Increase", Frequency.Year, Quantity.Value)]
        public double RSI {get; set; }
        [Factor("BoP", "Balance of Payments", Frequency.Year, Quantity.Percent)]
        public double BoP { get; set; }
        [Factor("BigMac Index", Frequency.Year, Quantity.PLN)]
        public double BigMacIndex { get; set; }
        [Factor("Public Debt", Frequency.Year, Quantity.USD)]
        public double PublicDebt { get; set; }
        #endregion
        #region World
        [Factor("Oil", "Oil Price", Frequency.Month, Quantity.USD)]
        public double OilPrice { get; set; }
        #endregion
        #endregion
    }
}
