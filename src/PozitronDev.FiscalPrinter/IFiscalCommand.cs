using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public interface IFiscalCommand<TResponse> where TResponse : FiscalResponse
    {
        byte Byte { get; }
        string RequestData { get; }

        TResponse MapResponse(FiscalResponse fiscalResponse);
    }
}
