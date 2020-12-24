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

        public int NumOfFiscalRecord { get; set; }
        public decimal TotalExcludedTax { get; set; }
        public decimal TotalExcludedSaleFromTaxA { get; set; }
        public decimal TotalExcludedSaleFromTaxB { get; set; }
        public decimal TotalExcludedSaleFromTaxC { get; set; }
        public decimal TotalExcludedSaleFromTaxD { get; set; }
    }
}
