using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class CloseFiscalBillCommand : IFiscalCommand<CloseFiscalBillResponse>
    {
        public byte Byte => 56;

        public string RequestData => null;

        public CloseFiscalBillResponse MapResponse(FiscalResponse fiscalResponse)
        {
            return new CloseFiscalBillResponse(fiscalResponse);
        }
    }

    public static partial class FiscalCommandFactoryExtensions
    {
        public static CloseFiscalBillCommand CloseFiscalBill(this IFiscalCommandFactory value)
            => new CloseFiscalBillCommand();
    }
}
