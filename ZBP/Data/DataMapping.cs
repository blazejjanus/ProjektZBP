﻿using Wig20Input = ZBP.Wig20Prediction.ModelInput;
using Wig20Output = ZBP.Wig20Prediction.ModelOutput;
using WigInput = ZBP.WigPrediction.ModelInput;
using WigOutput = ZBP.WigPrediction.ModelOutput;

namespace ZBP.Data {
    public static class DataMapping {
        public static Wig20Input Wig20Mapping(Record record) {
            return new Wig20Input {
                Date = new DateTime(record.Date.Year, record.Date.Month, record.Date.Day),
                Wig = (float)(record.Wig ?? 0),
                Wig20 = (float)(record.Wig20 ?? 0),
                PlnChfRate = (float)(record.PlnChfRate ?? 0),
                PlnEurRate = (float)(record.PlnEurRate ?? 0),
                PlnGbpRate = (float)(record.PlnGbpRate ?? 0),
                PlnUsdRate = (float)(record.PlnUsdRate ?? 0),
                CpiChf = (float)(record.CpiChf ?? 0),
                CpiGbp = (float)(record.CpiGbp ?? 0),
                CpiPln = (float)(record.CpiPln ?? 0),
                CpiUsd = (float)(record.CpiUsd ?? 0),
                CpiEur = (float)(record.CpiEur ?? 0),
                InterestRatePln = (float)(record.InterestRatePln ?? 0),
                PublicDebtPL = (float)(record.PublicDebtPL ?? 0),
                POL_DebtPerGDP = (float)(record.POL_DebtPerGDP ?? 0),
                POL_PopulationGrowth = (float)(record.POL_PopulationGrowth ?? 0),
                POL_Unemployment = (float)(record.POL_Unemployment ?? 0),
                POL_GDP_Growth = (float)(record.POL_GDP_Growth ?? 0),
                POL_GDP = (float)(record.POL_GDP ?? 0),
                POL_GDP_PC = (float)(record.POL_GDP_PC ?? 0),
                POL_GDP_PPP = (float)(record.POL_GDP_PPP ?? 0),
                POL_GDP_PPP_PC = (float)(record.POL_GDP_PPP_PC ?? 0),
                EU_GDP_Growth = (float)(record.EU_GDP_Growth ?? 0),
                EU_GDP = (float)(record.EU_GDP ?? 0),
                EU_GDP_PC = (float)(record.EU_GDP_PC ?? 0),
                EU_GDP_PPP = (float)(record.EU_GDP_PPP ?? 0),
                EU_GDP_PPP_PC = (float)(record.EU_GDP_PPP_PC ?? 0),
                Lse = (float)(record.Lse ?? 0),
                Nasdaq = (float)(record.Nasdaq ?? 0),
                Nyse = (float)(record.Nyse ?? 0)
            };
        }

        public static Record Wig20Mapping(Wig20Output record) {
            return new Record {
                Date = DateOnly.FromDateTime(record.Date),
                Wig = record.Wig,
                Wig20 = record.Wig20,
                PlnChfRate = record.PlnChfRate,
                PlnEurRate = record.PlnEurRate,
                PlnGbpRate = record.PlnGbpRate,
                PlnUsdRate = record.PlnUsdRate,
                CpiChf = record.CpiChf,
                CpiGbp = record.CpiGbp,
                CpiPln = record.CpiPln,
                CpiUsd = record.CpiUsd,
                CpiEur = record.CpiEur,
                InterestRatePln = record.InterestRatePln,
                PublicDebtPL = record.PublicDebtPL,
                POL_DebtPerGDP = record.POL_DebtPerGDP,
                POL_PopulationGrowth = record.POL_PopulationGrowth,
                POL_Unemployment = record.POL_Unemployment,
                POL_GDP_Growth = record.POL_GDP_Growth,
                POL_GDP = record.POL_GDP,
                POL_GDP_PC = record.POL_GDP_PC,
                POL_GDP_PPP = record.POL_GDP_PPP,
                POL_GDP_PPP_PC = record.POL_GDP_PPP_PC,
                EU_GDP_Growth = record.EU_GDP_Growth,
                EU_GDP = record.EU_GDP,
                EU_GDP_PC = record.EU_GDP_PC,
                EU_GDP_PPP = record.EU_GDP_PPP,
                EU_GDP_PPP_PC = record.EU_GDP_PPP_PC,
                Lse = record.Lse,
                Nasdaq = record.Nasdaq,
                Nyse = record.Nyse
            };
        }

        public static WigInput WigMapping(Record record) {
            return new WigInput {
                Date = new DateTime(record.Date.Year, record.Date.Month, record.Date.Day),
                Wig = (float)(record.Wig ?? 0),
                Wig20 = (float)(record.Wig20 ?? 0),
                PlnChfRate = (float)(record.PlnChfRate ?? 0),
                PlnEurRate = (float)(record.PlnEurRate ?? 0),
                PlnGbpRate = (float)(record.PlnGbpRate ?? 0),
                PlnUsdRate = (float)(record.PlnUsdRate ?? 0),
                CpiChf = (float)(record.CpiChf ?? 0),
                CpiGbp = (float)(record.CpiGbp ?? 0),
                CpiPln = (float)(record.CpiPln ?? 0),
                CpiUsd = (float)(record.CpiUsd ?? 0),
                CpiEur = (float)(record.CpiEur ?? 0),
                InterestRatePln = (float)(record.InterestRatePln ?? 0),
                PublicDebtPL = (float)(record.PublicDebtPL ?? 0),
                POL_DebtPerGDP = (float)(record.POL_DebtPerGDP ?? 0),
                POL_PopulationGrowth = (float)(record.POL_PopulationGrowth ?? 0),
                POL_Unemployment = (float)(record.POL_Unemployment ?? 0),
                POL_GDP_Growth = (float)(record.POL_GDP_Growth ?? 0),
                POL_GDP = (float)(record.POL_GDP ?? 0),
                POL_GDP_PC = (float)(record.POL_GDP_PC ?? 0),
                POL_GDP_PPP = (float)(record.POL_GDP_PPP ?? 0),
                POL_GDP_PPP_PC = (float)(record.POL_GDP_PPP_PC ?? 0),
                EU_GDP_Growth = (float)(record.EU_GDP_Growth ?? 0),
                EU_GDP = (float)(record.EU_GDP ?? 0),
                EU_GDP_PC = (float)(record.EU_GDP_PC ?? 0),
                EU_GDP_PPP = (float)(record.EU_GDP_PPP ?? 0),
                EU_GDP_PPP_PC = (float)(record.EU_GDP_PPP_PC ?? 0),
                Lse = (float)(record.Lse ?? 0),
                Nasdaq = (float)(record.Nasdaq ?? 0),
                Nyse = (float)(record.Nyse ?? 0)
            };
        }

        public static Record WigMapping(WigOutput record) {
            return new Record {
                Date = DateOnly.FromDateTime(record.Date),
                Wig = record.Wig,
                Wig20 = record.Wig20,
                PlnChfRate = record.PlnChfRate,
                PlnEurRate = record.PlnEurRate,
                PlnGbpRate = record.PlnGbpRate,
                PlnUsdRate = record.PlnUsdRate,
                CpiChf = record.CpiChf,
                CpiGbp = record.CpiGbp,
                CpiPln = record.CpiPln,
                CpiUsd = record.CpiUsd,
                CpiEur = record.CpiEur,
                InterestRatePln = record.InterestRatePln,
                PublicDebtPL = record.PublicDebtPL,
                POL_DebtPerGDP = record.POL_DebtPerGDP,
                POL_PopulationGrowth = record.POL_PopulationGrowth,
                POL_Unemployment = record.POL_Unemployment,
                POL_GDP_Growth = record.POL_GDP_Growth,
                POL_GDP = record.POL_GDP,
                POL_GDP_PC = record.POL_GDP_PC,
                POL_GDP_PPP = record.POL_GDP_PPP,
                POL_GDP_PPP_PC = record.POL_GDP_PPP_PC,
                EU_GDP_Growth = record.EU_GDP_Growth,
                EU_GDP = record.EU_GDP,
                EU_GDP_PC = record.EU_GDP_PC,
                EU_GDP_PPP = record.EU_GDP_PPP,
                EU_GDP_PPP_PC = record.EU_GDP_PPP_PC,
                Lse = record.Lse,
                Nasdaq = record.Nasdaq,
                Nyse = record.Nyse
            };
        }
    }
}
