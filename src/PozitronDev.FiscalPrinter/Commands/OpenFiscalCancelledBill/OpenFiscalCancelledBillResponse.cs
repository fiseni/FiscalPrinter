using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class OpenFiscalCancelledBillResponse : FiscalResponse
    {
        public OpenFiscalCancelledBillResponse(FiscalResponse response) : base(response)
        {
            var data = response.RawData.Split(',');
            int.TryParse(data[0], out var fiscalNum);
            FiscalNumber = fiscalNum;
            int.TryParse(data[1], out var stornoNum);
            FiscalStornoNumber = stornoNum;
        }

        public int FiscalNumber { get; set; }
        public int FiscalStornoNumber { get; set; }
    }
}
