using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class DailyFiscalReportResponse : FiscalResponse
    {
        private readonly ConversionHelper _helper = new ConversionHelper();

        public DailyFiscalReportResponse(FiscalResponse response) : base(response)
        {
            var data = response.RawData.Split(',');

            int.TryParse(data[0], out var fiscalNumber);
            NumOfFiscalRecord = fiscalNumber;
            TotalExcludedTax = _helper.ConvertAccentDecimalStringToDecimal(data[1]);
            TotalExcludedSaleFromTaxA = _helper.ConvertAccentDecimalStringToDecimal(data[2]);
            TotalExcludedSaleFromTaxB = _helper.ConvertAccentDecimalStringToDecimal(data[3]);
            TotalExcludedSaleFromTaxC = _helper.ConvertAccentDecimalStringToDecimal(data[4]);
            TotalExcludedSaleFromTaxD = _helper.ConvertAccentDecimalStringToDecimal(data[5]);
        }

        public int NumOfFiscalRecord { get; set; }
        public decimal TotalExcludedTax { get; set; }
        public decimal TotalExcludedSaleFromTaxA { get; set; }
        public decimal TotalExcludedSaleFromTaxB { get; set; }
        public decimal TotalExcludedSaleFromTaxC { get; set; }
        public decimal TotalExcludedSaleFromTaxD { get; set; }
    }
}
