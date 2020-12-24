using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class OpenFiscalBillResponse : FiscalResponse
    {
        public OpenFiscalBillResponse(FiscalResponse response) : base(response)
        {
            var data = response.Data.Split(',');
            int.TryParse(data[0], out var fiscalNum);
            FiscalNumber = fiscalNum;
            int.TryParse(data[1], out var stornoNum);
            FiscalStornoNumber = stornoNum;
        }

        public int FiscalNumber { get; set; }
        public int FiscalStornoNumber { get; set; }
    }
}
