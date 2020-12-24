using PozitronDev.Convert;
using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class DailyFiscalReportResponse : FiscalResponse
    {
        private readonly ConversionHelper helper = new ConversionHelper();

        public DailyFiscalReportResponse(FiscalResponse response) : base(response)
        {
            var data = response.RawData.Split(',');

            NumOfFiscalRecord = data[0].To().IntOrDefault;

            TotalExcludedTax = helper.ConvertAccentDecimalStringToDecimal(data[1]);
            TotalExcludedSaleFromTaxA = helper.ConvertAccentDecimalStringToDecimal(data[2]);
            TotalExcludedSaleFromTaxB = helper.ConvertAccentDecimalStringToDecimal(data[3]);
            TotalExcludedSaleFromTaxC = helper.ConvertAccentDecimalStringToDecimal(data[4]);
            TotalExcludedSaleFromTaxD = helper.ConvertAccentDecimalStringToDecimal(data[5]);
        }

        public int NumOfFiscalRecord { get; }
        public decimal TotalExcludedTax { get; }
        public decimal TotalExcludedSaleFromTaxA { get; }
        public decimal TotalExcludedSaleFromTaxB { get; }
        public decimal TotalExcludedSaleFromTaxC { get; }
        public decimal TotalExcludedSaleFromTaxD { get; }
    }
}
