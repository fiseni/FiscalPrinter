using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class CloseFiscalBillResponse : FiscalResponse
    {
        public CloseFiscalBillResponse(FiscalResponse response) : base(response)
        {
            var data = response.RawData.Split(',');
            int.TryParse(data[0], out var fiscalNum);
            FiscalReceiptNumber = fiscalNum;
            int.TryParse(data[1], out var stornoNum);
            StornoReceiptNumber = stornoNum;
        }

        public int FiscalReceiptNumber { get; set; }
        public int StornoReceiptNumber { get; set; }
    }
}
