using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class CloseFiscalBillCommand : IFiscalCommand<CloseFiscalBillResponse>
    {
        public byte Byte => 48;

        public string RequestData => null;

        public CloseFiscalBillResponse MapResponse(FiscalResponse fiscalResponse)
        {
            return new CloseFiscalBillResponse(fiscalResponse);
        }
    }
}
