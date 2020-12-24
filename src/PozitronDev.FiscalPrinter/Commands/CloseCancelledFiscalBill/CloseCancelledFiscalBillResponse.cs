using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class CloseCancelledFiscalBillResponse : FiscalResponse
    {
        public CloseCancelledFiscalBillResponse(FiscalResponse response) : base(response)
        {
            var data = response.Data.Split(',');
            int.TryParse(data[0], out var fiscalNum);
            FiscalReceiptNumber = fiscalNum;
            int.TryParse(data[1], out var stornoNum);
            StornoReceiptNumber = stornoNum;
        }

        public int FiscalReceiptNumber { get; set; }
        public int StornoReceiptNumber { get; set; }
    }
}
