using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class CloseCancelledFiscalBillCommand : IFiscalCommand<CloseCancelledFiscalBillResponse>
    {
        public byte Byte => 86;

        public string RequestData => null;

        public CloseCancelledFiscalBillResponse MapResponse(FiscalResponse fiscalResponse)
        {
            return new CloseCancelledFiscalBillResponse(fiscalResponse);
        }
    }
}
