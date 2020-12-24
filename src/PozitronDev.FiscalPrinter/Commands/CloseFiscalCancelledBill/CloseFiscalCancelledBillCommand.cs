using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class CloseFiscalCancelledBillCommand : IFiscalCommand<CloseFiscalCancelledBillResponse>
    {
        public byte Byte => 86;

        public string RequestData => null;

        public CloseFiscalCancelledBillResponse MapResponse(FiscalResponse fiscalResponse)
        {
            return new CloseFiscalCancelledBillResponse(fiscalResponse);
        }
    }
}
